using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AMSCore
{

    public class autoSynchronizer : GenericStorage, IDisposable
    {        

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        bool _isbusy = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        bool _iscancelled = false;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string _sitecode = string.Empty;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BackgroundWorker _fileexec = new BackgroundWorker();

        public string siteCode
        {
            get
            {
                return _sitecode;
            }
            set
            {
                _sitecode = value;
            }
        }

        public bool canStart
        { 
            get 
            { 
                return (!_isbusy); 
            } 
        }

        public bool isBusy
        { 
            get
            { 
                return (_isbusy); 
            } 
        }

        #region Events
        /// <summary>
        /// Occurs when SQL file execution process was started
        /// </summary>
        public event EventHandler Started;

        /// <summary>
        /// Occurs when SQL file execution process was finished
        /// </summary>
        public event EventHandler Completed;

        /// <summary>
        /// Occurs when SQL file execution process was stopped
        /// </summary>
        public event EventHandler Stopped;

        /// <summary>
        /// Occurs when a SQL file execution process has been completed successfully
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="size"></param>
        public delegate void fileexecsuccess(string filename);

        /// <summary>
        /// Occurs when a SQL file execution process has been completed unsuccessfully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void filexecfailed(object sender, Exception e);

        /// <summary>
        /// Declaration of FileExecFailed event
        /// This will be raised when there is an issue or problem the SQL file creation process
        /// </summary>
        public event filexecfailed FileExecFailed;

        /// <summary>
        /// Raised event started when SQL file creation process was started
        /// </summary>
        /// <param name="e"></param>
        protected virtual void started(EventArgs e)
        {
            EventHandler handler = Started;

            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Raise event completed when the SQL file creations process is complete.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void completed(EventArgs e)
        {
            EventHandler handler = Completed;
            if (handler != null) handler(this, e);
        }

        /// <summary>
        /// Raise event stopped when the current process was halted
        /// </summary>
        /// <param name="e"></param>
        protected virtual void stopped(EventArgs e)
        {
            EventHandler handler = Stopped;
            if (handler != null) handler(this, e);
        }

        #endregion

        #region intance of synchronizer

        public autoSynchronizer(string connString = null, string endPoint = null)
        {
            
            this.APIEndpoint                = endPoint;
            this.connectionString           = connString;
           
            _fileexec.DoWork                += _fileexec_DoWork;
            _fileexec.ProgressChanged       += _fileexec_ProgressChanged;
            _fileexec.RunWorkerCompleted    += _fileexec_RunWorkerCompleted;

            _fileexec.WorkerReportsProgress      = true;
            _fileexec.WorkerSupportsCancellation = true;

        }

        #endregion

        #region Backgroundworker events

        void _fileexec_DoWork(object sender, DoWorkEventArgs e)
        {
            executefile();
        }

        void _fileexec_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == EventRaiser)
            {
                switch ((FileExeTransitions)e.UserState)
                {
                    case FileExeTransitions.FileExeAttempting:
                        break;
                    case FileExeTransitions.FileExeStarted:
                        break;
                    case FileExeTransitions.FileExeStopped:
                        break;
                    case FileExeTransitions.FileExeSucceeded:
                        break;
                    case FileExeTransitions.ProgressChanged:
                        break;
                }
            }

            if (e.ProgressPercentage == FailedRaiser)
            {
                if (FileExecFailed != null) FileExecFailed(this, (Exception)e.UserState);
            }
        }

        void _fileexec_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!_iscancelled)
            {
                completed(new EventArgs());
            }

            stopped(new EventArgs());

            _isbusy = false;
        }

        public void startAutoSycn()
        {
            if (!_isbusy)
            {
                _isbusy = true;
                _fileexec.RunWorkerAsync();
                started(new EventArgs());
            }
        }

        private void executefile()
        {

            bool _success = true;
            string _error = "";
            
            DataTable _table = new DataTable();
            postMethodSync request = new postMethodSync(this.connectionString, this.APIEndpoint);

            FireEventFromWorker(FileExeTransitions.FileExeAttempting);

            if ((_table = getTable("SELECT * FROM tmp_updates WHERE IFNULL(Grab,0) = 0")) != null)
            {
                FireEventFromWorker(FileExeTransitions.FileExeStarted);

                foreach (DataRow item in _table.Rows)
                {
                    string _refno = item["ReferenceNo"].ToString();

                    switch (item["Module"].ToString())
                    {
                        case "Fleet":
                            _success = request.sendFleet(_refno, siteCode, false);
                            break;
                        case "Authorized":
                            _success = request.sendFleetAuthorized(_refno, false);
                            break;
                        case "Registration":
                            _success = request.sendVehicleReg(_refno, false);
                            break;
                        case "Inspection":
                            _success = request.sendInspection(_refno, false);
                            break;
                        case "Quotation":
                            _success = request.sendQuotation(_refno, false);
                            break;
                        case "Workorder":
                            _success = request.sendWorkOrder(_refno, false);
                            break;
                        case "WOInvoice":

                            if (getQueryvalue("SELECT ReferenceNo FROM tmp_updates WHERE ReferenceNo = ( SELECT wo.WONo FROM workorder wo INNER JOIN workorderinvoices si ON si.WONo = wo.WONo WHERE si.InvoiceNo = '" + _refno + "' )") == null)
                                
                                executeQuery("INSERT INTO tmp_updates (Module,ReferenceNo,Grab) SELECT 'Workorder' Module, wo.WONo ReferenceNo, 0 Grab FROM workorder wo INNER JOIN workorderinvoices si ON si.WONo = wo.WONo WHERE si.InvoiceNo = '" + _refno + "';");

                            _success = request.sendWOInvoice(_refno, false);

                            break;
                        case "Personnel":
                            _success = request.sendPersonnel(_refno, false);
                            break;
                        case "Request":
                            _success = request.sendRequest(_refno, false);
                            break;
                        case "Utilization":
                            _success = request.sendUtilization(_refno, false);
                            break;
                        case "CustomerSS":
                            _success = request.sendCustomerSS(_refno, false);
                            break;
                        case "WOVehicle":
                            _success = request.sendWOVehicle(_refno, false);
                            break;
                        case "WorkReq":
                            _success = request.sendWorkRequest(_refno, siteCode, false);
                            break;
                        case "OdomHistory":
                            _success = request.sendOdometerHistory(_refno, siteCode, false);
                            break;
                        case "Fepp":
                            _success = request.sendToFepp(_refno, false);
                            break;
                    }

                    if (_success) executeQuery("UPDATE tmp_updates SET Grab = 1 WHERE UpdateID = " + item["UpdateID"].ToString());
                    
                }

            }

            if (!_success)
            {

                Exception _ex = new Exception(_error);
                _fileexec.ReportProgress(FailedRaiser, _ex);

            }
            else FireEventFromWorker(FileExeTransitions.FileExeSucceeded);
            
        }

        private void FireEventFromWorker(FileExeTransitions _event)
        {
            _fileexec.ReportProgress(EventRaiser, _event);
        }

        public void Stop()
        {
            _iscancelled = true;

            _fileexec.CancelAsync();

            _isbusy = false;
        }

        #endregion

        #region IDisposable support

        protected virtual void Dispose(bool disposing) { }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion

        #region Enumerations

        static int EventRaiser = 0;
        static int FailedRaiser = 1;

        private enum FileExeTransitions
        {
            FileExeAttempting,
            FileExeStopped,
            FileExeStarted,
            FileExeSucceeded,
            ProgressChanged
        }
        #endregion 

    }
}

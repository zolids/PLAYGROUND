using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

using tarsierSQL = TarsierEyes.MySQL;
using tarsierSQLString = TarsierEyes.Common.SQLStrings;
using System.Diagnostics;


/**
 *  AMSCore Generic Class storage
 *  @author Jcabrito <Oct. 27, 2015>
 *  @return mixed
 */
namespace AMSCore
{
    public class GenericStorage
    {

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _constring    = string.Empty;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _apiEndpoint  = string.Empty;        

        public string connectionString
        {
            get
            {
                return _constring;
            }
            set
            {
                _constring = value;
            }
        }

        public string APIEndpoint
        {
            get
            {
                return _apiEndpoint;
            }
            set
            {
                _apiEndpoint = value;
            }
        }

        public string httpMethod { get; set; }

        public DataTable getTable(string sql)
        {
            DataTable table = new DataTable();

            try
            {

                using (var con = new MySqlConnection(this.connectionString))
                using (var adapter = new MySqlDataAdapter(sql, con))
                using (new MySqlCommandBuilder(adapter))
                {
                    adapter.Fill(table);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return ((table.Rows.Count <= 0) ? null : table);
            
        }

        /**
         * temporary set to non blocking code.
         * always return boolean true
         */
        public bool queueFailedRequest(string module, string reference_id)
        {

            bool response = true;

            tarsierSQL.Que processSql = null;

            if (string.IsNullOrEmpty(module) || string.IsNullOrEmpty(reference_id))
                return response;

            string sql = "call usp_tmpUpdates('" + module + "','" + reference_id + "')";
            
            processSql = tarsierSQL.Que.Execute(this.connectionString.ToString(),
                    sql, tarsierSQL.Que.ExecutionEnum.ExecuteNonQuery);

            return response;

        }

        /**
         * temporary set to non blocking code.
         * always return boolean true
         */
        public bool executeQuery(string sql)
        {

            bool response = true;

            tarsierSQL.Que processSql = null;

            if (string.IsNullOrEmpty(sql))
                return response;

            processSql = tarsierSQL.Que.Execute(this.connectionString.ToString(),
                    sql, tarsierSQL.Que.ExecutionEnum.ExecuteNonQuery);

            return response;

        }

        public object getQueryvalue(string sql)
        {

            object processSql = null;

            if (string.IsNullOrEmpty(sql))
                return processSql;

            processSql = tarsierSQL.Que.GetValue(this.connectionString.ToString(), sql);

            return processSql;

        }

    }
}

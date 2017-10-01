using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Teste
{
    public class CDB
    {
        string orabd = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=IP(127.0.0.1))(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=SERVICE_NAME(Do arquivo tnsnames.ora))));" +
	    "User Id = user; Password=pwd;";
        private OracleConnection myConn;

        public OracleConnection returnMyConn()
        {
            this.myConn = new OracleConnection(orabd);

            return this.myConn;
        }

        public bool OpenDB()
        {
            this.myConn = returnMyConn();
            string erro = string.Empty;

            try
            {
                myConn.Open();
            }
            catch (Exception e)
            {
                erro = e.Message.ToString();
            }

            if (myConn.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CloseDB()
        {
            this.myConn = returnMyConn();

            if (myConn.State == ConnectionState.Open)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}

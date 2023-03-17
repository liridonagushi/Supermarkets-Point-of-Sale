using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Supermarkets
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            //server pc
             string host = "localhost";
             int port = 3306;
            string database = "pos_market";
            string username = "root";
            string password = "123456";
         

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Store
{
    class DBConnection
    {
        private SqlConnection connection;  
        public SqlConnection Connection { get => connection; set => connection = value; }
        
        public void Connect()
        {
            var connectionString = @"Data Source=sql5097.site4now.net;Initial Catalog=db_a74d9f_oop2database;Persist Security Info=True;User ID=db_a74d9f_oop2database_admin;Password=oop2database";
            connection = new SqlConnection(connectionString);
        }

        public void Open()
        {
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }
    }
}

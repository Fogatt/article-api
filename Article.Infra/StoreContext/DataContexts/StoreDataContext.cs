using System;
using System.Data.SqlClient;
using Article.Shared;

namespace Article.Infra.DataContext
{
    public class StoreDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }
        public StoreDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            if(Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
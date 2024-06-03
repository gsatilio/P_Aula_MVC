using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class InsuranceRepository
    {
        string _StrConn = "Data Source=127.0.0.1; Initial Catalog=dbCarros; User Id=SA; Password=SqlServer2019!;TrustServerCertificate=True";
        SqlConnection _conn;
        public InsuranceRepository()
        {
            _conn = new SqlConnection(_StrConn);
            _conn.Open();
        }
        public int Insert(Insurance insurance)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(Insurance.INSERT, _conn);
                cmd.Parameters.AddWithValue("@Description", insurance.Description);
                result = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
                result = 0;
            }
            finally
            {
                _conn.Close();
            }
            return result;
        }
    }
}

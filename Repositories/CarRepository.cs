using Microsoft.Data.SqlClient;
using Models;
using System.Text;

namespace Repositories
{
    public class CarRepository
    {
        string _StrConn = "Data Source=127.0.0.1; Initial Catalog=dbCarros; User Id=SA; Password=SqlServer2019!;TrustServerCertificate=True";
        SqlConnection _conn;
        public CarRepository()
        {
            _conn = new SqlConnection(_StrConn);
            _conn.Open();
        }
        public bool Insert(Car car)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand(Car.INSERT, _conn);
                cmd.Parameters.AddWithValue("@Name", car.Name);
                cmd.Parameters.AddWithValue("@Color", car.Color);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
            return result;
        }
        public bool Update(Car car)
        {
            bool result = false;
            try
            {
                SqlCommand cmd = new SqlCommand(Car.UPDATE, _conn);
                cmd.Parameters.AddWithValue("@Id", car.Id);
                cmd.Parameters.AddWithValue("@Name", car.Name);
                cmd.Parameters.AddWithValue("@Color", car.Color);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                string sql = " DELETE FROM TB_CAR WHERE Id = @Id ";
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
            return result;
        }
        public List<Car> GetAll()
        {
            List<Car> cars = new List<Car>();
            StringBuilder sb = new StringBuilder();

            try
            {
                SqlCommand cmd = new SqlCommand(Car.GETALL, _conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Car car = new Car();
                    car.Id = dr.GetInt32(0);
                    car.Name = dr.GetString(1);
                    car.Color = dr.GetString(2);
                    car.Year = dr.GetInt32(3);

                    cars.Add(car);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
            return cars;
        }

        public Car? Get(int id)
        {
            StringBuilder sb = new StringBuilder();
            Car? car = null;

            try
            {
                SqlCommand cmd = new SqlCommand(Car.GET, _conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    car = new Car();
                    car.Id = dr.GetInt32(0);
                    car.Name = dr.GetString(1);
                    car.Color = dr.GetString(2);
                    car.Year = dr.GetInt32(3);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
            return car;
        }
    }
}

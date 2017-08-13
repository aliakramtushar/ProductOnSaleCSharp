using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Framework
{
    public class DataAccess
    {
        string connectionString = "Data Source=DESKTOP-7G5IUPG;Initial Catalog=POS_System;Persist Security Info=True;User ID=sa;Password=12345";

        public int ExecuteLogin(SqlCommand command)
        {
            string temp;
            SqlDataAdapter da = new SqlDataAdapter(command);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                command.Connection = connection;
                connection.Open();
                temp = command.ExecuteScalar().ToString();
                connection.Close();
                return Convert.ToInt32(temp);
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public string Execute(SqlCommand command)
        {
            
            string temp;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                command.Connection = connection;
                connection.Open();
                temp = command.ExecuteScalar().ToString();
                connection.Close();
                return temp;
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                connection.Close();
            }
            
        }
        
        public DataTable ExecuteInsert(SqlCommand command)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                command.Connection = connection;
                connection.Open();
                da.Fill(dt);
                connection.Close();
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                connection.Close();
            }

        }   

        public DataTable Query(SqlCommand query)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                query.Connection = connection;
                SqlDataAdapter da = new SqlDataAdapter(query);
                connection.Open();
                da.Fill(dt);
                connection.Close();
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void InventoryExecute(SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            
        }

        public int QuantityQuery(SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int temp;
            try
            {
                command.Connection = connection;
                connection.Open();
                temp = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return temp;
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}

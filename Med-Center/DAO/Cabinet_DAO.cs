using DAO_Interface;
using MedCenter;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class Cabinet_DAO : Cabinet_DAO_Interface
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MedCenterData"].ConnectionString;
        public void Add(Cabinet cabinet)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddCabinet";
                cmd.Parameters.AddWithValue(@"Name", cabinet.GiveTakeNumber);
                cmd.Parameters.AddWithValue(@"SecName", cabinet.GiveTakeSpeciality);
                var id = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "ID",
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(id);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public IEnumerable<Cabinet> GetAll()
        {
            List<Cabinet> cabinets = new List<Cabinet>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetListCabinet";
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ID = (int)reader["ID"];
                    int Number = (int)reader["Number"];
                    string Speciality = (string)reader["Speciality"];

                    cabinets.Add(new Cabinet(ID, Number, Speciality));
                }

            }
            return cabinets;
        }

        public void DeleteCabinet(int number)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteCabinet";
                cmd.Parameters.AddWithValue(@"ID", number);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public Cabinet GetInfoCabinet(int number)
        {
            Cabinet cabinet = new Cabinet();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetINFO_Cabinet";
                cmd.Parameters.AddWithValue(@"Number", number);
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ID = (int)reader["ID"];
                    int Number = (int)reader["Number"];
                    string Speciality = (string)reader["Speciality"];

                    cabinet = (new Cabinet(ID, Number, Speciality));
                }

            }
            return cabinet;
        }
        
    }
}

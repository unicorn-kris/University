using DAO_Interface;
using MedCenter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class Patient_DAO : Patient_DAO_Interface
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MedCenterData"].ConnectionString;
        public void Add(Patient patient)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddPatient";
                cmd.Parameters.AddWithValue(@"Name", patient.Name);
                cmd.Parameters.AddWithValue(@"Surname", patient.Surname);
                cmd.Parameters.AddWithValue(@"Patronymic", patient.Patronymic);
                cmd.Parameters.AddWithValue(@"Pasport", patient.Pasport);
                cmd.Parameters.AddWithValue(@"PhoneNumber", patient.PhoneNumber);
                cmd.Parameters.AddWithValue(@"Birthday", patient.Birthday);

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
        public IEnumerable<Patient> GetAll()
        {
            List<Patient> patients = new List<Patient>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetListPatient";
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ID = (int)reader["ID"];
                    string Name = (string)reader["Name"];
                    string SurName = (string)reader["SurName"];
                    string Patronymic = (string)reader["Patronymic"];
                    string Pasport = (string)reader["Pasport"];
                    string PhoneNumber = (string)reader["PhoneNumber"];
                    DateTime Birthday = (DateTime)reader["Birthday"];

                    patients.Add(new Patient(ID, Name, SurName, Patronymic, Pasport, PhoneNumber, Birthday));
                }
            }
            return patients;
        }

        public void DeletePatient(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletePatient";
                cmd.Parameters.AddWithValue(@"ID", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

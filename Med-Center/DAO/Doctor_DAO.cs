using DAO_Interface;
using MedCenter;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Configuration;

namespace DAO
{
    public class Doctor_DAO : Doctor_DAO_Interface
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MedCenterData"].ConnectionString;
        public void Add(Doctor doctor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddDoctor";
                cmd.Parameters.AddWithValue(@"Name", doctor.Name);
                cmd.Parameters.AddWithValue(@"Surname", doctor.Surname);
                cmd.Parameters.AddWithValue(@"Patronymic", doctor.Patronymic);
                cmd.Parameters.AddWithValue(@"Pasport", doctor.Pasport);
                cmd.Parameters.AddWithValue(@"PhoneNumber", doctor.PhoneNumber);
                cmd.Parameters.AddWithValue(@"Birthday", doctor.Birthday);
                cmd.Parameters.AddWithValue(@"Speciality", doctor.Speciality);
                
                string workHours = "";
                workHours += doctor.WorkHours;
                cmd.Parameters.AddWithValue(@"WorkDays", doctor.WorkDays);
                cmd.Parameters.AddWithValue(@"WorkHours", workHours);

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
        public IEnumerable<Doctor> GetAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetListDoctor";
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
                    string Speciality = (string)reader["Speciality"];
                    string WorkDays = (string)reader["WorkDays"];
                    string WorkHours = (string)reader["WorkHours"];

                    
                    int workhours = (int)WorkHours[0] - '0';

                    doctors.Add(new Doctor(ID, Name, SurName, Patronymic, Pasport, PhoneNumber, Birthday, Speciality, WorkDays, workhours));
                }

            }
            return doctors;
        }

        public void DeleteDoctor(int id)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDoctor";
                cmd.Parameters.AddWithValue(@"ID", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}

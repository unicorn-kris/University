using DAO_Interface;
using MedCenter;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;

namespace DAO
{
    public class Doctor_DAO : Doctor_DAO_Interface
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=MedCenter;Trusted_Connection=True";
        public void Add(Doctor doctor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddDoctor";
                cmd.Parameters.AddWithValue(@"Name", doctor.GiveTakeName);
                cmd.Parameters.AddWithValue(@"Surname", doctor.GiveTakeSurName);
                cmd.Parameters.AddWithValue(@"Patronymic", doctor.GiveTakePatronymic);
                cmd.Parameters.AddWithValue(@"Pasport", doctor.GiveTakePasport);
                cmd.Parameters.AddWithValue(@"PhoneNumber", doctor.GiveTakePhoneNumber);
                cmd.Parameters.AddWithValue(@"Birthday", doctor.GiveTakeBirthday);
                cmd.Parameters.AddWithValue(@"Speciality", doctor.GiveTakeSpeciality);
                string workDays = "";
                foreach (int x in doctor.GiveWorkDays)
                {
                    workDays += x;
                }
                string workHours = "";
                workHours += doctor.GiveWorkHours;
                cmd.Parameters.AddWithValue(@"WorkDays", workDays);
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

                    int[] workdays = new int[7];
                    for (int i = 0; i < 7; ++i)
                    {
                        workdays[i] = WorkDays[i];
                    }
                    int workhours = WorkHours[0];

                    doctors.Add(new Doctor(ID, Name, SurName, Patronymic, Pasport, PhoneNumber, Birthday, Speciality,workdays, workhours));
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

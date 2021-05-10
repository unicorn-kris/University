using DAO_Interface;
using MedCenter;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
   public class DataAppointment_DAO : DataAppointment_DAO_Interface
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MedCenterData"].ConnectionString;
        public void Add(DataAppointment dataAppointment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddAppointment";
                cmd.Parameters.AddWithValue(@"DoctorID", dataAppointment.DoctorID);
                cmd.Parameters.AddWithValue(@"CabinetNumber", dataAppointment.CabinetNumber);
                cmd.Parameters.AddWithValue(@"Day", dataAppointment.Day);
                cmd.Parameters.AddWithValue(@"Hour", dataAppointment.Hour);
                cmd.Parameters.AddWithValue(@"Minute", dataAppointment.Minute);
                cmd.Parameters.AddWithValue(@"PatientID", dataAppointment.PatientID);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<DataAppointment> GetAll()
        {
            List<DataAppointment> dataAppointments = new List<DataAppointment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetListAppointment";
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    int DoctorID = (int)reader["DoctorID"];
                    int CabinetNumber = (int)reader["CabinetNumber"];
                    int Day = (int)reader["Day"];
                    int Hour = (int)reader["Hour"];
                    int Minute = (int)reader["Minute"];
                    int PatientID = (int)reader["PatientID"];

                    dataAppointments.Add(new DataAppointment(DoctorID, CabinetNumber, Day, Hour, Minute, PatientID));
                }

            }
            return dataAppointments;
        }
        public void DeleteAppointment(int docID, int day, int hour, int minute)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteAppointment";
                cmd.Parameters.AddWithValue(@"DoctorID", docID);
                cmd.Parameters.AddWithValue(@"Day", day);
                cmd.Parameters.AddWithValue(@"Hour", hour);
                cmd.Parameters.AddWithValue(@"Minute", minute);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ChangePatientInAppointment(int docID, int day, int hour, int minute, int patID)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChangePatientInAppointment";
                cmd.Parameters.AddWithValue(@"PatientID", patID);
                cmd.Parameters.AddWithValue(@"DoctorID", docID);
                cmd.Parameters.AddWithValue(@"Day", day);
                cmd.Parameters.AddWithValue(@"Hour", hour);
                cmd.Parameters.AddWithValue(@"Minute", minute);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeletePatientInAppointment(int docID, int day, int hour, int minute, int patID)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletePatientAppointment";
                cmd.Parameters.AddWithValue(@"PatientID", patID);
                cmd.Parameters.AddWithValue(@"DoctorID", docID);
                cmd.Parameters.AddWithValue(@"Day", day);
                cmd.Parameters.AddWithValue(@"Hour", hour);
                cmd.Parameters.AddWithValue(@"Minute", minute);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ChangeCabinetInAppointment(int docID, int day, int cabNUM)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChangeCabinetInAppointment";
                cmd.Parameters.AddWithValue(@"CabinetNumber", cabNUM);
                cmd.Parameters.AddWithValue(@"DoctorID", docID);
                cmd.Parameters.AddWithValue(@"Day", day);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

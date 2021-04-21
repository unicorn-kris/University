using DAO_Interface;
using MedCenter;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
   public class DataAppointment_DAO : DataAppointment_DAO_Interface
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=MedCenter;Trusted_Connection=True";
        public void Add(DataAppointment dataAppointment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddCabinet";
                cmd.Parameters.AddWithValue(@"DoctorID", dataAppointment.GiveTakeDoctorID);
                cmd.Parameters.AddWithValue(@"CabinetNumber", dataAppointment.GiveTakeCabinetNumber);
                cmd.Parameters.AddWithValue(@"Day", dataAppointment.GiveTakeDay);
                cmd.Parameters.AddWithValue(@"Hour", dataAppointment.GiveTakeHour);
                cmd.Parameters.AddWithValue(@"Minute", dataAppointment.GiveTakeMinute);
                cmd.Parameters.AddWithValue(@"PatientID", dataAppointment.GiveTakePatientID);

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


        public List<DataAppointment> GetInfoAppointment(int doctorID)
        {
            List<DataAppointment> dataAppointments = new List<DataAppointment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetINFO_Appointment";
                cmd.Parameters.AddWithValue(@"DoctorID", doctorID);
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
    }
}

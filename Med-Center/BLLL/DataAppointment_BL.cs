using BL_Interface;
using DAO;
using MedCenter;
using System.Collections.Generic;

namespace BL
{
    public class DataAppointment_BL : DataAppointment_BL_Interface
    {
        private DataAppointment_DAO _dataAppointment = new DataAppointment_DAO();
        public void Add(DataAppointment dataAppointment)
        {
            _dataAppointment.Add(dataAppointment);
        }
        public IEnumerable<DataAppointment> GetAll()
        {
            return _dataAppointment.GetAll();
        }
        public List<DataAppointment> GetInfoAppointment(int Doctorid)
        {
            List<DataAppointment> search = new List<DataAppointment>();
            foreach (DataAppointment data in _dataAppointment.GetAll())
                if (data.DoctorID == Doctorid)
                    search.Add(data);
            return search;
        }
        //свободен ли кабинет
        public bool FreeCabinet(int number, int day)
        {
            bool free = true;
            foreach (DataAppointment data in _dataAppointment.GetAll())
                if (data.CabinetNumber == number && data.Day == day)
                    free = false;
            return free;
        }
        //есть ли кабинет у доктора (0-нет)
        public bool FreeDoctor(int id, int day)
        {
            bool free = true;
            foreach (DataAppointment data in _dataAppointment.GetAll())
                if (data.DoctorID == id && data.CabinetNumber != 0 && data.Day == day)
                    free = false;

            return free;
        }
        //есть ли доктор в расписании
        public bool HaveDoctorInAppointments(int id)
        {
            bool have = false;
            foreach (DataAppointment data in _dataAppointment.GetAll())
                if (data.DoctorID == id)
                    have = true;

            return have;
        }
        public bool HavePatientInAppointments(int docID, int day, int hour, int minute, int patID)
        {
            bool have = false;
            foreach (DataAppointment data in _dataAppointment.GetAll())
                if (data.DoctorID == docID && data.Day == day && data.Hour == hour && data.Minute == minute && data.PatientID == patID)
                    have = true;

            return have;
        }
        //нет ли в записи пациента
        public bool CanAddPatientInAppointment(int docID, int patID, int day, int hour, int minute)
        {
            bool have = false;
            foreach (DataAppointment data in _dataAppointment.GetAll())
                if (data.DoctorID == docID && data.Day == day && data.Hour == hour && data.Minute == minute && data.PatientID == 0)
                    have = true;

            return have;
        }
        public void ChangePatientInAppointment(int docID, int patID, int day, int hour, int minute)
        {
            _dataAppointment.ChangePatientInAppointment(docID, day, hour, minute, patID);
        }
        public void ChangeCabinetInAppointment(int docID, int day, int cabNUM)
        {
            _dataAppointment.ChangeCabinetInAppointment(docID, day, cabNUM);
        }
        public void DeletePatientInAppointment(int docID, int patID, int day, int hour, int minute)
        {
            _dataAppointment.DeletePatientInAppointment(docID, day, hour, minute, patID);
        }
        public void DeleteAppointment(int docID, int day, int hour, int minute)
        {
            _dataAppointment.DeleteAppointment(docID, day, hour, minute);
        }
        public IEnumerable<DataAppointment> GetByDoctor(int id)
        {
            List<DataAppointment> search = new List<DataAppointment>();
            foreach (DataAppointment appointment in _dataAppointment.GetAll())
                if (appointment.DoctorID == id)
                    search.Add(appointment);
            return search;
        }
        public IEnumerable<DataAppointment> GetByPatient(int id)
        {
            List<DataAppointment> search = new List<DataAppointment>();
            foreach (DataAppointment appointment in _dataAppointment.GetAll())
                if (appointment.PatientID == id)
                {
                    bool add = true;
                    foreach (DataAppointment data in search)
                        if (data.DoctorID == appointment.DoctorID && data.Day == appointment.Day &&
                            data.Hour == appointment.Hour && data.Minute == appointment.Minute)
                            add = false;
                    if (add)
                            search.Add(appointment);
                }
            return search;
        }
    }
}

using MedCenter;
using System.Collections.Generic;

namespace BL_Interface
{
    public interface DataAppointment_BL_Interface
    {
        void Add(DataAppointment dataAppointment);
        IEnumerable<DataAppointment> GetAll();
        List<DataAppointment> GetInfoAppointment(int Doctorid);
        bool FreeCabinet(int number, int day);
        //есть ли кабинет у доктора (0-нет)
        bool FreeDoctor(int id, int day);
        //есть ли доктор в расписании
        bool HaveDoctorInAppointments(int id);
        //нет ли в записи пациента
        bool CanAddPatientInAppointment(int docID, int patID, int day, int hour, int minute);
        void ChangePatientInAppointment(int docID, int patID, int day, int hour, int minute);
        void ChangeCabinetInAppointment(int docID, int day, int cabNUM);
        void DeletePatientInAppointment(int docID, int patID, int day, int hour, int minute);
        void DeleteAppointment(int docID, int day, int hour, int minute);
        IEnumerable<DataAppointment> GetByDoctor(int id);
        IEnumerable<DataAppointment> GetByPatient(int id);
    }
}

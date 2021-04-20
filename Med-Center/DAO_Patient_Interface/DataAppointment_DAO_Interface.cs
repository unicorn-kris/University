using MedCenter;
using System.Collections.Generic;

namespace DAO_Interface
{
    public interface DataAppointment_DAO_Interface
    {
        void Add(DataAppointment dataAppointment);
        IEnumerable<DataAppointment> GetAll();
        Appointment GetInfoAppointment(int Doctorid, int day, int hour, int minute);
        void UpdateAppointment(int Doctorid, int CabinetNumber, int day, int hour, int minute, int PatientId);
        void RemoveAppointment(int Doctorid, int CabinetNumber, int day, int hour, int minute, int PatientId);
    }
}

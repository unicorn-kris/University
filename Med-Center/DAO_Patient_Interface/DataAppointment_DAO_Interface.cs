using MedCenter;
using System.Collections.Generic;

namespace DAO_Interface
{
    public interface DataAppointment_DAO_Interface
    {
        void Add(DataAppointment dataAppointment);
        IEnumerable<DataAppointment> GetAll();
        //List<DataAppointment> GetInfoAppointment(int Doctorid);
        void DeleteAppointment(int docID, int day, int hour, int minute);
        void ChangePatientInAppointment(int docID, int day, int hour, int minute, int patID);
        void DeletePatientInAppointment(int docID, int day, int hour, int minute, int patID);
        void ChangeCabinetInAppointment(int docID, int day, int cabNUM);
    }
}

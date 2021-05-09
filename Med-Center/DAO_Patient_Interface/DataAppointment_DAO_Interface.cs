using MedCenter;
using System.Collections.Generic;

namespace DAO_Interface
{
    public interface DataAppointment_DAO_Interface
    {
        void Add(DataAppointment dataAppointment);
        IEnumerable<DataAppointment> GetAll();
        //List<DataAppointment> GetInfoAppointment(int Doctorid);
        
    }
}

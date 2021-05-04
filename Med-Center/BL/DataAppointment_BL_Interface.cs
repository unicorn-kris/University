using MedCenter;
using System.Collections.Generic;

namespace BL_Interface
{
    public interface DataAppointment_BL_Interface
    {
        void Add(DataAppointment dataAppointment);
        IEnumerable<DataAppointment> GetAll();
        List<DataAppointment> GetInfoAppointment(int Doctorid);
    }
}

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
    }
}

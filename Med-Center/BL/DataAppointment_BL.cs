using System;
using System.Collections.Generic;
using System.Text;
using MedCenter;
using DAO;
using BL_Interface;

namespace BL
{
    class DataAppointment_BL: DataAppointment_BL_Interface
    {
        private DataAppointment_DAO _dataAppointment;
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
            return _dataAppointment.GetInfoAppointment(Doctorid);
        }
    }
}

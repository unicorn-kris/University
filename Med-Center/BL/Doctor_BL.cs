using System;
using System.Collections.Generic;
using System.Text;
using MedCenter;
using DAO;
using BL_Interface;

namespace BL
{
    class Doctor_BL: Doctor_BL_Interface
    {
        private Doctor_DAO _doctor;
        public void Add(Doctor doctor)
        {
            _doctor.Add(doctor);
        }
       public IEnumerable<Doctor> GetAll()
        {
            return _doctor.GetAll();
        }
        public void DeleteDoctor(int id)
        {
            _doctor.DeleteDoctor(id);
        }
    }
}

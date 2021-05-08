using System;
using System.Collections.Generic;
using System.Text;
using MedCenter;
using DAO;
using BL_Interface;

namespace BL
{
   public class Patient_BL : Patient_BL_Interface
    {
        private Patient_DAO _patient;
        public void Add(Patient Patient)
        {
            _patient.Add(Patient);
        }
        public IEnumerable<Patient> GetAll()
        {
            return _patient.GetAll();
        }
        public void DeletePatient(int id)
        {
            _patient.DeletePatient(id);
        }
    } 
}
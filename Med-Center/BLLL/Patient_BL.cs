using BL_Interface;
using DAO;
using MedCenter;
using System.Collections.Generic;

namespace BL
{
    public class Patient_BL : Patient_BL_Interface
    {
        private Patient_DAO _patient = new Patient_DAO();
        public void Add(Patient Patient)
        {

            bool have = false;
            foreach (Patient patient in _patient.GetAll())
                if (patient.Pasport == Patient.Pasport)
                    have = true;
            if (!have)
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
        public IEnumerable<Patient> GetBySurname(string surname)
        {
            List<Patient> search = new List<Patient>();
            foreach (Patient patient in _patient.GetAll())
                if (patient.Surname == surname)
                    search.Add(patient);
            return search;
        }
        public IEnumerable<Patient> GetByID(int id)
        {
            List<Patient> search = new List<Patient>();
            foreach (Patient patient in _patient.GetAll())
                if (patient.ID == id)
                    search.Add(patient);
            return search;
        }
        public bool HavePatient(int id)
        {
            bool search = false;
            foreach (Patient patient in _patient.GetAll())
                if (patient.ID == id)
                    search = true;
            return search;
        }
        public Patient ByID(int id)
        {
           Patient search = new Patient();
            foreach (Patient patient in _patient.GetAll())
                if (patient.ID == id)
                    search = patient;
            return search;
        }
    }
}
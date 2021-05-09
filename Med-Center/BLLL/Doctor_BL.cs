using System;
using System.Collections.Generic;
using System.Text;
using MedCenter;
using DAO;
using BL_Interface;

namespace BL
{
   public class Doctor_BL: Doctor_BL_Interface
    {
        private Doctor_DAO _doctor = new Doctor_DAO();
        public void Add(Doctor doctor)
        {
            bool have = false;
            foreach (Doctor doctors in _doctor.GetAll())
                if (doctors.Pasport == doctor.Pasport)
                    have = true;
            if (!have)
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
        public IEnumerable<Doctor> GetBySurname(string surname)
        {
            List<Doctor> search = new List<Doctor>();
            foreach (Doctor doctors in _doctor.GetAll())
                if (doctors.Surname == surname)
                    search.Add(doctors);
            return search;
        }
        public IEnumerable<Doctor> GetByID(int id)
        {
            List<Doctor> search = new List<Doctor>();
            foreach (Doctor doctors in _doctor.GetAll())
                if (doctors.ID == id)
                    search.Add(doctors);
            return search;
        }
    }
}

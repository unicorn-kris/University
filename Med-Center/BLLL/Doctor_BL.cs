using BL_Interface;
using DAO;
using MedCenter;
using System.Collections.Generic;

namespace BL
{
    public class Doctor_BL : Doctor_BL_Interface
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
        public bool HaveDoctor(int id)
        {
            bool search = false;
            foreach (Doctor doctors in _doctor.GetAll())
                if (doctors.ID == id)
                    search = true;
            return search;
        }
        public bool HaveDay(int id, int day)
        {
            bool search = false;
            foreach (Doctor doctors in _doctor.GetAll())
                if (doctors.ID == id && doctors.WorkDays[day] == '1')
                    search = true;
            return search;
        }
        public bool HaveHour(int id, int hour)
        {
            bool search = false;
            foreach (Doctor doctors in _doctor.GetAll())
                if (doctors.ID == id)
                {
                    if (doctors.WorkHours == 1 && hour < 13 && hour > 7)
                        search = true;
                    else if (doctors.WorkHours == 2 && hour < 19 && hour > 13)
                        search = true;
                }
            return search;
        }
        public Doctor ByID(int id)
        {
            Doctor search = new Doctor();
            foreach (Doctor doctors in _doctor.GetAll())
                if (doctors.ID == id)
                    search = doctors;
            return search;
        }
    }
}

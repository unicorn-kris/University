using MedCenter;
using System;
using System.Collections.Generic;

namespace BL_Interface
{
    public interface Patient_BL_Interface
    {
        void Add(Patient patient);
        IEnumerable<Patient> GetAll();
        IEnumerable<Patient> GetBySurname(string surname);
        void DeletePatient(int id);

    }
}

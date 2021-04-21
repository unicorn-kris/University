using MedCenter;
using System;
using System.Collections.Generic;

namespace DAO_Interface
{
    public interface Patient_DAO_Interface
    {
        void Add(Patient patient);
        IEnumerable<Patient> GetAll();
        void DeletePatient(int id);

    }
}

using MedCenter;
using System;
using System.Collections.Generic;

namespace BL_Interface
{
    public interface Patient_BL_Interface
    {
        void Add(Patient patient);
        IEnumerable<Patient> GetAll();
        void DeletePatient(int id);

    }
}

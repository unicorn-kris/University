using MedCenter;
using System;
using System.Collections.Generic;

namespace DAO_Interface
{
    public interface Patient_DAO_Interface
    {
        void Add(Patient patient);
        IEnumerable<Patient> GetAll();
        Patient GetInfoPatient(int id);
        void UpdatePatient(int id, string name, string surname, string patronymic, string pasport, string phoneNumber,
                       DateTime birthday);
        void RemovePatient(int id);

    }
}

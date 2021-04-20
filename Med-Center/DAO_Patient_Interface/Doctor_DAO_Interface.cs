using MedCenter;
using System;
using System.Collections.Generic;

namespace DAO_Interface
{
    public interface Doctor_DAO_Interface
    {
        void Add(Doctor doctor);
        IEnumerable<Doctor> GetAll();
        Doctor GetInfoDoctor(int id);
        void UpdateDoctor(int id, string name, string surname, string patronymic, string pasport, string phoneNumber,
                       DateTime birthday, string speciality, int[] workDays, int workHours);
        void RemoveDoctor(int id);

    }
}

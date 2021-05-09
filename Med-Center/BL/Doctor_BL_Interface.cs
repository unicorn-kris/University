using MedCenter;
using System;
using System.Collections.Generic;

namespace BL_Interface
{
    public interface Doctor_BL_Interface
    {
        void Add(Doctor doctor);
        IEnumerable<Doctor> GetAll();
         IEnumerable<Doctor> GetBySurname(string surname);
        void DeleteDoctor(int id);

    }
}
using MedCenter;
using System;
using System.Collections.Generic;

namespace DAO_Interface
{
    public interface Doctor_DAO_Interface
    {
        void Add(Doctor doctor);
        IEnumerable<Doctor> GetAll();
        void DeleteDoctor(int id);

    }
}

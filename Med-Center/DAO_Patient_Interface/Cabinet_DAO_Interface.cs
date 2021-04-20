using MedCenter;
using System.Collections.Generic;

namespace DAO_Interface
{
    public interface Cabinet_DAO_Interface
    {
        void Add(Cabinet cabinet);
        IEnumerable<Cabinet> GetAll();
        Cabinet GetInfoCabinet(int number);
        void UpdateCabinet(int id, int number, string speciality);
        void RemoveCabinet(int id);

    }
}

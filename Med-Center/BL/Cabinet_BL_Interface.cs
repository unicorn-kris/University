using MedCenter;
using System.Collections.Generic;

namespace BL_Interface
{
    public interface Cabinet_BL_Interface
    {
        void Add(Cabinet cabinet);
        IEnumerable<Cabinet> GetAll();
        IEnumerable<Cabinet> GetInfoCabinet(int number);
        void DeleteCabinet(int id);
    }
}

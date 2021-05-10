using BL_Interface;
using DAO;
using MedCenter;
using System.Collections.Generic;

namespace BL
{
    public class Cabinet_BL : Cabinet_BL_Interface
    {
        private Cabinet_DAO _cabinet = new Cabinet_DAO();
        public void Add(Cabinet cabinet)
        {
            bool have = false;
            foreach (Cabinet cabinet1 in _cabinet.GetAll())
                if (cabinet1.Number == cabinet.Number)
                    have = true;
            if (!have)
                _cabinet.Add(cabinet);
        }
        public IEnumerable<Cabinet> GetAll()
        {
            return _cabinet.GetAll();
        }
        public IEnumerable<Cabinet> GetInfoCabinet(int number)
        {
            List<Cabinet> search = new List<Cabinet>();
            foreach (Cabinet cabinet in _cabinet.GetAll())
                if (cabinet.Number == number)
                    search.Add(cabinet);
            return search;
        }

        public void DeleteCabinet(int number)
        {
            _cabinet.DeleteCabinet(number);
        }

        public bool HaveCabinet(int number)
        {
            bool search = false;
            foreach (Cabinet cabinet in _cabinet.GetAll())
                if (cabinet.Number == number)
                    search = true;
            return search;
        }
    }
}
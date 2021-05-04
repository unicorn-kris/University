using System;
using System.Collections.Generic;
using System.Text;
using BL_Interface;
using MedCenter;
using DAO;

namespace BL
{
    class Cabinet_BL : Cabinet_BL_Interface
    {
        private Cabinet_DAO _cabinet;
        public void Add(Cabinet cabinet)
        {
            _cabinet.Add(cabinet);
        }
        public IEnumerable<Cabinet> GetAll()
        {
            return _cabinet.GetAll();
        }
        public Cabinet GetInfoCabinet(int number)
        {
            return _cabinet.GetInfoCabinet(number);
        }
        public void DeleteCabinet(int id)
        {
            _cabinet.DeleteCabinet(id);
        }
    }
}
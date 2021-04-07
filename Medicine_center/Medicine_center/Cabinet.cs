using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_center
{
    class Cabinet
    {
        private int _Number;
        private int _CabinetID;
        private string _Speciality;
        public Cabinet(int id, int number, string speciality)
        {
            _Number = number;
            _Speciality = speciality;
            _CabinetID = id;
        }
        public new int GiveTakeNumber
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
            }
        }
        public new string GiveTakeSpeciality
        {
            get
            {
                return _Speciality;
            }
            set
            {
                _Speciality = value;
            }
        }
        public new int GiveTakeID
        {
            get
            {
                return _CabinetID;
            }
            set
            {
                _CabinetID = value;
            }
        }
    }
}

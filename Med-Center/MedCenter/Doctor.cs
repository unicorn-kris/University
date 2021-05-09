using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCenter
{
    public class Doctor : Person
    {
        private string _Speciality;
        private int[] _WorkDays;
        private int _WorkHours;
        public Doctor( string name, string surname, string patronymic, string pasport, string phoneNumber,
                       DateTime birthday, string speciality, int[] workDays, int workHours)
        {
           
            _Speciality = speciality;
            _WorkDays = workDays;
            _WorkHours = workHours;

        }
        public Doctor(int id, string name, string surname, string patronymic, string pasport, string phoneNumber,
                      DateTime birthday, string speciality, int[] workDays, int workHours)
        {
            _ID = id;
            _Name = name;
            _SurName = surname;
            _Patronymic = patronymic;
            _Pasport = pasport;
            _PhoneNumber = phoneNumber;
            _Birthday = birthday;
            _Speciality = speciality;
            _WorkDays = workDays;
            _WorkHours = workHours;

        }
        public new string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public new string Surname
        {
            get
            {
                return _SurName;
            }
            set
            {
                _SurName = value;
            }
        }
        public new string Patronymic
        {
            get
            {
                return _Patronymic;
            }
            set
            {
                _Patronymic = value;
            }
        }
        public new string PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }
        public new string Pasport
        {
            get
            {
                return _Pasport;
            }
            set
            {
                _Pasport = value;
            }
        }
        public string Speciality
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
        public new DateTime Birthday
        {
            get
            {
                return _Birthday;
            }
            set
            {
                _Birthday = value;
            }
        }
        public  int ID
        {
            get
            {
                return _ID;
            }
            set => _ID = value;
        }
        public int[] WorkDays
        {
            get
            {
                return _WorkDays;
            }
        }
        public int WorkHours
        {
            get
            {
                return _WorkHours;
            }
        }
    }
}
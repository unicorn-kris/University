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
            get => _Name;
            set => _Name = value;
        }
        public new string Surname
        {
            get => _SurName;
            set => _SurName = value;
        }
        public new string Patronymic
        {
            get => _Patronymic;
            set => _Patronymic = value;
        }
        public new string PhoneNumber
        {
            get => _PhoneNumber;
            set => _PhoneNumber = value;
        }
        public new string Pasport
        {
            get => _Pasport;
            set => _Pasport = value;
        }
        public string Speciality
        {
            get => _Speciality;
            set => _Speciality = value;
        }
        public new DateTime Birthday
        {
            get => _Birthday;
            set => _Birthday = value;
        }
        public new int ID
        {
            get => _ID;
            set => _ID = value;
        }
        public int[] WorkDays => _WorkDays;
        public int WorkHours => _WorkHours;
    }
}
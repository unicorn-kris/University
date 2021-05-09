using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCenter
{
    public class Patient : Person
    {

        public Patient(int id, string name, string surname, string patronymic, string pasport, string phoneNumber,
                       DateTime birthday)
        {
            _Name = name;
            _SurName = surname;
            _Patronymic = patronymic;
            _Pasport = pasport;
            _PhoneNumber = phoneNumber;
            _Birthday = birthday;
            _ID = id;
        }
        public Patient( string name, string surname, string patronymic, string pasport, string phoneNumber,
                       DateTime birthday)
        {
            _Name = name;
            _SurName = surname;
            _Patronymic = patronymic;
            _Pasport = pasport;
            _PhoneNumber = phoneNumber;
            _Birthday = birthday;
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
        public int ID
        {
            get
            {
                return _ID;
            }
            set => _ID = value;
        }
        
    }
}

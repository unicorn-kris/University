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

    }
}

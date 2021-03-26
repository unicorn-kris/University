using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_center
{//придумать айди! чтобы в дальнейшем добавлять человека если его нет!
    class Patient: Person
    {
        private string _PhoneNumber;
        private DateTime _Birthday;

        public Patient(string name, string surname, string patronymic, string phoneNumber,
                       DateTime birthday)
        {
            Name = name;
            SurName = surname;
            Patronymic = patronymic;
            _PhoneNumber = phoneNumber;
            _Birthday = birthday;
            ID = 0;
        }
        public new string GiveTakeName { 
            get {
                return Name;
            }
            set {
                Name = value;
            }
        }
        public new string GiveTakeSurName {
            get
            {
                return SurName;
            }
            set
            {
                SurName = value;
            }
        }
        public new string GiveTakePatronymic {
            get
            {
                return Patronymic;
            }
            set
            {
                Patronymic = value;
            }
        }
        public new int GiveTakeID {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public string GiveTakePhoneNumber
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
        public DateTime GiveTakeBirthday
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
    }
}

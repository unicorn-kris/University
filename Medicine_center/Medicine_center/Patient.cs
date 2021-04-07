using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_center
{//придумать айди! чтобы в дальнейшем добавлять человека если его нет!
    class Patient: Person
    {
       
        public Patient(string name, string surname, string patronymic, string pasport, string phoneNumber,
                       DateTime birthday)
        {
            Name = name;
            SurName = surname;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Pasport = pasport;
            Birthday = birthday;
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
        public new string GiveTakePhoneNumber
        {
            get
            {
                return PhoneNumber;
            }
            set
            {
                PhoneNumber = value;
            }
        }
        public new string GiveTakePasport
        {
            get
            {
                return Pasport;
            }
            set
            {
                Pasport = value;
            }
        }
        public new DateTime GiveTakeBirthday
        {
            get
            {
                return Birthday;
            }
            set
            {
                Birthday = value;
            }
        }
        public new int GiveTakeID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
    }
}

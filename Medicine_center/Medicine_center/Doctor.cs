using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_center
{//придумать айди! чтобы в дальнейшем добавлять врача если его нет!
    class Doctor: Person
    {
        private string _Speciality;
        private int[] _WorkDays;
        private int _WorkHours;

        public Doctor(int id, string name, string surname, string patronymic, string pasport, string phoneNumber,
                       DateTime birthday, string speciality, int[] workDays, int workHours)
        {
            ID = id;
            Name = name;
            SurName = surname;
            Patronymic = patronymic;
            Pasport = pasport;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            _Speciality = speciality;
            _WorkDays = new int[7];
            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < workDays.Length; ++j)
                    if (i == workDays[j])
                        _WorkDays[i] = 1;
                    else 
                        _WorkDays[i] = 0;
            }
            _WorkHours = workHours;
        }
        public new string GiveTakeName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public new string GiveTakeSurName
        {
            get
            {
                return SurName;
            }
            set
            {
                SurName = value;
            }
        }
        public new string GiveTakePatronymic
        {
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
        public int [] GiveWorkDays
        {
            get
            {
                return _WorkDays;
            }
        }
        public int GiveWorkHours
        {
            get
            {
                return _WorkHours;
            }
        }
    }
}
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
        private int[] _WorkHours;

        public Doctor(string name, string surname, string patronymic, string phoneNumber,
                       DateTime birthday, string speciality, int[] workDays, int workHours)
        {
            Name = name;
            SurName = surname;
            Patronymic = patronymic;
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
            if (workHours == 1)
            {
               
            }
            else
            {

            }
            ID = 0;
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
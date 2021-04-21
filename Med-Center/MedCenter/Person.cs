using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCenter
{
    public abstract class Person
    {
        protected int ID;
        protected string Name;
        protected string SurName;
        protected string Patronymic;
        protected string Pasport;
        protected string PhoneNumber;
        protected DateTime Birthday;
        public string GiveTakeName { get; set; }
        public string GiveTakeSurName { get; set; }
        public string GiveTakePatronymic { get; set; }
        public string GiveTakePhoneNumber { get; set; }
        public string GiveTakePasport { get; set; }
        public DateTime GiveTakeBirthday { get; set; }
        public int GiveTakeID { get; set; }
    }
}

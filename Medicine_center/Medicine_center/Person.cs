using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_center
{
    abstract class Person
    {
        protected string Name;
        protected string SurName;
        protected string Patronymic;
        protected string PhoneNumber;
        protected string Pasport;
        protected DateTime Birthday;
        protected int ID;
        public string GiveTakeName{ get; set; }
        public string GiveTakeSurName { get; set; }
        public string GiveTakePatronymic { get; set; }
        public string GiveTakePhoneNumber{ get; set; }
        public string GiveTakePasport { get; set; }
        public DateTime GiveTakeBirthday { get; set; }
        public int GiveTakeID { get; set; }
    }
}

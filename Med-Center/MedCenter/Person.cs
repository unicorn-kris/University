using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCenter
{
    public abstract class Person
    {
        protected int _ID;
        protected string _Name;
        protected string _SurName;
        protected string _Patronymic;
        protected string _Pasport;
        protected string _PhoneNumber;
        protected DateTime _Birthday;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Pasport { get; set; }
        public DateTime Birthday { get; set; }
        public int ID { get; set; }
    }
}

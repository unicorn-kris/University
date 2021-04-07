using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine_center
{//придумать айди!
    class Appointment
    {
        private Patient _patient;
        private Doctor _doctor;
        private Cabinet _cabinet;
        private DateTime _dateTime;
        public Appointment (Doctor doctor, Cabinet cabinet, DateTime dateTime)
        {
            _patient = null;
            _doctor = doctor;
            _cabinet = cabinet;
            _dateTime = dateTime;
        }
        public new Patient GiveTakePatient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
            }
        }
        public new Doctor GiveTakeDoctor
        {
            get
            {
                return _doctor;
            }
            set
            {
                _doctor = value;
            }
        }
        public new Cabinet GiveTakeCabinet
        {
            get
            {
                return _cabinet;
            }
            set
            {
                _cabinet = value;
            }
        }
        public new DateTime GiveTakeDate
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
            }
        }
        
        
    }
}

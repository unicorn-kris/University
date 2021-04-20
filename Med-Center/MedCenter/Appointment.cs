using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCenter
{
    public class Appointment
    {
        private Patient _patient;
        private Doctor _doctor;
        private Cabinet _cabinet;
        private int _day;
        private int _hour;
        private int _minutes;
        public Appointment(Doctor doctor, Cabinet cabinet, int day, int hour, int minute)
        {
            _patient = null;
            _doctor = doctor;
            _cabinet = cabinet;
            _day = day;
            _hour = hour;
            _minutes = minute;
        }
        public Patient GiveTakePatient
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
        public Doctor GiveTakeDoctor
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
        public Cabinet GiveTakeCabinet
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
        public int GiveTakeDay
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value;
            }
        }
        public int GiveTakeHour
        {
            get
            {
                return _hour;
            }
            set
            {
                _hour = value;
            }
        }
        public int GiveTakeMinute
        {
            get
            {
                return _minutes;
            }
            set
            {
                _minutes = value;
            }
        }

    }
}



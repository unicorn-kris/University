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
        private int ID;

        //если нет такого айди то добавить запись, иначе вывести сообщение о существовании записи на данное число и время
        public Appointment (Patient patient, Doctor doctor, Cabinet cabinet, DateTime dateTime)
        {
            ID = _doctor.GiveTakeID;//change!
            _patient = patient;
            _doctor = doctor;
            _cabinet = cabinet;
            _dateTime = dateTime;
        }

    }
}

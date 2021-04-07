using System.Collections.Generic;

namespace Medicine_center
{//добавляет записи в список, позже по нему проводится поиск существующей записи по айди!
    class Shedule
    {
        private List<Appointment> _appointments;
        public Shedule()
        {
            _appointments = null;
        }
        public Shedule(List<Appointment> appointments)
        {
            _appointments = appointments;
        }
        public List<Appointment> GetAppointments
        {
            get
            {
                return _appointments;
            }
        }
        public bool CheckForExist(Patient patient)//если паспорт совпадает то запись уже есть
        {
            bool check = false;
            foreach (Appointment appointment in _appointments)
            {
                if (appointment.GiveTakePatient.GiveTakePasport != patient.GiveTakePasport)
                {
                    check = true;
                }
            }
            return check;
        }
        public void AddAppointment(Appointment appointment)
        {
            foreach (Appointment appointmentExist in _appointments)
            {
                //доктор есть, кабинет есть, а времени такого нет - добавить запись
                if (appointmentExist.GiveTakeDoctor.GiveTakePasport == appointment.GiveTakeDoctor.GiveTakePasport &&
                    appointmentExist.GiveTakeCabinet.GiveTakeNumber == appointment.GiveTakeCabinet.GiveTakeNumber &&
                    appointmentExist.GiveTakeDate != appointment.GiveTakeDate) 
                {
                    _appointments.Add(appointment);
                }

                //доктор есть, но у него нет такого кабинета и времени - добавить запись
               else if (appointmentExist.GiveTakeDoctor.GiveTakePasport == appointment.GiveTakeDoctor.GiveTakePasport &&
                    appointmentExist.GiveTakeCabinet.GiveTakeNumber != appointment.GiveTakeCabinet.GiveTakeNumber &&
                    appointmentExist.GiveTakeDate != appointment.GiveTakeDate)
                {
                    _appointments.Add(appointment);
                }
                
            }
        }
        public void AddPatientInAppointment(Patient patient, Appointment appointment)
        {
            Appointment appointmentNew = appointment;//создана новая запись для будущего добавления
            appointment.GiveTakePatient = patient;

            //доктор есть, кабинет есть, время есть, пациента в этой записи нет - добавить пациента и заменить запись
            for (int index=0; index<_appointments.Count; ++index)
            {
                if (_appointments[index].GiveTakeDoctor.GiveTakePasport == appointment.GiveTakeDoctor.GiveTakePasport &&
                    _appointments[index].GiveTakeCabinet.GiveTakeNumber == appointment.GiveTakeCabinet.GiveTakeNumber &&
                    _appointments[index].GiveTakeDate == appointment.GiveTakeDate &&
                    _appointments[index].GiveTakePatient == null)
                {
                    _appointments[index] = appointmentNew;
                }
            }
        }
        public void DeletePatientInAppointment(Patient patient, Appointment appointment)
        {
            Appointment appointmentNew = appointment;//создана новая запись для будущего добавления
            appointment.GiveTakePatient = null;

            //доктор есть, время и кабинет есть и есть пациент - заменить запись на аналогичную без пациента
            for (int index = 0; index < _appointments.Count; ++index)
            {
                if (_appointments[index].GiveTakeDoctor.GiveTakePasport == appointment.GiveTakeDoctor.GiveTakePasport &&
                    _appointments[index].GiveTakeCabinet.GiveTakeNumber == appointment.GiveTakeCabinet.GiveTakeNumber &&
                    _appointments[index].GiveTakeDate == appointment.GiveTakeDate &&
                    _appointments[index].GiveTakePatient == patient)
                {
                    _appointments[index] = appointmentNew;
                }
            }
        }
    }
}

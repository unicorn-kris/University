using System.Collections.Generic;

namespace MedCenter
{//добавляет записи в список, позже по нему проводится поиск существующей записи по айди!
     public class Shedule
    {
        private List<DataAppointment> _appointments;

        public Shedule(List<DataAppointment> appointments)
        {
            _appointments = appointments;
        }
        public List<DataAppointment> GetAppointments
        {
            get
            {
                return _appointments;
            }
        }
        //public bool CheckForExist(Patient patient)//если паспорт совпадает то запись уже есть
        //{
        //    bool check = false;
        //    foreach (Appointment appointment in _appointments)
        //    {
        //        if (appointment.GiveTakePatient.GiveTakePasport != patient.GiveTakePasport)
        //        {
        //            check = true;
        //        }
        //    }
        //    return check;
        //}
        public void AddAppointment(DataAppointment appointment)
        {
            bool save = false;
            if (_appointments.Count != 0 && appointment != null)
            {
                foreach (DataAppointment appointmentExist in _appointments)
                {
                    //доктор есть, кабинет есть, а времени такого нет - добавить запись
                    if (appointmentExist.GiveTakeDoctorID == appointment.GiveTakeDoctorID
                        && (appointmentExist.GiveTakeDay != appointment.GiveTakeDay ||
                         appointmentExist.GiveTakeHour != appointment.GiveTakeHour ||
                         appointmentExist.GiveTakeMinute != appointment.GiveTakeMinute))

                    {
                        save = true;
                    }

                }
            }

            foreach (DataAppointment appointmentExist in _appointments)
            {
                if (appointmentExist.GiveTakeDoctorID != appointment.GiveTakeDoctorID)
                    save = true;
            }

            if (save || _appointments.Count == 0)
                _appointments.Add(appointment);
        }
        //проверить!
        public void DeleteDocAppointment(Doctor doctor)
        {
            for (int i = 0; i < _appointments.Count; ++i)
            {
                if (_appointments[i].GiveTakeDoctorID == doctor.GiveTakeID)
                {
                    _appointments.RemoveAt(i);
                }
            }

        }
        public void DeletePatAppointment(Patient patient)
        {
            for (int i = 0; i < _appointments.Count; ++i)
            {
                if (_appointments[i].GiveTakePatientID != 0 && _appointments[i].GiveTakePatientID == patient.GiveTakeID)
                {
                    _appointments[i].GiveTakePatientID = 0;
                }
            }

        }
        public int Count()
        {
            if (_appointments != null)
                return _appointments.Count;
            else
                return 0;

        }

        public void AddPatientInAppointment(Patient patient, DataAppointment appointment)
        {
            DataAppointment appointmentNew = appointment;//создана новая запись для будущего добавления
            appointment.GiveTakePatientID = patient.GiveTakeID;

            //доктор есть, кабинет есть, время есть, пациента в этой записи нет - добавить пациента и заменить запись
            for (int index = 0; index < _appointments.Count; ++index)
            {
                if (_appointments[index].GiveTakeDoctorID == appointment.GiveTakeDoctorID &&
                    _appointments[index].GiveTakeCabinetNumber != 0)
                    if (_appointments[index].GiveTakeCabinetNumber == appointment.GiveTakeCabinetNumber && _appointments[index].GiveTakePatientID == 0)
                        if (_appointments[index].GiveTakeDay == appointment.GiveTakeDay)
                            if (_appointments[index].GiveTakeHour == appointment.GiveTakeHour)
                                if (_appointments[index].GiveTakeMinute == appointment.GiveTakeMinute)
                                {
                                    _appointments[index] = appointmentNew;
                                }
            }
        }
        public void DeletePatientInAppointment(Patient patient, DataAppointment appointment)
        {
            DataAppointment appointmentNew = appointment;//создана новая запись для будущего удаления

            //доктор есть, время и кабинет есть и есть пациент - заменить запись на аналогичную без пациента
            for (int index = 0; index < _appointments.Count; ++index)
            {
                if (_appointments[index].GiveTakeDoctorID == appointment.GiveTakeDoctorID &&
                    _appointments[index].GiveTakeCabinetNumber != 0)
                    if (_appointments[index].GiveTakeCabinetNumber == appointment.GiveTakeCabinetNumber && _appointments[index].GiveTakePatientID != 0)
                        if (_appointments[index].GiveTakeDay == appointment.GiveTakeDay)
                            if (_appointments[index].GiveTakeHour == appointment.GiveTakeHour)
                                if (_appointments[index].GiveTakeMinute == appointment.GiveTakeMinute)
                                    
                                {
                                    appointmentNew.GiveTakePatientID = 0;
                                    _appointments[index] = appointmentNew;
                                }
            }
        }
    }
}

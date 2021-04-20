using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCenter
{
    public class DataAppointment
    {
        private int _DoctorID;
        private int _CabinetNumber;
        private int _Day;
        private int _Hour;
        private int _Minute;
        private int _PatientID;
        public DataAppointment(int doctorID, int cabinetNum, int day, int hour, int minute, int patientID)
        {
            _DoctorID = doctorID;
            _CabinetNumber = cabinetNum;
            _Day = day;
            _Hour = hour;
            _Minute = minute;
            _PatientID = patientID;
        }
        public int GiveTakeDoctorID
        {
            get
            {
                return _DoctorID;
            }
            set
            {
                _DoctorID = value;
            }
        }
        public int GiveTakeCabinetNumber
        {
            get
            {
                return _CabinetNumber;
            }
            set
            {
                _CabinetNumber = value;
            }
        }
        public int GiveTakeDay
        {
            get
            {
                return _Day;
            }
            set
            {
                _Day = value;
            }
        }
        public int GiveTakeHour
        {
            get
            {
                return _Hour;
            }
            set
            {
                _Hour = value;
            }
        }
        public int GiveTakeMinute
        {
            get
            {
                return _Minute;
            }
            set
            {
                _Minute = value;
            }
        }
        public int GiveTakePatientID
        {
            get
            {
                return _PatientID;
            }
            set
            {
                _PatientID = value;
            }
        }
    }
}

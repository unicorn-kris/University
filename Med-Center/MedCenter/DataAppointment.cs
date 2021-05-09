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
        public DataAppointment()
        {
            _DoctorID = 0;
            _CabinetNumber = 0;
            _Day = -1;
            _Hour = -1;
            _Minute = -1;
            _PatientID = 0;
        }
        public DataAppointment(int doctorID, int cabinetNum, int day, int hour, int minute, int patientID)
        {
            _DoctorID = doctorID;
            _CabinetNumber = cabinetNum;
            _Day = day;
            _Hour = hour;
            _Minute = minute;
            _PatientID = patientID;
        }
        public int DoctorID
        {
            get => _DoctorID;
            set => _DoctorID = value;
        }
        public int CabinetNumber
        {
            get => _CabinetNumber;
            set => _CabinetNumber = value;
        }
        public int Day
        {
            get => _Day;
            set => _Day = value;
        }
        public int Hour
        {
            get => _Hour;
            set => _Hour = value;
        }
        public int Minute
        {
            get => _Minute;
            set => _Minute = value;
        }
        public int PatientID
        {

            get => _PatientID;
            set => _PatientID = value;
        }
    }
}

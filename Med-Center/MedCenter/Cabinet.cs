namespace MedCenter
{
    public class Cabinet
    {
        private int _Number;
        private int _CabinetID;
        private string _Speciality;

        public Cabinet(int number, string speciality)
        {
            _Number = number;
            _Speciality = speciality;
        }
        public Cabinet()
        {
            _Number = 0;
            _Speciality = "";
        }
        public Cabinet(int id, int number, string speciality)
        {
            _Number = number;
            _Speciality = speciality;
            _CabinetID = id;
        }
        public int Number
        {
            get => _Number;
            set => _Number = value;
        }
        public string Speciality
        {
            get => _Speciality;
            set => _Speciality = value;
        }
        public int ID
        {
            get => _CabinetID;
            set => _CabinetID = value;
        }
    }
}

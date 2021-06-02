using BL;
using MedCenter;
using System;
using System.Windows.Forms;

namespace Med__Center
{
    public partial class Shedule : Form
    {
        public Shedule()
        {
            InitializeComponent();
            var doc = doctor.GetAll();
            foreach(Doctor doctorADD in doc)
            {
                comboBox1.Items.Add(doctorADD);
            }
            var pat = patient.GetAll();
            foreach(Patient patientAdd in pat)
            {
                comboBox2.Items.Add(patientAdd);
            }

            textBox1.Clear();
            var data = dataAppointment.GetAll();
            foreach (DataAppointment data1 in data)
            {
                int docID = data1.DoctorID;
                int day = data1.Day;
                int patID = data1.PatientID;

                string daySTR = "";
                switch (day)
                {
                    case 0:
                        daySTR = "Пн";
                        break;
                    case 1:
                        daySTR = "Вт";
                        break;
                    case 2:
                        daySTR = "Ср";
                        break;
                    case 3:
                        daySTR = "Чт";
                        break;
                    case 4:
                        daySTR = "Пт";
                        break;
                    case 5:
                        daySTR = "Сб";
                        break;
                    case 6:
                        daySTR = "Вс";
                        break;
                }

                Doctor doctor1 = doctor.ByID(data1.DoctorID);
                textBox1.Text += doctor1.ToString();
                int cabinetNum = data1.CabinetNumber;

                if (cabinetNum == 0)
                    textBox1.Text += "\tКАБИНЕТ: НЕТ";
                else
                    textBox1.Text += " \tКАБИНЕТ: " + cabinetNum;
                textBox1.Text += " \tДЕНЬ: " + daySTR + " ВРЕМЯ: " + data1.Hour + " " + data1.Minute + " \tПациент: ";
                
                if (patID != 0)
                {
                    Patient patient1 = patient.ByID(patID);
                    textBox1.Text += patient1.ToString();
                }
                else
                    textBox1.Text += "НЕТ";
                textBox1.Text += Environment.NewLine;
            }

        }

        private void Shedule_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "medCenterDataSet.Appointments". При необходимости она может быть перемещена или удалена.
            this.appointmentsTableAdapter.Fill(this.medCenterDataSet.Appointments);

        }
        DataAppointment_BL dataAppointment = new DataAppointment_BL();
        Doctor_BL doctor = new Doctor_BL();
        Patient_BL patient = new Patient_BL();
        private void buttonDoc_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "ВРАЧ")
            {
                textBox1.Clear();
                Doctor doctor1 = (Doctor)comboBox1.SelectedItem;
                int search = doctor1.ID;
                var data = dataAppointment.GetByDoctor(search);
                foreach (DataAppointment data1 in data)
                {
                    int docID = data1.DoctorID;
                    int day = data1.Day;

                    string daySTR = "";
                    switch (day)
                    {
                        case 0:
                            daySTR = "Пн";
                            break;
                        case 1:
                            daySTR = "Вт";
                            break;
                        case 2:
                            daySTR = "Ср";
                            break;
                        case 3:
                            daySTR = "Чт";
                            break;
                        case 4:
                            daySTR = "Пт";
                            break;
                        case 5:
                            daySTR = "Сб";
                            break;
                        case 6:
                            daySTR = "Вс";
                            break;
                    }


                    textBox1.Text += doctor1.ToString();
                    int cabinetNum = data1.CabinetNumber;
                    if (cabinetNum == 0)
                        textBox1.Text += "\tКАБИНЕТ: НЕТ";
                    else
                        textBox1.Text += " \tКАБИНЕТ: " + cabinetNum;
                    textBox1.Text += " \tДЕНЬ: " + daySTR + " ВРЕМЯ: " + data1.Hour + " " + data1.Minute + " \tПациент: ";
                    int patID = data1.PatientID;
                    if (patID != 0)
                    {
                        Patient patient1 = patient.ByID(patID);
                        textBox1.Text += patient1.ToString();
                    }
                    else
                        textBox1.Text += "НЕТ";
                    textBox1.Text += Environment.NewLine;
                }
            }

        }

        private void buttonPat_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "ПАЦИЕНТ")
            {
                textBox1.Clear();
                Patient patient1 = (Patient)comboBox2.SelectedItem;
                int search = patient1.ID;
                var data = dataAppointment.GetByPatient(search);
                foreach (DataAppointment data1 in data)
                {
                    int docID = data1.DoctorID;
                    int day = data1.Day;

                    string daySTR = "";
                    switch (day)
                    {
                        case 0:
                            daySTR = "Пн";
                            break;
                        case 1:
                            daySTR = "Вт";
                            break;
                        case 2:
                            daySTR = "Ср";
                            break;
                        case 3:
                            daySTR = "Чт";
                            break;
                        case 4:
                            daySTR = "Пт";
                            break;
                        case 5:
                            daySTR = "Сб";
                            break;
                        case 6:
                            daySTR = "Вс";
                            break;
                    }

                    Doctor doctor1 = doctor.ByID(data1.DoctorID);
                    textBox1.Text += doctor1;
                    int cabinetNum = data1.CabinetNumber;
                    textBox1.Text += " \tКАБИНЕТ: " + cabinetNum;
                    textBox1.Text += doctor1.ToString();
                    textBox1.Text += " \tДЕНЬ: " + daySTR + " ВРЕМЯ: " + data1.Hour + " " + data1.Minute + " \tПациент: ";

                    textBox1.Text += patient1.ToString();

                    textBox1.Text += Environment.NewLine;
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}

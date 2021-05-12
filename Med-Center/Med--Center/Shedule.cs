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
            dataGridView1.AllowUserToAddRows = false;
            comboBox1.DataSource = doctor.GetAll();
            comboBox2.DataSource = patient.GetAll();
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
            Doctor doctor1 = (Doctor)comboBox1.SelectedItem;
            int search = doctor1.ID;
            dataGridView1.DataSource = dataAppointment.GetByDoctor(search);
        }

        private void buttonPat_Click(object sender, EventArgs e)
        {
            Patient patient1 = (Patient)comboBox2.SelectedItem;
            int search = patient1.ID;
            dataGridView1.DataSource = dataAppointment.GetByPatient(search);
        }
    }
}

using System;
using System.Windows.Forms;


namespace Med_Center
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            var itemDoctor = new ToolStripButton("Доктора");
            var itemPatient = new ToolStripButton("Пациента");
            var itemCabinet = new ToolStripButton("Кабинет");
            Добавить.DropDownItems.Add(itemDoctor);
            Добавить.DropDownItems.Add(itemPatient);
            Добавить.DropDownItems.Add(itemCabinet);

            itemDoctor.Click += doctorButtonsClick;
            itemPatient.Click += patientButtonsClick;
            itemCabinet.Click += cabinetButtonsClick;
        }

        private void Имя_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
        private void doctorButtonsClick(object sender, EventArgs e)
        {
            //Doctor_BL doctor = new Doctor_BL();
            // dataGridView1.DataSource = doctor.GetAll();
            AddDoctorForm addDoctorForm = new AddDoctorForm();
            addDoctorForm.Show();
        }
        private void patientButtonsClick(object sender, EventArgs e)
        {
            AddPatientForm addPatientForm = new AddPatientForm();
            addPatientForm.Show();
        }
        private void cabinetButtonsClick(object sender, EventArgs e)
        {
            AddCabinetForm addCabinetForm = new AddCabinetForm();
            addCabinetForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

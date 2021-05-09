using BL;
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

            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;
        }

        Doctor_BL doctor = new Doctor_BL();
        Patient_BL patient = new Patient_BL();
        Cabinet_BL cabinet = new Cabinet_BL();
        private void Имя_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
        private void doctorButtonsClick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = doctor.GetAll();
            AddDoctorForm addDoctorForm = new AddDoctorForm();
            addDoctorForm.ShowDialog(this);
            dataGridView1.DataSource = doctor.GetAll();
        }
        private void patientButtonsClick(object sender, EventArgs e)
        {
            dataGridView2.DataSource = patient.GetAll();
            AddPatientForm addPatientForm = new AddPatientForm();
            addPatientForm.ShowDialog(this);
            dataGridView2.DataSource = patient.GetAll();
        }
        private void cabinetButtonsClick(object sender, EventArgs e)
        {
            dataGridView3.DataSource = cabinet.GetAll();
            AddCabinetForm addCabinetForm = new AddCabinetForm();
            addCabinetForm.ShowDialog(this);
            dataGridView3.DataSource = cabinet.GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "medCenterDataSet.Cabinets". При необходимости она может быть перемещена или удалена.
            this.cabinetsTableAdapter.Fill(this.medCenterDataSet.Cabinets);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "medCenterDataSet.Patients". При необходимости она может быть перемещена или удалена.
            this.patientsTableAdapter.Fill(this.medCenterDataSet.Patients);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "medCenterDataSet.Doctors". При необходимости она может быть перемещена или удалена.
            this.doctorsTableAdapter.Fill(this.medCenterDataSet.Doctors);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text;
            dataGridView1.DataSource = doctor.GetBySurname(search);
            if (search == "")
                dataGridView1.DataSource = doctor.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string search = textBox2.Text;
            dataGridView2.DataSource = patient.GetBySurname(search);
            if (search == "")
                dataGridView2.DataSource = patient.GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                int search = int.Parse(textBox3.Text);
                dataGridView3.DataSource = cabinet.GetInfoCabinet(search);
                if (search < 0)
                    dataGridView3.DataSource = cabinet.GetAll();
            }
            else
            {
                dataGridView3.DataSource = cabinet.GetAll();
            }
        }

            private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
            {
                char number = e.KeyChar;

                if (!Char.IsDigit(number))
                {
                    e.Handled = true;
                    MessageBox.Show("Введите цифры!");
                }
            }
    }
}

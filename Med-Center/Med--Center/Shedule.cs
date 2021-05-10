using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Med__Center
{
    public partial class Shedule : Form
    {
        public Shedule()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
        }

        private void Shedule_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "medCenterDataSet.Appointments". При необходимости она может быть перемещена или удалена.
            this.appointmentsTableAdapter.Fill(this.medCenterDataSet.Appointments);

        }
        DataAppointment_BL dataAppointment = new DataAppointment_BL();
        Doctor_BL doctor = new Doctor_BL();
        Patient_BL patient = new Patient_BL();

        int id = 0;
        int idPat = 0;
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text != "")
            {
                 id = int.Parse(textBox1.Text);

                if (!doctor.HaveDoctor(id))
                    MessageBox.Show("неверный id доктора!");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text != "")
            {
                 idPat = int.Parse(textBox2.Text);

                if (!patient.HavePatient(idPat))
                    MessageBox.Show("неверный id пациента!");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
                MessageBox.Show("Введите цифры!");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
                MessageBox.Show("Введите цифры!");
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int search = id;
            dataGridView1.DataSource = dataAppointment.GetByDoctor(search);
            if (search < 1)
                dataGridView1.DataSource = dataAppointment.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int search = idPat;
            dataGridView1.DataSource = dataAppointment.GetByPatient(search);
            if (search < 1)
                dataGridView1.DataSource = dataAppointment.GetAll();
        }
    }
}

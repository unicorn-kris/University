using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MedCenter;
using BL;

namespace Med_Center
{
    public partial class AddPatientForm : Form
    {
        public AddPatientForm()
        {
            InitializeComponent();
        }

        public string Name = "";
        public String Surname = "";
        public string patronymic = "";
        public string pasport = "";
        public string phoneNumber = "";
        public DateTime birthday = DateTime.Now;
        private void AddPatient_Load(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Name = textBox1.Text;
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Surname = textBox2.Text;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.Clear();
            char number = e.KeyChar;
        }
        private void textBox2_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            patronymic = textBox3.Text;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
        }
        private void textBox3_Click_1(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) || !Char.IsSeparator(number))
            {
                e.Handled = true;
                MessageBox.Show("Введите цифры или пробел!");
            }
        }
        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.IsMatch(textBox4.Text, @"\d{4}\s\d{6}"))
            {
                pasport = textBox4.Text;
            }
            else
            {
                MessageBox.Show("Некорректные паспортные данные!");
            }
        }
        private void textBox4_Click_1(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox5_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.IsMatch(textBox5.Text, @"\d{11}"))
            {
                phoneNumber = textBox5.Text;
            }
            else
            {
                MessageBox.Show("Некорректный номер!");
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
                MessageBox.Show("Введите цифры!");
            }
        }
        private void textBox5_Click_1(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
        

        Patient_BL patientBL = new Patient_BL();
        private void button1_Click(object sender, EventArgs e)
        {
            birthday = dateTimePicker1.Value;

            if (Name == "" || Surname == "" || pasport == "" || phoneNumber == "" || birthday == DateTime.Now
                || (Name == "Имя" || Surname == "Фамилия" || pasport == "Паспортные данные" || phoneNumber == "Номер телефона"))
            {
                MessageBox.Show("Некорректные данные!");
            }
            else
            {
                Patient patient = new Patient(Name, Surname, patronymic, pasport, phoneNumber, birthday);
                patientBL.Add(patient);
                Close();
            }
        }
    }

}

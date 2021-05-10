using BL;
using MedCenter;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Med_Center
{
    public partial class AddCabinetForm : Form
    {
        public AddCabinetForm()
        {
            InitializeComponent();
        }

        private void AddCabinet_Load(object sender, EventArgs e)
        {

        }
        public int num = -1;
        public string speciality = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool insert = int.TryParse(textBox1.Text, out num);
            if (insert)
                num = int.Parse(textBox1.Text);
            else
                num = -1;
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
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            speciality = textBox2.Text;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, @".*\d"))
            {
                num = int.Parse(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Некорректный номер кабинета!");
            }
        }

        Cabinet_BL cabinetBL = new Cabinet_BL();
        private void button1_Click(object sender, EventArgs e)
        {
            if (num == -1 || speciality == "")
                MessageBox.Show("Введите все данные корректно!");
            else
            {
                Cabinet cabinet = new Cabinet(num, speciality);
                cabinetBL.Add(cabinet);
                Close();
            }
        }
    }
}

using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BL;
using MedCenter;

namespace Med_Center
{
    public partial class AddDoctorForm : Form
    {
        public AddDoctorForm()
        {
            InitializeComponent();

            this.checkedListBox1.Items.AddRange(new object[] { "понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье"});

            this.Controls.Add(this.checkedListBox1);

            this.checkedListBox2.Items.AddRange(new object[] {1, 2});

            this.Controls.Add(this.checkedListBox2);
        }

        public string Name = "";
        public String Surname = "";
        public string patronymic = "";
        public string pasport = "";
        public string phoneNumber = "";
        public DateTime birthday = DateTime.Now;
        public string speciality = "";
        public int[] workdays = new int[7];
        public int workhours = 0;
        private void AddDoctorForm_Load(object sender, EventArgs e)
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
        private void textBox2_Click(object sender, EventArgs e)
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
        private void textBox3_Click(object sender, EventArgs e)
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
        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Regex.IsMatch(textBox6.Text, @"^(?:0[1-9]|[12]\d|3[01])([.])(?:0[1-9]|1[012])\1(?:19|20)\d\d$"))
            {
                string date = textBox6.Text;
                string[] dateCorrect = date.Split('.');

                birthday = new DateTime(int.Parse(dateCorrect[2]), int.Parse(dateCorrect[1]), int.Parse(dateCorrect[0]));
            }
            else
            {
                MessageBox.Show("Некорректная дата!");
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

        }
        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            speciality = textBox7.Text;
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
        }

       

        private void checkedListBox1_Click(object sender, EventArgs e)
        {

            // Для каждого элемента из CheckedListBox.

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {

                // Отмечен ли элемент?

                if (checkedListBox1.GetItemChecked(i))
                {

                    // Получение текста элемента и добавление к orderInfo.

                    workdays[i] = 1;
                }
                else
                    workdays[i] = 0;
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Если отмечено больше 2 элементов, то снимаем выделение со всех и отмечаем текущий.
            if (checkedListBox2.CheckedItems.Count > 1)
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                    checkedListBox2.SetItemChecked(i, false);
                checkedListBox2.SetItemChecked(checkedListBox1.SelectedIndex, true);
            }
        }

        private void checkedListBox2_Click(object sender, EventArgs e)
        {
            // Для каждого элемента из CheckedListBox.

            for (int i = 0; i < 2; i++)
            {

                // Отмечен ли элемент?

                if (checkedListBox2.GetItemChecked(0))
                {

                    // Получение текста элемента и добавление к orderInfo.

                    workhours = 1;
                }
                else if (checkedListBox2.GetItemChecked(1))
                    workhours = 2;
            }
        }
        Doctor_BL doctorBL = new Doctor_BL();
        private void button1_Click(object sender, EventArgs e)
        {
            if (Name == "" || Surname == "" || pasport == "" || phoneNumber == "" || birthday == DateTime.Now || speciality == "" || workhours == 0
                || (Name == "Имя" || Surname == "Фамилия" || pasport == "Паспортные данные" || phoneNumber == "Номер телефона" || speciality == "Специальность"))
            {
                MessageBox.Show("Некорректные данные!");
            }
            else
            {
                Doctor doctor = new Doctor(Name, Surname, patronymic, pasport, phoneNumber, birthday, speciality, workdays, workhours);
                doctorBL.Add(doctor);
                Close();
            }

        }
    }
}

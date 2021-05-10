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
    public partial class ChangeCabinet : Form
    {
        public ChangeCabinet()
        {
            InitializeComponent();
        }
        Doctor_BL doctor = new Doctor_BL();
        Cabinet_BL cabinet = new Cabinet_BL();
        DataAppointment_BL dataAppointment = new DataAppointment_BL();

        int id = 0;
        int num = 0;
        int day = -1;
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);

                if (!doctor.HaveDoctor(id))
                    MessageBox.Show("неверный id доктора!");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text != "")
            {
                int num = int.Parse(textBox2.Text);

                if (!cabinet.HaveCabinet(num))
                    MessageBox.Show("неверный номер кабинета!");
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
            id = int.Parse(textBox1.Text);
            num = int.Parse(textBox2.Text);
            //int day = int.Parse(checkedListBox1.GetItemChecked);

            if (!doctor.HaveDoctor(id))
                MessageBox.Show("неверный id доктора!");
            else if (!cabinet.HaveCabinet(num))
                MessageBox.Show("неверный номер кабинета!");

            else
            {
                int oneday = 0;
                day = -1;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    // Отмечен ли элемент?
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        day = i;
                        ++oneday;
                    }
                }

                if (oneday != 1)
                {
                    MessageBox.Show("Выберите 1 день!");
                }

                else if (!dataAppointment.FreeCabinet(num, day))
                    MessageBox.Show("кабинет занят в этот день!");

                else
                {
                    if (!doctor.HaveDay(id, day))
                        MessageBox.Show("доктор не работает в этот день!");
                    else if (dataAppointment.FreeDoctor(id, day))
                        MessageBox.Show("доктор не имеет кабинет в этот день!");
                    else if (!dataAppointment.FreeDoctor(id, day))
                    {
                        dataAppointment.ChangeCabinetInAppointment(id, day, num);
                        MessageBox.Show("кабинет успешно изменен!");
                    }
                }
            }
        }

        private void ChangeCabinet_Load(object sender, EventArgs e)
        {

        }
    }
}

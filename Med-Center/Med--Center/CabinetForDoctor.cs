using BL;
using MedCenter;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Med__Center
{
    public partial class CabinetForDoctor : Form
    {
        public CabinetForDoctor()
        {
            InitializeComponent();
        }
        Doctor_BL doctor = new Doctor_BL();
        Cabinet_BL cabinet = new Cabinet_BL();
        DataAppointment_BL dataAppointment = new DataAppointment_BL();
        private void CabinetForDoctor_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "medCenterDataSet.Doctors". При необходимости она может быть перемещена или удалена.
            this.doctorsTableAdapter.Fill(this.medCenterDataSet.Doctors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "medCenterDataSet.Cabinets". При необходимости она может быть перемещена или удалена.
            this.cabinetsTableAdapter.Fill(this.medCenterDataSet.Cabinets);

        }
        int id = 0;
        int num = 0;
        int day = -1;
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
                    else if (!dataAppointment.FreeDoctor(id, day))
                        MessageBox.Show("доктор имеет кабинет в этот день!");
                    else
                    {
                        var doctor1 = doctor.GetByID(id);
                        foreach (Doctor newdoc in doctor1)
                        {
                            Doctor doctor2 = newdoc;
                            if ((int)doctor2.WorkDays[day] == '1')
                            {
                                if (doctor2.WorkHours == 1)
                                {
                                    int hour = 8;
                                    int minute = 0;
                                    while (hour < 13)
                                    {
                                        DataAppointment data = new DataAppointment(id, num, day, hour, minute, 0);
                                        dataAppointment.Add(data);
                                        if (minute == 30)
                                        {
                                            ++hour;
                                            minute = 0;
                                        }
                                        else if (minute == 0)
                                            minute = 30;

                                    }
                                }
                                else if (doctor2.WorkHours == 2)
                                {
                                    int hour = 14;
                                    int minute = 0;
                                    while (hour < 19)
                                    {
                                        DataAppointment data = new DataAppointment(id, num, day, hour, minute, 0);
                                        dataAppointment.Add(data);
                                        if (minute == 30)
                                        {
                                            ++hour;
                                            minute = 0;
                                        }
                                        else if (minute == 0)
                                            minute = 30;
                                    }
                                }
                            
                            }
                        }
                        Close();
                    }
                }
            }
        }

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

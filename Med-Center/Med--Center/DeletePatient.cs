using BL;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Med__Center
{
    public partial class DeletePatient : Form
    {
        public DeletePatient()
        {
            InitializeComponent();
        }
        Doctor_BL doctor = new Doctor_BL();
        Cabinet_BL cabinet = new Cabinet_BL();
        Patient_BL patient = new Patient_BL();
        DataAppointment_BL dataAppointment = new DataAppointment_BL();

        int docID = 0;
        int patID = 0;
        int day = -1;
        int hour = 0;
        int minute = -1;
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text != "")
            {
                bool insert = int.TryParse(textBox1.Text, out docID);
                if (insert)
                {
                    if (!doctor.HaveDoctor(docID))
                        MessageBox.Show("неверный id доктора!");
                    else if (!dataAppointment.HaveDoctorInAppointments(docID))
                        MessageBox.Show("невозможно создать запись для данного доктора!");
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            bool insert = int.TryParse(textBox2.Text, out patID);
            if (insert)
            {
                if (textBox2.Text != "")
                {
                    patID = int.Parse(textBox2.Text);

                    if (!patient.HavePatient(patID))
                        MessageBox.Show("неверный id пациента!");
                }
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }


        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

            if (textBox3.Text != "")
            {
                bool insert = int.TryParse(textBox3.Text, out hour);
                if (insert)
                {
                    hour = int.Parse(textBox3.Text);

                    if (!doctor.HaveHour(docID, hour))
                        MessageBox.Show("доктор не работает в это время!");
                }
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text != "")
            {
                bool insert = int.TryParse(textBox4.Text, out minute);
                if (insert)
                {
                    minute = int.Parse(textBox4.Text);

                    if (minute != 0 && minute != 30)
                        MessageBox.Show("запись возможна только на 0 или 30 минут!");
                }
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!dataAppointment.HaveDoctorInAppointments(docID))
                MessageBox.Show("невозможно создать запись для данного доктора!");
            else
            {
                int oneday = 0;
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

                else
                {
                    if (!doctor.HaveDay(docID, day))
                        MessageBox.Show("доктор не работает в этот день!");
                    else if (dataAppointment.FreeDoctor(docID, day))
                        MessageBox.Show("у доктора не назначен кабинет в этот день!");
                    else
                    {
                        if (!doctor.HaveHour(docID, hour))
                            MessageBox.Show("доктор не работает в это время!");
                        else
                        {
                            dataAppointment.DeletePatientInAppointment(docID, patID, day, hour, minute);
                            MessageBox.Show("пациент успешно удален из записи!");
                            Close();
                        }
                    }
                }
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
                MessageBox.Show("Введите цифры!");
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

        private void DeletePatient_Load(object sender, EventArgs e)
        {

        }
    }
}

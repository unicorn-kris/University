using BL;
using MedCenter;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Med_Center
{
    public partial class AddAppointmentForm : Form
    {
        public AddAppointmentForm()
        {
            InitializeComponent();
            comboBox1.DataSource = doctor.GetAll();
            comboBox2.DataSource = patient.GetAll();
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

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "medCenterDataSet.Doctors". При необходимости она может быть перемещена или удалена.
            this.doctorsTableAdapter.Fill(this.medCenterDataSet.Doctors);
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {

            if (textBox4.Text != "")
            {
                bool insert = int.TryParse(textBox4.Text, out hour);
                if (insert)
                {
                    hour = int.Parse(textBox4.Text);

                    if (!doctor.HaveHour(docID, hour))
                        MessageBox.Show("доктор не работает в это время!");
                }
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text != "")
            {
                bool insert = int.TryParse(textBox5.Text, out minute);
                if (insert)
                {
                    minute = int.Parse(textBox5.Text);

                    if (minute != 0 && minute != 30)
                        MessageBox.Show("запись возможна только на 0 или 30 минут!");
                }
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
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
                            if (!dataAppointment.CanAddPatientInAppointment(docID, patID, day, hour, minute))
                                MessageBox.Show("На это время записан другой пациент!");
                            else
                            {
                                
                                    dataAppointment.ChangePatientInAppointment(docID, patID, day, hour, minute);
                                    MessageBox.Show("пациент успешно добавлен!");
                                    Close();
                                
                            }
                        }
                    }
                }
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
                MessageBox.Show("Введите цифры!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Doctor doctor1 = (Doctor)comboBox1.SelectedItem;
            docID = doctor1.ID;
            if (!dataAppointment.HaveDoctorInAppointments(docID))
                MessageBox.Show("невозможно создать запись для данного доктора!");
            else
            {
                textBox1.Text = $"смена работы врача: {doctor1.WorkHours}";
                for (int i = 0; i < 7; ++i)
                {
                    if (doctor1.WorkDays[i] == '1')
                    {
                        string daySTR = "";
                        switch (i)
                        {
                            case 0:
                                daySTR = "Пн";
                                break;
                            case 1:
                                daySTR = "Вт";
                                break;
                            case 2:
                                daySTR = "Ср";
                                break;
                            case 3:
                                daySTR = "Чт";
                                break;
                            case 4:
                                daySTR = "Пт";
                                break;
                            case 5:
                                daySTR = "Сб";
                                break;
                            case 6:
                                daySTR = "Вс";
                                break;
                        }

                        if (daySTR != "")
                        {
                            ListViewItem item = new ListViewItem(daySTR);
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Patient patient1 = (Patient)comboBox2.SelectedItem;
            patID = patient1.ID;

        }
    }
}

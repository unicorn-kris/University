using BL;
using MedCenter;
using System;
using System.Windows.Forms;

namespace Med__Center
{
    public partial class ChangeCabinet : Form
    {
        public ChangeCabinet()
        {
            InitializeComponent();
            comboBox1.DataSource = doctor.GetAll();
            comboBox2.DataSource = cabinet.GetAll();
        }
        Doctor_BL doctor = new Doctor_BL();
        Cabinet_BL cabinet = new Cabinet_BL();
        DataAppointment_BL dataAppointment = new DataAppointment_BL();

        int id = 0;
        int num = 0;
        int day = -1;

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Doctor doctor1 = (Doctor)comboBox1.SelectedItem;
            id = doctor1.ID;
            if (!dataAppointment.HaveDoctorInAppointments(id))
                MessageBox.Show("невозможно создать запись для данного доктора!");
            else
            {

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
            Cabinet cabinet1 = (Cabinet)comboBox2.SelectedItem;
            num = cabinet1.Number;

        }
    }
}


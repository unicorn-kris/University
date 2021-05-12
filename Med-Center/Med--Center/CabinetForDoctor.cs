using BL;
using MedCenter;
using System;
using System.Windows.Forms;

namespace Med__Center
{
    public partial class CabinetForDoctor : Form
    {
        public CabinetForDoctor()
        {
            InitializeComponent();
            comboBox1.DataSource = doctor.GetAll();
            comboBox2.DataSource = cabinet.GetAll();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Doctor doctor1 = (Doctor)comboBox1.SelectedItem;
            id = doctor1.ID;
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cabinet cabinet1 = (Cabinet)comboBox2.SelectedItem;
            num = cabinet1.Number;

        }
    }
}

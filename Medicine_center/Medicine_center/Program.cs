using System;
using System.Collections.Generic;
using System.IO;

namespace Medicine_center
{
    class Program
    {
        enum AdminDecide
        {
            AddNewDoctor = 1,
            AddNewCabinet,
            AddPatientInAppointment,
            DeletePatientInAppointment,
            DeletePatient,
            DeleteDoctor,
            ShowShedule,
            AddCabinetsInShedule,
            Save
        }

        static void InputNewPerson(out string name, out string surname, out string patronymic, out string phoneNumber, out string pasport,
             out DateTime birthday)
        {
            Console.WriteLine("Введите имя");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            surname = Console.ReadLine();
            Console.WriteLine("Введите отчество");
            patronymic = Console.ReadLine();
            Console.WriteLine("Введите паспортные данные");
            pasport = Console.ReadLine();
            Console.WriteLine("Введите номер телефона");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Введите дату рождения в виде трех чисел: год, месяц, день");

            birthday = new DateTime(1, 1, 1);
            while (birthday.Year == 1)
            {
                try
                {
                    int day = int.Parse(Console.ReadLine());
                    int month = int.Parse(Console.ReadLine());
                    int year = int.Parse(Console.ReadLine());
                    birthday = new DateTime(day, month, year);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Введите корректную дату");
                }
            }
        }
        static int Input()
        {
            int N;
            bool input = int.TryParse(Console.ReadLine(), out N);
            while (!input || N < 0 || N > 10)
            {
                Console.WriteLine("Введите корректное значение");
                input = int.TryParse(Console.ReadLine(), out N);
            }
            return N;
        }
        static void FindPatient(List<Patient> patients, out Patient newPatient)
        {
            newPatient = null;
            int id = -1;
            string name = "";
            string surname = "";
            string patronymic = "";
            string pasport = "";
            string phoneNumber = "";
            DateTime birthday = new DateTime(1, 1, 1);

            Console.WriteLine("Введите фамилию пациента");
            string patSurname = Console.ReadLine();
            bool find = false;

            Patient findPatient = null;
            foreach (Patient patient in patients)
            {
                if (patient.GiveTakeSurName == patSurname)
                {
                    Console.WriteLine("ID, name, surname, patronymic, phone, pasport, birthday");
                    Console.Write($"{patient.GiveTakeID} {patient.GiveTakeName} {patient.GiveTakeSurName} {patient.GiveTakePatronymic} " +
               $" {patient.GiveTakePasport} {patient.GiveTakePhoneNumber} {patient.GiveTakeBirthday}");
                    Console.WriteLine();
                    find = true;
                    Console.WriteLine("Введите id пациента");
                }
            }


            bool findPat = false;
            if (find)
            {
                int index = int.Parse(Console.ReadLine());
                while (!findPat && index != 0)
                {
                    foreach (Patient patient in patients)
                    {
                        if (patient.GiveTakeID == index)
                        {
                            findPat = true;
                            findPatient = patient;
                        }
                    }
                    if (!findPat)
                    {
                        Console.WriteLine("Неверный id, введите новый или 0, чтобы ввести нового пациента");
                        index = int.Parse(Console.ReadLine());
                    }
                }
            }

            if (findPat)
                newPatient = findPatient;

            if (!find || !findPat)

            {
                Console.WriteLine("Пациент не найден в базе, введите данные нового пациента!\n");
                InputNewPerson(out name, out surname, out patronymic,  out pasport, out phoneNumber, out birthday);

                if (patients.Count != 0)
                    id = patients[patients.Count - 1].GiveTakeID + 1;
                else
                    id = 1;

                newPatient = new Patient(id, name, surname, patronymic, pasport, phoneNumber, birthday);

                //bool havePat = false;
                //if (patients.Count != 0)
                //{
                //    foreach (Patient patient in patients)
                //    {
                //        if (patient.GiveTakePasport == newPatient.GiveTakePasport)
                //        {
                //            havePat = true;
                //        }

                //    }
                //}
                //if (!havePat)
                //{
                    //if (patients.Count != 0)
                    //    id = patients[patients.Count - 1].GiveTakeID + 1;
                    //else
                    //    id = 1;
                    patients.Add(newPatient);
                    
                
            }
        }
        static bool FindDoctor(List<Doctor> doctors, out Doctor doctorForApp)
        {
            doctorForApp = null;
            Console.WriteLine("Введите фамилию врача");
            string docSurname = Console.ReadLine();
            bool find = false;
            foreach (Doctor doctor in doctors)
            {
                if (doctor.GiveTakeSurName == docSurname)
                {
                    Console.Write($"{doctor.GiveTakeID} {doctor.GiveTakeName} {doctor.GiveTakeSurName} {doctor.GiveTakePatronymic} " +
                        $"{doctor.GiveTakePhoneNumber} {doctor.GiveTakePasport} {doctor.GiveTakeBirthday} {doctor.GiveTakeSpeciality} ");
                    for (int i = 0; i < 7; ++i)
                        Console.Write($"{doctor.GiveWorkDays[i]} ");
                    Console.Write($"{doctor.GiveWorkHours}");
                    Console.WriteLine();
                    find = true;
                }
            }


            Console.WriteLine("Введите id нужного врача");
            bool findDoc = false;
            if (find)
            {
                int index = int.Parse(Console.ReadLine());
                while (!findDoc && index != 0)
                {
                    foreach (Doctor doctor in doctors)
                    {
                        if (doctor.GiveTakeID == index)
                        {
                            findDoc = true;
                            doctorForApp = doctor;
                        }
                    }
                    if (!findDoc)
                    {
                        Console.WriteLine("Неверный id, введите новый или 0");
                        index = int.Parse(Console.ReadLine());
                    }
                }
            }
            return findDoc;
        }
        static void Main(string[] args)
        {
            List<Doctor> doctors = new List<Doctor>();
            List<Patient> patients = new List<Patient>();
            List<Cabinet> cabinets = new List<Cabinet>();
            List<Appointment> appointments = new List<Appointment>();
            Shedule newShedule = new Shedule(appointments);

            //инициализация данных абстрактного класса
            int id = -1;
            string name = "";
            string surname = "";
            string patronymic = "";
            string pasport = "";
            string phoneNumber = "";

            //доп. данные для доктора и кабинета
            string speciality = "";
            int[] workDays = new int[7];
            int workHours = 0;
            DateTime birthday = new DateTime(1, 1, 1);

            int number = -1;

            //сбор пациентов, кабинетов, докторов. для дальнейшей работы
            using (StreamReader file = new StreamReader("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Patients.txt"))
            {
                string read = file.ReadLine();

                while (read != null)
                {
                    string[] patientData = read.Split(' ', ':', '.');
                    id = int.Parse(patientData[0]);
                    name = patientData[1];
                    surname = patientData[2];
                    patronymic = patientData[3];
                    pasport = patientData[4];
                    phoneNumber = patientData[5];
                    birthday = new DateTime(int.Parse(patientData[8]), int.Parse(patientData[7]), int.Parse(patientData[6]));
                    Patient newPatient = new Patient(id, name, surname, patronymic, pasport, phoneNumber, birthday);
                    patients.Add(newPatient);
                    read = file.ReadLine();
                }

            }
            using (StreamReader file = new StreamReader("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Doctors.txt"))
            {
                string read = file.ReadLine();

                while (read != null)
                {
                    string[] doctorData = read.Split(' ', ':', '.');
                    id = int.Parse(doctorData[0]);
                    name = doctorData[1];
                    surname = doctorData[2];
                    patronymic = doctorData[3];
                    pasport = doctorData[4];
                    phoneNumber = doctorData[5];
                    birthday = new DateTime(int.Parse(doctorData[8]), int.Parse(doctorData[7]), int.Parse(doctorData[6]));
                    speciality = doctorData[12];
                    for (int index = 13; index < doctorData.Length - 1; ++index)
                    {
                        workDays[index - 13] = int.Parse(doctorData[index]);
                    }
                    workHours = int.Parse(doctorData[doctorData.Length - 1]);

                    Doctor newDoctor = new Doctor(id, name, surname, patronymic, pasport, phoneNumber, birthday, speciality, workDays, workHours);
                    doctors.Add(newDoctor);
                    read = file.ReadLine();
                }
            }
            using (StreamReader file = new StreamReader("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Cabinets.txt"))
            {
                string read = file.ReadLine();

                while (read != null)
                {
                    string[] cabinetData = read.Split(' ');
                    id = int.Parse(cabinetData[0]);
                    number = int.Parse(cabinetData[1]);
                    speciality = cabinetData[2];

                    Cabinet newCabinet = new Cabinet(id, number, speciality);
                    cabinets.Add(newCabinet);
                    read = file.ReadLine();
                }
            }

            //1.сбор текущего расписания, НО 
            using (StreamReader file = new StreamReader("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Shedule.txt"))
            {
                string read = file.ReadLine();
                int doctorID = 0;
                int cabinetNumber = 0;
                int day = 0;
                int hour = 0;
                int minute = 0;

                int patientID = 0;

                while (read != null)
                {
                    string[] sheduleData = read.Split(' ');

                    doctorID = int.Parse(sheduleData[0]);
                    Doctor sheduleDoctor = null;
                    foreach (Doctor doctor in doctors)
                        if (doctor.GiveTakeID == doctorID)
                        {
                            sheduleDoctor = doctor;
                            break;
                        }

                    cabinetNumber = int.Parse(sheduleData[1]);
                    Cabinet sheduleCabinet = null;
                    foreach (Cabinet cabinet in cabinets)
                        if (cabinet.GiveTakeNumber == cabinetNumber)
                        {
                            sheduleCabinet = cabinet;
                            break;
                        }

                    day = int.Parse(sheduleData[2]);
                    hour = int.Parse(sheduleData[3]);
                    minute = int.Parse(sheduleData[4]);

                    Patient shedulePatient = null;
                    if (sheduleData.Length > 5)
                    {
                        patientID = int.Parse(sheduleData[5]);
                        foreach (Patient patient in patients)
                            if (patient.GiveTakeID == patientID)
                            {
                                shedulePatient = patient;
                                break;
                            }

                    }
                    //создание записи, добавление записи в расписание, добавление пациента, если он не null
                    Appointment sheduleAppointment = new Appointment(sheduleDoctor, sheduleCabinet, day, hour, minute);
                    newShedule.AddAppointment(sheduleAppointment);
                    if (shedulePatient != null)
                        newShedule.AddPatientInAppointment(shedulePatient, sheduleAppointment);
                    read = file.ReadLine();
                }

                if (newShedule.GetAppointments != null)
                    appointments = newShedule.GetAppointments;
            }

            //2.если расписание пустое - заполнить его записями врачей без пациентов и кабинетов
            if (newShedule.Count() == 0)
            {
                if (doctors.Count != 0)
                {
                    int docId = 0;
                    int day = 0;
                    int hour = 0;
                    int minute = 0;
                    for (int i = 0; i < doctors.Count; ++i)
                    {
                        docId = doctors[i].GiveTakeID;
                        workDays = doctors[i].GiveWorkDays;
                        workHours = doctors[i].GiveWorkHours;
                        for (int j = 0; j < 7; ++j)
                        {
                            if (workDays[j] != 0)
                            {
                                day = j;
                                if (workHours == 1)
                                {
                                    hour = 8;
                                    minute = 0;
                                    while (hour < 13)
                                    {
                                        Appointment appointment = new Appointment(doctors[i], null, day, hour, minute);
                                        if (minute != 30)
                                            minute = 30;
                                        else
                                            minute = 0;
                                        if (minute == 0)
                                            ++hour;
                                        newShedule.AddAppointment(appointment);
                                    }
                                }
                            }
                        }
                    }
                }
                if (newShedule.GetAppointments != null)
                    appointments = newShedule.GetAppointments;
            }

            int decide = 0;
            while (decide != 10)
            {
                Console.WriteLine("\nВведите, что вы хотите сделать: 1 - добавить доктора в базу, 2 - добавить кабинет в базу, \n" +
                "3 - добавить пациента в запись, 4 - удалить пациента из записи, \n" +
                "5 - удалить пациента из базы, 6 - удалить доктора из базы, \n" +
                "7 - вывести расписание определенного врача, 8 - заполнить кабинеты, 9 - сохранить, 10 - выйти");

                decide = Input();

                if (decide == (int)AdminDecide.AddNewDoctor)
                {
                    InputNewPerson(out name, out surname, out patronymic, out pasport, out phoneNumber, out birthday);

                    Console.WriteLine("Введите специальность врача");
                    speciality = Console.ReadLine();
                    Console.WriteLine("Введите рабочие дни врача врача начиная с понедельника, рабочие отмечая 1, а выходные - нулями");
                    for (int i = 0; i < 7; ++i)
                    {
                        workDays[i] = int.Parse(Console.ReadLine());

                    }
                    Console.WriteLine("Введите смену, в которую работает врач (1 или 2)");
                    workHours = int.Parse(Console.ReadLine());
                    if (doctors.Count != 0)
                        id = doctors[doctors.Count - 1].GiveTakeID + 1;
                    else
                        id = 1;

                    Doctor newDoctor = new Doctor(id, name, surname, patronymic, pasport, phoneNumber, birthday, speciality, workDays, workHours);

                    bool have = false;
                    foreach (Doctor doctor in doctors)
                    {
                        if (doctor.GiveTakePasport == newDoctor.GiveTakePasport)
                        {
                            have = true;
                            Console.WriteLine("Такой врач уже существует!\n");
                            break;
                        }
                    }

                    if (!have)
                        doctors.Add(newDoctor);

                    int docId = 0;
                    int day = 0;
                    int hour = 0;
                    int minute = 0;
                    for (int j = 0; j < 7; ++j)
                    {
                        if (workDays[j] != 0)
                        {
                            day = j;
                            if (workHours == 1)
                            {
                                hour = 8;
                                minute = 0;
                                while (hour < 13)
                                {
                                    Appointment appointment = new Appointment(newDoctor, null, day, hour, minute);
                                    if (minute != 30)
                                        minute = 30;
                                    else
                                        minute = 0;
                                    if (minute == 0)
                                        ++hour;

                                    if (appointment != null)
                                    {
                                        //appointments.Add(appointment);

                                        newShedule.AddAppointment(appointment);
                                    }
                                }
                            }
                        }
                    }
                }

                else if (decide == (int)AdminDecide.AddNewCabinet)
                {
                    Console.WriteLine("Введите номер кабинета");
                    number = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите специальность кабинета");
                    speciality = Console.ReadLine();

                    if (cabinets.Count != 0)
                        id = cabinets[cabinets.Count - 1].GiveTakeID + 1;
                    else
                        id = 1;

                    Cabinet newCabinet = new Cabinet(id, number, speciality);

                    bool have = false;
                    foreach (Cabinet cabinet in cabinets)
                    {
                        if (cabinet.GiveTakeNumber == newCabinet.GiveTakeNumber)
                        {
                            have = true;
                            Console.WriteLine("Такой кабинет уже существует!\n");
                            break;
                        }
                    }

                    if (!have)
                        cabinets.Add(newCabinet);
                }

                else if (decide == (int)AdminDecide.AddPatientInAppointment)
                {
                    Patient newPatient = null;
                    FindPatient(patients, out newPatient);


                    Doctor doctorForApp = null;
                    bool findDoc = FindDoctor(doctors, out doctorForApp);


                    if (findDoc)
                    {
                        Console.WriteLine("Введите день записи (понедельник - 0)");
                        int day = int.Parse(Console.ReadLine());

                        bool successday = false;
                        while (!successday && day != -1)
                        {
                            int[] docdays = doctorForApp.GiveWorkDays;

                            if (docdays[day] != 0)
                            {
                                successday = true;
                            }
                            if (!successday)
                            {
                                Console.WriteLine("Доктор не работает в этот день");
                                Console.WriteLine("Введите другой день или нажмите -1, чтобы выйти");
                                day = int.Parse(Console.ReadLine());
                            }
                        }
                        Console.WriteLine("Введите час записи");
                        int hour = int.Parse(Console.ReadLine());

                        bool successhour = false;
                        while (!successhour && hour != 0)
                        {
                            int dochours = doctorForApp.GiveWorkHours;

                            if (dochours == 1 && hour >= 8 && hour <= 13)
                            {
                                successhour = true;
                            }
                            if (dochours == 2 && hour >= 14 && hour <= 18)
                            {
                                successhour = true;
                            }
                            if (!successhour)
                            {
                                Console.WriteLine("Доктор не работает в этот час");
                                Console.WriteLine("Введите другой час или нажмите 0, чтобы выйти");
                                hour = int.Parse(Console.ReadLine());
                            }
                        }

                        Console.WriteLine("Введите минуты записи");
                        int minutes = int.Parse(Console.ReadLine());

                        bool successminutes = false;
                        while (!successminutes && minutes != 1)
                        {
                            if (minutes == 0 || minutes == 30)
                            {
                                foreach (Appointment appointment in appointments)
                                    if (appointment.GiveTakeDoctor.GiveTakeID == doctorForApp.GiveTakeID &&
                                        appointment.GiveTakeDay == day &&
                                        appointment.GiveTakeHour == hour &&
                                        appointment.GiveTakeMinute == minutes &&
                                        appointment.GiveTakePatient == null)
                                        successminutes = true;
                                foreach (Appointment appointment in appointments)
                                    if (appointment.GiveTakePatient != null &&
                                        appointment.GiveTakeDay == day &&
                                        appointment.GiveTakeHour == hour &&
                                        appointment.GiveTakeMinute == minutes)
                                        if (appointment.GiveTakePatient.GiveTakeID == newPatient.GiveTakeID)
                                        {
                                            successminutes = false;
                                            Console.WriteLine($"Пациент записан на это время к другому врачу! Его id для проверки - {newPatient.GiveTakeID}");
                                        }
                            }
                            if (!successminutes)
                            {
                                Console.WriteLine("Доктор занят в это время или оно введено не корректно или пациент уже записан");
                                Console.WriteLine("Введите другое время или нажмите 1, чтобы выйти");
                                minutes = int.Parse(Console.ReadLine());
                            }
                        }

                        if (successday && successhour && successminutes)
                        {
                            foreach (Appointment appointment in appointments)
                            {
                                if (appointment.GiveTakeDoctor.GiveTakeID == doctorForApp.GiveTakeID &&
                                        appointment.GiveTakeDay == day &&
                                        appointment.GiveTakeHour == hour &&
                                        appointment.GiveTakeMinute == minutes)
                                {

                                    if (appointment.GiveTakeCabinet != null)
                                    {
                                        
                                        newShedule.AddPatientInAppointment(newPatient, appointment);
                                        appointments = newShedule.GetAppointments;
                                        Console.WriteLine("Запись проведена успешно!");
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Произошла ошибка, у варча не назначен кабинет! Сохраните изменения и повторите запись пациента");
                                }
                            }
                        }
                    }
                    
                }

                else if (decide == (int)AdminDecide.DeletePatientInAppointment)
                {
                    Patient deletePatient = null;
                    FindPatient(patients, out deletePatient);
                    
                    Console.WriteLine("Введите день записи");
                    int day = int.Parse(Console.ReadLine());

                    bool successday = false;
                    while (!successday && day != -1)
                    {
                        foreach (Appointment appointment in appointments)
                            if (appointment.GiveTakePatient != null && appointment.GiveTakePatient.GiveTakeID == deletePatient.GiveTakeID &&
                                   appointment.GiveTakeDay == day)
                            {
                                successday = true;
                            }
                        if (!successday)
                        {
                            Console.WriteLine("Пациент не записан в этот день");
                            Console.WriteLine("Введите другой день или нажмите -1, чтобы выйти");
                            day = int.Parse(Console.ReadLine());
                        }
                    }

                    Console.WriteLine("Введите час записи");
                    int hour = int.Parse(Console.ReadLine());

                    bool successhour = false;
                    while (!successhour && hour != 0)
                    {
                        foreach (Appointment appointment in appointments)
                            if (appointment.GiveTakePatient != null && appointment.GiveTakePatient.GiveTakeID == deletePatient.GiveTakeID &&
                                appointment.GiveTakeDay == day &&
                                appointment.GiveTakeHour == hour)
                                successhour = true;
                        if (!successhour)
                        {
                            Console.WriteLine("Пациент не записан в этот час");
                            Console.WriteLine("Введите другой час или нажмите 0, чтобы выйти");
                            hour = int.Parse(Console.ReadLine());
                        }
                    }

                    Console.WriteLine("Введите минуты записи");
                    int minutes = int.Parse(Console.ReadLine());

                    Appointment appointment1 = null;
                    bool successminutes = false;
                    while (!successminutes && minutes != 1)
                    {
                        if (minutes == 0 || minutes == 30)
                        {
                            foreach (Appointment appointment in appointments)
                                if (appointment.GiveTakePatient != null && appointment.GiveTakePatient.GiveTakeID == deletePatient.GiveTakeID &&
                                    appointment.GiveTakeDay == day &&
                                    appointment.GiveTakeHour == hour &&
                                    appointment.GiveTakeMinute == minutes)
                                {
                                    appointment1 = appointment;
                                    successminutes = true;
                                }
                        }
                        if (!successminutes)
                        {
                            Console.WriteLine("Пациент не записан в это время");
                            Console.WriteLine("Введите другое время или нажмите 1, чтобы выйти");
                            minutes = int.Parse(Console.ReadLine());
                        }
                    }

                    if (successday && successhour && successminutes)
                    {
                        newShedule.DeletePatientInAppointment(deletePatient, appointment1);
                        appointments = newShedule.GetAppointments;
                        Console.WriteLine("Удаление прошло успешно!");
                    }
                    else
                        Console.WriteLine("Пациент не удален из записи! Повторите попытку!");

                }

                else if (decide == (int)AdminDecide.DeletePatient)
                {
                    Patient deletePatient = null;
                    FindPatient(patients, out deletePatient);
                    //Console.WriteLine("Введите id пациента");
                    //int findId = int.Parse(Console.ReadLine());
                    //for (int i = 0; i < patients.Count; ++i)
                    //{
                    //    if (patients[i].GiveTakeID == findId)
                    //    {
                    //        patients.RemoveAt(i);
                    //        deletePatient = patients[i];
                    //        break;
                    //    }
                    //}

                    newShedule.DeletePatAppointment(deletePatient);
                    appointments = newShedule.GetAppointments;
                }

                else if (decide == (int)AdminDecide.DeleteDoctor)//удаление доктора и всех записей с ним
                {
                    Doctor deleteDoctor = null;
                    bool find = FindDoctor(doctors, out deleteDoctor);
                    //Console.WriteLine("Введите id доктора");
                    //int findId = int.Parse(Console.ReadLine());
                    //for (int i = 0; i < doctors.Count; ++i)
                    //{
                    //    if (doctors[i].GiveTakeID == findId)
                    //    {
                    //        doctors.RemoveAt(i);
                    //        deleteDoctor = doctors[i];
                    //        break;
                    //    }
                    //}
                    if (find)
                    {
                        newShedule.DeleteDocAppointment(deleteDoctor);
                        appointments = newShedule.GetAppointments;
                    }
                    else
                    {
                        Console.WriteLine("Доктор не найден");
                    }

                }

                else if (decide == (int)AdminDecide.ShowShedule)
                {
                    Doctor appForDoctor = null;
                    bool find = FindDoctor(doctors, out appForDoctor);

                    if (find)
                    {
                        Console.WriteLine("Doctor ID, Cabinet Number, Patient ID, day, hour, minute");
                        foreach (Appointment appointment in appointments)
                        {
                            if (appointment.GiveTakeDoctor.GiveTakeID == appForDoctor.GiveTakeID)
                            {
                                Console.Write($"{appointment.GiveTakeDoctor.GiveTakeID}, ");

                                if (appointment.GiveTakeCabinet != null)
                                    Console.Write($"{appointment.GiveTakeCabinet.GiveTakeNumber}, ");
                                else
                                    Console.Write("NO, ");

                                if (appointment.GiveTakePatient != null)
                                    Console.Write($"{appointment.GiveTakePatient.GiveTakeID}, ");
                                else
                                    Console.Write("NO, ");
                                Console.Write($"{appointment.GiveTakeDay}, ");
                                Console.Write($"{appointment.GiveTakeHour}, ");
                                Console.Write($"{appointment.GiveTakeMinute} ");

                                Console.WriteLine();
                            }
                        }
                    }
                    else
                        Console.WriteLine("Врач не найден");
                }

                else if (decide == (int)AdminDecide.AddCabinetsInShedule)
                {
                    Doctor doctorForCabinet = null;
                    bool successdoc = FindDoctor(doctors, out doctorForCabinet);
                    Console.WriteLine("Введите номер дня его работы (понедельник - 0)");
                    int day = int.Parse(Console.ReadLine());

                    if (successdoc)
                    {
                        bool successcab = false;
                        Console.WriteLine("Введите номер кабинета");
                        int num = int.Parse(Console.ReadLine());
                        Cabinet cabinetForDoctor = null;
                        foreach (Cabinet cabinet in cabinets)
                        {
                            if (cabinet.GiveTakeNumber == num)
                            {
                                cabinetForDoctor = cabinet;
                                successcab = true;
                            }
                        }

                        bool Cab = false;//если кабинет не используется в этот день, то добавить
                        if (successcab)
                        {
                            foreach (Appointment appointment in appointments)
                            {
                                if (appointment.GiveTakeDay == day && appointment.GiveTakeCabinet != null)
                                    if (appointment.GiveTakeCabinet.GiveTakeNumber == num)
                                        Cab = true;
                            }
                        }
                        else
                            Console.WriteLine("Неверный номер кабинета");

                        bool success = false;
                        if (!Cab && successcab && successdoc)
                        {
                            foreach (Appointment appointment in appointments)
                            {
                                if (appointment.GiveTakeDoctor.GiveTakeID == doctorForCabinet.GiveTakeID && appointment.GiveTakeDay == day && appointment.GiveTakeCabinet == null)
                                {
                                    appointment.GiveTakeCabinet = cabinetForDoctor;
                                    success = true;
                                }
                            }
                        }

                        if (!success)
                            Console.WriteLine("Кабинет не добавлен");
                        newShedule = new Shedule(appointments);
                    }
                }

                else if (decide == (int)AdminDecide.Save)
                {
                    SaveAll(doctors, patients, cabinets, newShedule);
                }
            }
        }
        static void SaveAll(List<Doctor> doctors, List<Patient> patients, List<Cabinet> cabinets, Shedule newShedule)
        {
            //занесение в файлы конечной информации перед выходом или СОХРАНЕНИЕ ИНФОРМАЦИИ
            using (StreamWriter file = new StreamWriter("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Patients.txt", false))
            {
                foreach (Patient patient in patients)
                {
                    file.Write($"{patient.GiveTakeID} {patient.GiveTakeName} {patient.GiveTakeSurName} {patient.GiveTakePatronymic} " +
                        $"{patient.GiveTakePasport} {patient.GiveTakePhoneNumber} {patient.GiveTakeBirthday}");
                    file.WriteLine();
                }
            }
            using (StreamWriter file = new StreamWriter("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Doctors.txt", false))
            {
                foreach (Doctor doctor in doctors)
                {
                    file.Write($"{doctor.GiveTakeID} {doctor.GiveTakeName} {doctor.GiveTakeSurName} {doctor.GiveTakePatronymic} " +
                        $"{doctor.GiveTakePasport} {doctor.GiveTakePhoneNumber} {doctor.GiveTakeBirthday} {doctor.GiveTakeSpeciality} ");
                    for (int i = 0; i < 7; ++i)
                        file.Write($"{doctor.GiveWorkDays[i]} ");
                    file.Write($"{doctor.GiveWorkHours}");
                    file.WriteLine();
                }

            }
            using (StreamWriter file = new StreamWriter("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Cabinets.txt", false))
            {
                foreach (Cabinet cabinet in cabinets)
                {
                    file.Write($"{cabinet.GiveTakeID} {cabinet.GiveTakeNumber} {cabinet.GiveTakeSpeciality}");
                    file.WriteLine();
                }
            }

            //занесение расписания 
            using (StreamWriter file = new StreamWriter("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Shedule.txt", false))
            {
                foreach (Appointment appointment in newShedule.GetAppointments)
                {
                    if (appointment.GiveTakeCabinet != null)
                        file.Write($"{appointment.GiveTakeDoctor.GiveTakeID} {appointment.GiveTakeCabinet.GiveTakeNumber}" +
                            $" {appointment.GiveTakeDay} {appointment.GiveTakeHour} {appointment.GiveTakeMinute}");
                    else if (appointment.GiveTakeCabinet == null)
                        file.Write($"{appointment.GiveTakeDoctor.GiveTakeID} 0 " +
                            $"{appointment.GiveTakeDay} {appointment.GiveTakeHour} {appointment.GiveTakeMinute}");
                    if (appointment.GiveTakePatient != null)
                        file.Write($" { appointment.GiveTakePatient.GiveTakeID}");
                    file.WriteLine();
                }
            }
        }
    }
}
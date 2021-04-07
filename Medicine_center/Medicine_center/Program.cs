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
            DeleteCabinet,
            ShowShedule
        }

        static void InputNewPerson(out string name, out string surname, out string patronymic, out string pasport,
            out string phoneNumber, out DateTime birthday)
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
            Console.WriteLine("Введите дату рождения в виде трех чисел");
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            birthday = new DateTime(day, month, year);
        }
        static int Input()
        {
            int N;
            bool input = int.TryParse(Console.ReadLine(), out N);
            while (!input || N < 0 || N > 8)
            {
                Console.WriteLine("Введите корректное значение");
                input = int.TryParse(Console.ReadLine(), out N);
            }
            return N;
        }
        static void Main(string[] args)
        {
            List<Doctor> doctors = new List<Doctor>();
            List<Patient> patients = new List<Patient>();
            List<Cabinet> cabinets = new List<Cabinet>();
            Shedule newShedule = new Shedule();

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
            DateTime birthday = new DateTime(0, 0, 0);

            int number = -1;

            using (StreamReader file = new StreamReader("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Patients.txt", true))
            {
                string read = file.ReadLine();
                string[] patientData = read.Split(' ');

                while (read != "")
                {
                    id = int.Parse(patientData[0]);
                    name = patientData[1];
                    surname = patientData[2];
                    patronymic = patientData[3];
                    pasport = patientData[4];
                    phoneNumber = patientData[5];
                    birthday = new DateTime(int.Parse(patientData[6]), int.Parse(patientData[7]), int.Parse(patientData[8]));


                    Patient newPatient = new Patient(id, name, surname, patronymic, pasport, phoneNumber, birthday);
                    patients.Add(newPatient);
                }

            }
            using (StreamReader file = new StreamReader("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Doctors.txt", true))
            {
                string read = file.ReadLine();
                string[] doctorData = read.Split(' ');

                while (read != "")
                {
                    id = int.Parse(doctorData[0]);
                    name = doctorData[1];
                    surname = doctorData[2];
                    patronymic = doctorData[3];
                    pasport = doctorData[4];
                    phoneNumber = doctorData[5];
                    birthday = new DateTime(int.Parse(doctorData[6]), int.Parse(doctorData[7]), int.Parse(doctorData[8]));
                    speciality = doctorData[9];
                    for (int index = 10; index < doctorData.Length - 1; ++index)
                    {
                        workDays[index - 10] = int.Parse(doctorData[index]);
                    }
                    workHours = int.Parse(doctorData[doctorData.Length - 1]);

                    Doctor newDoctor = new Doctor(id, name, surname, patronymic, pasport, phoneNumber, birthday, speciality, workDays, workHours);
                    doctors.Add(newDoctor);
                }

            }
            using (StreamReader file = new StreamReader("C:/Users/Кристина/Documents/University/Medicine_center/Medicine_center/Cabinets.txt", true))
            {
                string read = file.ReadLine();
                string[] cabinetData = read.Split(' ');

                while (read != "")
                {
                    id = int.Parse(cabinetData[0]);
                    number = int.Parse(cabinetData[1]);
                    speciality = cabinetData[2];

                    Cabinet newCabinet = new Cabinet(id, number, speciality);
                    cabinets.Add(newCabinet);
                }
            }
                
            

            Console.WriteLine("Введите, что вы хотите сделать: 1 - добавить доктора в базу, 2 - добавить кабинет в базу, \n" +
            "3 - добавить пациента в запись, 4 - удалить пациента из записи, \n" +
            "5 - удалить пациента из базы, 6 - удалить доктора из базы, 7 - удалить кабинет из базы, \n" +
            "8 - вывести расписание");
            int decide = Input();
           
            if (decide == (int)AdminDecide.AddNewDoctor)
            {
                InputNewPerson(out name, out surname, out patronymic, out pasport, out phoneNumber, out birthday);
                Console.WriteLine("Введите специальность врача");
                speciality = Console.ReadLine();
                Console.WriteLine("Введите количество рабочих дней врача");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите рабочие дни врача врача");
                for (int i = 0; i < n; ++i)
                {
                    workDays[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Введите смену, в которую работает врач (1 или 2)");
                workHours = int.Parse(Console.ReadLine());
                id = doctors[doctors.Count - 1].GiveTakeID + 1;

                Doctor newDoctor = new Doctor(id, name, surname, patronymic, pasport, phoneNumber, birthday, speciality, workDays, workHours);
                
                bool have = false;
                foreach (Doctor doctor in doctors)
                {
                    if (doctor.GiveTakePasport == newDoctor.GiveTakePasport)
                    {
                        have = true;
                        break;
                    }
                }

                if (!have)
                    doctors.Add(newDoctor);
                    
            }

            else if (decide == (int)AdminDecide.AddNewCabinet)
            {
                Console.WriteLine("Введите номер кабинета");
                number = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите специальность кабинета");
                speciality = Console.ReadLine();
                
                id = cabinets[cabinets.Count - 1].GiveTakeID + 1;

                Cabinet newCabinet = new Cabinet(id, number, speciality);

                bool have = false;
                foreach (Cabinet cabinet in cabinets)
                {
                    if (cabinet.GiveTakeNumber == newCabinet.GiveTakeNumber)
                    {
                        have = true;
                        break;
                    }
                }

                if (!have)
                    cabinets.Add(newCabinet);
            }

        }
    }
}

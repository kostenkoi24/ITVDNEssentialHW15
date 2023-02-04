using System;
using System.Collections;
using System.Linq;

namespace Homework15_2
{
    class Program : WorkerComparer
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Worker[] workers = new Worker[2]; //что бы долго не вводить сотрудников 2 вместо 5


            InputWorkers(workers);

            ShowWorkers(workers);

            Console.WriteLine("Введите стаж работы для поиска:");

            try
            {
                int.TryParse(Console.ReadLine(), out int yearsExperience);
                SearchWorker(workers, yearsExperience);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            

                       

            Console.ReadKey();
        }


        static void InputWorkers(Worker[] workers)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                Console.WriteLine($"Введите ФИО сотрудника: ");
                workers[i].name = Console.ReadLine();

                Console.WriteLine($"Введите должность: ");
                workers[i].position = Console.ReadLine();

                bool error = false;

                do
                {
                    Console.WriteLine($"Введите дату приема на работу в формате DD/MM/YYYY: ");
                    string userInput = Console.ReadLine();
                    try
                    {
                        workers[i].yearBeginWork = DateTime.Parse(userInput);

                        
                        error = false;
                    }
                    catch (Exception e)
                    {
                        error = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Вы ввели не корректный формат даты {userInput} - {e.Message}");
                        Console.ResetColor();
                    }
                }
                while (error);


            }

            Array.Sort(workers, new WorkerComparer());

        }

        static void ShowWorkers(Worker[] workers)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{new string('-', 15)} Ваши сотрудники {new string('-', 15)}"  );
            foreach (Worker worker in workers)
            {
                Console.WriteLine($"ФИО сотрудника: {worker.name} ");
                Console.WriteLine($"Должность: {worker.position}");
                Console.WriteLine($"Дату приема на работу: {worker.yearBeginWork.Date} ");
            }
            Console.ResetColor();
        }

        static void SearchWorker(Worker[] workers, int yearsExperience)
        {
            Worker[] result = Array.FindAll(workers, element => (DateTime.Now.Date - element.yearBeginWork.Date).Days >= (DateTime.Now.Date - DateTime.Now.AddYears(-yearsExperience).Date).Days);

            if (result.Length > 0)
            {
                ShowWorkers(result);
            }
            else
            {
                Console.WriteLine("Сотрудники с подобным стажем отсутствуют");
            }
        }

    }

    class WorkerComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(((Worker)x).name, ((Worker)y).name);
        }
    }
}

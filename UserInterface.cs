using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class UserInterface
    {
        public static int ReadInt(string message)
        {
            int number;
            bool isConvert;
            do
            {
                Console.WriteLine(message);
                isConvert = int.TryParse(Console.ReadLine(), out number);
                if (!isConvert)
                {
                    Console.WriteLine("Ошибка при вводе целого числа");
                }
            } while (!isConvert);
            return number;
        }
        public static bool IsNumberInDiapason(int number, int left, int right) => number >= left && number <= right;

        public static int ReadIntAndCheckDiapason(string message, int left, int right)
        {
            int number;
            do
            {
                number = ReadInt(message);
                if (!IsNumberInDiapason(number, left, right))
                    Console.WriteLine($"Число должно быть больше {left} и меньше {right}");
            } while (number < left || number > right);
            return number;
        }

        // Функция для поиска самого старшего студента с GPA > 8
        public static Studentcs FindOldestStudentWithHighGPA(StudentArray students)
        {
            Studentcs oldestStudent = null;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Gpa > 8)
                {
                    if (oldestStudent == null || students[i].Age > oldestStudent.Age)
                    {
                        oldestStudent = students[i];
                    }
                }
            }
            return oldestStudent;
        }

        public static void Main(string[] args)
        {
            int answer;
            int readAnsw;
            bool isAnswCorr;

            do
            {
                Console.WriteLine("\n1. Работа со случайным массивом");
                Console.WriteLine("2. Работа с ручным массивом");
                Console.WriteLine("3. Student.cs");
                Console.WriteLine("4. Выход");

                do
                {
                    isAnswCorr = int.TryParse(Console.ReadLine(), out answer);
                    if (answer < 1) isAnswCorr = false;
                    if (!isAnswCorr)
                        Console.WriteLine("Ошибка, попробуйте еще раз");
                } while (!isAnswCorr);

                switch (answer)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("\n1. Создать массив и вывести");
                            Console.WriteLine("2. Назад");

                            readAnsw = ReadIntAndCheckDiapason("Выберите действие", 1, 2);
                            switch (readAnsw)
                            {
                                case 1:

                                    StudentArray students1 = new StudentArray(5);
                                    Console.WriteLine("Студенты в массиве students1:");
                                    students1.PrintStudents();

   
                                    StudentArray students2 = new StudentArray(students1);
                                    Console.WriteLine("\nСтуденты в массиве students2 (копия students1):");
                                    students2.PrintStudents();

                                    // Демонстрация работы индексатора
                                    try
                                    {
                                        Console.WriteLine("\nДемонстрация работы индексатора:");
                                        Console.WriteLine("Элемент с индексом 1: " + students1[1]);
                                        students1[1] = new Studentcs("Loshara2010", 20, 5.0);
                                        Console.WriteLine("Элемент с индексом 1 после изменения: " + students1[1]);
                                        Console.WriteLine("Попытка доступа к элементу с индексом 10: " + students1[10]);
                                    }
                                    catch (IndexOutOfRangeException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    
                                    // Проверка наличия студентов с GPA > 8
                                    bool hasHighGPAStudents = students1.HasStudentsWithHighGPA();
                                    Console.WriteLine("\nЕсть ли студенты с GPA > 8: " + hasHighGPAStudents);

                                    // Проверка наличия студентов старше определенного возраста
                                    bool hasOlderStudents = students1.HasStudentsOlderThan(22);
                                    Console.WriteLine("Есть ли студенты старше 22 лет: " + hasOlderStudents);

                                    // Поиск самого старшего студента с GPA > 8
                                    Studentcs oldestStudent = FindOldestStudentWithHighGPA(students1);
                                    if (oldestStudent != null)
                                    {
                                        Console.WriteLine("\nСамый старший студент с GPA > 8: " + oldestStudent);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nСтудентов с GPA > 8 не найдено.");
                                    }


                                    Console.WriteLine("\nКоличество созданных объектов: " + StudentArray.GetObjectCount());
                                    Console.WriteLine("Количество созданных коллекций: " + StudentArray.GetCollectionCount());

                                    break;

                            }
                        } while (readAnsw != 2);
                        break;

                    case 2: 
                        do
                        {
                            Console.WriteLine("\n1. Создать ручной массив");
                            Console.WriteLine("2. Назад");

                            readAnsw = ReadIntAndCheckDiapason("Выберите действие", 1, 2);

                            switch (readAnsw)
                            {
                                case 1:
                                    int size = ReadIntAndCheckDiapason("Введите количество студентов", 1, 5);
                                    StudentArray students1 = new StudentArray(size);
   
                                        for (int j = 0; j < size; j++)
                                        {
                                            try
                                            {
                                                Console.WriteLine($"Введите имя {j+1}-ого студента: ");
                                                students1[j].Name = Console.ReadLine();

                                                Console.WriteLine($"Введите возраст {j+1}-ого студента: ");
                                                students1[j].Age = int.Parse(Console.ReadLine());

                                                Console.WriteLine($"Введите GPA {j+1}-ого студента: ");
                                                students1[j].Gpa = double.Parse(Console.ReadLine());

                                            }   
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Ошибка при вводе элмента, попробуйте еще раз");
                                                j--;
                                            }
                                        }
                                    Console.WriteLine("\nСтуденты в массиве students1:");
                                    students1.PrintStudents();

                                    // Создание копии
                                    StudentArray students2 = new StudentArray(students1);
                                    Console.WriteLine("\nСтуденты в массиве students2 (копия students1):");
                                    students2.PrintStudents();

                                    try
                                    {
                                        Console.WriteLine("\nДемонстрация работы индексатора:");
                                        Console.WriteLine("Элемент с индексом 1: \n" + students1[1]);
                                        students1[1] = new Studentcs("Loshara2010", 20, 5.0);
                                        Console.WriteLine("\nЭлемент с индексом 1 после изменения: " + students1[1]);
                                        Console.WriteLine("Попытка доступа к элементу с индексом 10: " + students1[10]);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Выход за пределы массива");
                                    }

                                    // Проверка наличия студентов с GPA > 8
                                    bool hasHighGPAStudents = students1.HasStudentsWithHighGPA();
                                    Console.WriteLine("\nЕсть ли студенты с GPA > 8: " + hasHighGPAStudents);

                                    // Проверка наличия студентов старше определенного возраста
                                    bool hasOlderStudents = students1.HasStudentsOlderThan(22);
                                    Console.WriteLine("Есть ли студенты старше 22 лет: " + hasOlderStudents);

                                    // Поиск самого старшего студента с GPA > 8
                                    Studentcs oldestStudent = FindOldestStudentWithHighGPA(students1);
                                    if (oldestStudent != null)
                                    {
                                        Console.WriteLine("\nСамый старший студент с GPA > 8: " + oldestStudent);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nСтудентов с GPA > 8 не найдено.");
                                    }

                                    // Подсчет количества созданных объектов и коллекций
                                    Console.WriteLine("\nКоличество созданных объектов: " + StudentArray.GetObjectCount());
                                    Console.WriteLine("Количество созданных коллекций: " + StudentArray.GetCollectionCount());

                                    break;
                            }
                        } while (readAnsw != 2);
                        
                        break;

                    case 3:


                        Console.WriteLine($"Количество созданных объектов: {Studentcs.GetObjectCount()}");
                        Studentcs student1 = new Studentcs("иван", 19, 4.5);

                        Console.WriteLine("Создан объект student1");
                        Console.WriteLine($"Количество созданных объектов: {Studentcs.GetObjectCount()}");
                        Studentcs student2 = new Studentcs("мария", 21, 6.5);

                        Console.WriteLine("Создан объект student2");
                        Console.WriteLine($"Количество созданных объектов: {Studentcs.GetObjectCount()}");


                        Console.WriteLine("\nСравнение студентов с использованием метода класса:");
                        Console.WriteLine(student1.CompareStudents(student2));


                        Console.WriteLine("\nСравнение студентов с использованием статической функции:");
                        Console.WriteLine(Studentcs.CompareStudentsStatic(student1, student2));


                        student1 = ~student1;
                        Console.WriteLine("\nПосле применения операции ~:");
                        Console.WriteLine($"{student1}");

                        student1++;
                        Console.WriteLine("\nПосле применения операции ++:");
                        Console.WriteLine($"{student1}"); ;


                        int course = (int)student1;
                        Console.WriteLine("\nНомер курса студента 1: " + course);


                        bool isSatisfactory = student1;
                        Console.WriteLine("\nСтудент 1 имеет удовлетворительные оценки: " + isSatisfactory);


                        Studentcs student3 = student1 % "Алексей";
                        Console.WriteLine("\nСоздан новый студент с другим именем:");
                        Console.WriteLine($"{student3}"); ;


                        student2 = student2 - 1;
                        Console.WriteLine("\nПосле уменьшения GPA студента 2 на 1.0:");
                        Console.WriteLine($"{student2}"); ;


                        Console.WriteLine("\nСравнение student1 и student2:");
                        if (student1.Equals(student2) == false)
                        {
                            Console.WriteLine("Не совпадают");
                        }
                        else
                        {
                            Console.WriteLine("Совпадают");
                        }
                        break;

       
                }

            } while (answer != 4);
        }
    }
}

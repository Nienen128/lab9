using Student;
using System.Threading.Channels;

namespace Student
{
    public class StudentArray
    {
        private Studentcs[] students;
        private static int objectCount = 0;
        private static int collectionCount = 0;
        

        public int Length => students.Length;

        // Конструктор без параметров
        public StudentArray()
        {
            students = [];
            objectCount++;
            collectionCount++;
        }

        // Конструктор с параметрами
        public StudentArray(int size)
        {
            students = new Studentcs[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                students[i] = new Studentcs($"Student{i + 1}", random.Next(17, 26), random.NextDouble() * 10);
            }
            objectCount++;
            collectionCount++;
        }

        // Конструктор копирования
        public StudentArray(StudentArray other)
        {
            students = new Studentcs[other.students.Length];
            for (int i = 0; i < other.students.Length; i++)
            {
                students[i] = new Studentcs(other.students[i].Name, other.students[i].Age, other.students[i].Gpa);
            }
            objectCount++;
            collectionCount++;
        }

        // Метод для просмотра элементов массива
        public void PrintStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student}");
            }
        }

        // Индексатор для доступа к элементам коллекции
        public Studentcs this[int index]
        {
            get
            {
                if (index < 0 || index >= students.Length)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы массива");
                return students[index];
            }
            set
            {
                if (index < 0 || index >= students.Length)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы массива");
                students[index] = value;
            }
        }


        public static int GetObjectCount()
        {
            return objectCount;
        }

 
        public static int GetCollectionCount()
        {
            return collectionCount;
        }

        // Метод для проверки, есть ли студенты с GPA > 8
        public bool HasStudentsWithHighGPA()
        {
            foreach (var student in students)
            {
                if (student.Gpa > 8)
                    return true;
            }
            return false;
        }

        // Метод для проверки, есть ли студенты старше определенного возраста
        public bool HasStudentsOlderThan(int age)
        {
            foreach (var student in students)
            {
                if (student.Age > age)
                    return true;
            }
            return false;
        }
    }
}


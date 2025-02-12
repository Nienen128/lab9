using System.Threading.Channels;

namespace Student
{

    public class Studentcs
    {
        private string name;
        private int age;
        private double gpa;

        static int Objects;

        // Конструктор без параметров
        public Studentcs()
        {
            name = "";
            age = 0;
            gpa = 0.0;
            Objects++;
        }

        // Конструктор с параметрами
        public Studentcs(string name, int age, double gpa)
        {
            this.name = name;
            this.age = age;
            this.gpa = gpa;
            Objects++;
        }

        // Свойство к имени
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Свойство к возрасту
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        // Свойство к GPA
        public double Gpa
        {
            get { return gpa; }
            set { gpa = value; }
        }

        // Метод для сравнения студентов
        public string CompareStudents(Studentcs other)
        {
            string ageComparison = CompareAges(other);
            string gpaComparison = CompareGpas(other);
            return $"{ageComparison}. {gpaComparison}";
        }

        // метод для сравнения возрастов
        public string CompareAges(Studentcs other)
        {
            if (this.age < other.age)
                return $"{this.name} младше {other.name}";
            else if (this.age > other.age)
                return $"{this.name} старше {other.name}";
            else
                return $"{this.name} ровесник {other.name}";
        }

        // метод для сравнения GPA
        public string CompareGpas(Studentcs other)
        {
            if (this.gpa < other.gpa)
                return $"GPA {this.name} ниже GPA {other.name}";
            else if (this.gpa > other.gpa)
                return $"GPA {this.name} выше GPA {other.name}";
            else
                return $"GPA {this.name} равен GPA {other.name}";
        }

        // функция для сравнения студентов
        public static string CompareStudentsStatic(Studentcs student1, Studentcs student2)
        {
            string ageComparison = CompareAgesStatic(student1, student2);
            string gpaComparison = CompareGpasStatic(student1, student2);
            return $"{ageComparison}. {gpaComparison}";
        }

        // функция для сравнения возрастов
        public static string CompareAgesStatic(Studentcs student1, Studentcs student2)
        {
            if (student1.age < student2.age)
                return $"{student1.name} младше {student2.name}";
            else if (student1.age > student2.age)
                return $"{student1.name} старше {student2.name}";
            else
                return $"{student1.name} ровесник {student2.name}";
        }

        // функция для сравнения GPA
        public static string CompareGpasStatic(Studentcs student1, Studentcs student2)
        {
            if (student1.gpa < student2.gpa)
                return $"GPA {student1.name} ниже GPA {student2.name}";
            else if (student1.gpa > student2.gpa)
                return $"GPA {student1.name} выше GPA {student2.name}";
            else
                return $"GPA {student1.name} равен GPA {student2.name}";
        }

        // Переопределение метода ToString для вывода информации
        public override string ToString()
        {
            return $"Студент(Имя: {name}, Возраст: {age}, GPA: {gpa})";
        }

        public static int GetObjectCount()
        {
            return Objects ;
        }

        
        public static Studentcs operator ~(Studentcs student)
        {
            if (student.name.Length > 0)
            {
                student.name = char.ToUpper(student.name[0]) + student.name.Substring(1).ToLower();
            }
            return student;
        }


        public static Studentcs operator ++(Studentcs student)
        {
            student.age++;
            return student;
        }

        public static explicit operator int(Studentcs student)
        {
       
            if (student.age >= 18 && student.age <= 22)
                return student.age - 17; // Номер курса
            else
                return -1; // Студент слишком стар
        }


        public static implicit operator bool(Studentcs student)
        {
            return student.gpa < 6;
        }


        public static Studentcs operator %(Studentcs student, string newName)
        {
            return new Studentcs(newName, student.age, student.gpa);
        }


        public static Studentcs operator -(Studentcs student, double d)
        {
            student.gpa = Math.Max(student.gpa - d, 0);
            return student;
        }

        public override bool Equals(object obj)
        {
            if (obj is Studentcs other)
            {
                return this.name == other.name && this.age == other.age && this.gpa == other.gpa;
            }
            return false;
        }

    }
}




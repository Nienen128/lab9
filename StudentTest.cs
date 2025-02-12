using Student;
namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void StudentDefaultConstructor()
        {
            // Arrange & Act
            var student = new Studentcs();

            // Assert
            Assert.AreEqual("", student.Name); 
            Assert.AreEqual(0, student.Age);   
            Assert.AreEqual(0.0, student.Gpa); 
        }

       
        [TestMethod]
        public void StudentParameterConstructor()
        {
            // Arrange
            string name = "Иван";
            int age = 20;
            double gpa = 4.5;

            // Act
            var student = new Studentcs(name, age, gpa);

            // Assert
            Assert.AreEqual(name, student.Name);
            Assert.AreEqual(age, student.Age);
            Assert.AreEqual(gpa, student.Gpa);
        }

       
        [TestMethod]
        public void StudentName()
        {
            // Arrange
            var student = new Studentcs();
            string newName = "Мария";

            // Act
            student.Name = newName;

            // Assert
            Assert.AreEqual(newName, student.Name);
        }

       
        [TestMethod]
        public void StudentAge()
        {
            // Arrange
            var student = new Studentcs();
            int newAge = 22;

            // Act
            student.Age = newAge;

            // Assert
            Assert.AreEqual(newAge, student.Age);
        }

       
        [TestMethod]
        public void StudentGpa1()
        {
            // Arrange
            var student = new Studentcs();
            double newGpa = 8.5;

            // Act
            student.Gpa = newGpa;

            // Assert
            Assert.AreEqual(newGpa, student.Gpa);
        }

        [TestMethod]
        public void StudentConstructor()
        {
            // Arrange
            string name = "Иван";
            int age = 20;
            double gpa = 4.5;

            // Act
            var student = new Student.Studentcs(name, age, gpa);

            // Assert
            Assert.AreEqual(name, student.Name);
            Assert.AreEqual(age, student.Age);
            Assert.AreEqual(gpa, student.Gpa);
        }

        [TestMethod]
        public void StudentToString()
        {
            // Arrange
            var student = new Student.Studentcs("Иван", 20, 4.5);

            // Act
            var result = student.ToString();

            // Assert
            Assert.AreEqual("Студент(Имя: Иван, Возраст: 20, GPA: 4,5)", result);
        }

        [TestMethod]
        public void StudentCompareStudents1()
        {
            // Arrange
            var student1 = new Studentcs("Иван", 19, 4.5);
            var student2 = new Studentcs("Мария", 21, 4.5);

            // Act
            var result = student1.CompareStudents(student2);

            // Assert
            Assert.AreEqual("Иван младше Мария. GPA Иван равен GPA Мария", result);
        }

        [TestMethod]
        public void StudentCompareStudents2()
        {
            // Arrange
            var student1 = new Studentcs("Иван", 20, 4.6);
            var student2 = new Studentcs("Мария", 20, 4.5);

            // Act
            var result = student1.CompareStudents(student2);

            // Assert
            Assert.AreEqual("Иван ровесник Мария. GPA Иван выше GPA Мария", result);
        }

        [TestMethod]
        public void StudentCompareStudents3()
        {
            // Arrange
            var student1 = new Studentcs("Иван", 22, 4.5);
            var student2 = new Studentcs("Мария", 21, 4.7);

            // Act
            var result = student1.CompareStudents(student2);

            // Assert
            Assert.AreEqual("Иван старше Мария. GPA Иван ниже GPA Мария", result);
        }

        [TestMethod]
        public void StudentCompareStudentsStatic1()
        {
            // Arrange
            var student1 = new Studentcs("Иван", 19, 4.5);
            var student2 = new Studentcs("Мария", 21, 4.5);

            // Act
            var result = Studentcs.CompareStudentsStatic(student1, student2);

            // Assert
            Assert.AreEqual("Иван младше Мария. GPA Иван равен GPA Мария", result);
        }

        [TestMethod]
        public void StudentCompareStudentsStatic2()
        {
            // Arrange
            var student1 = new Studentcs("Иван", 20, 4.6);
            var student2 = new Studentcs("Мария", 20, 4.5);

            // Act
            var result = Studentcs.CompareStudentsStatic(student1, student2);

            // Assert
            Assert.AreEqual("Иван ровесник Мария. GPA Иван выше GPA Мария", result);
        }

        [TestMethod]
        public void StudentCompareStudentsStatic3()
        {
            // Arrange
            var student1 = new Studentcs("Иван", 22, 4.5);
            var student2 = new Studentcs("Мария", 21, 4.7);

            // Act
            var result = Studentcs.CompareStudentsStatic(student1, student2);

            // Assert
            Assert.AreEqual("Иван старше Мария. GPA Иван ниже GPA Мария", result);
        }

       
        [TestMethod]
        public void StudentGpa2()
        {
            // Arrange
            var student = new Studentcs();
            double negativeGpa = -1.0;

            // Act
            student.Gpa = negativeGpa;

            // Assert
            Assert.AreEqual(negativeGpa, student.Gpa); 
        }

       
        [TestMethod]
        public void StudentGpa3()
        {
            // Arrange
            var student = new Studentcs();
            double zeroGpa = 0.0;

            // Act
            student.Gpa = zeroGpa;

            // Assert
            Assert.AreEqual(zeroGpa, student.Gpa);
        }

      
        [TestMethod]
        public void StudentGpa4()
        {
            // Arrange
            var student = new Studentcs();
            double maxGpa = double.MaxValue;

            // Act
            student.Gpa = maxGpa;

            // Assert
            Assert.AreEqual(maxGpa, student.Gpa);
        }

       
        [TestMethod]
        public void StudentGpa5()
        {
            // Arrange
            var student = new Studentcs();
            double minGpa = double.MinValue;

            // Act
            student.Gpa = minGpa;

            // Assert
            Assert.AreEqual(minGpa, student.Gpa);
        }

       
        [TestMethod]
        public void StudentOperatorTilde()
        {
            // Arrange
            var student = new Studentcs("иван", 20, 4.5);

            // Act
            student = ~student;

            // Assert
            Assert.AreEqual("Иван", student.Name);
        }

      
        [TestMethod]
        public void StudentOperatorInt()
        {
            // Arrange
            var student = new Studentcs("Иван", 20, 4.5);

            // Act
            student++;

            // Assert
            Assert.AreEqual(21, student.Age);
        }

      
        [TestMethod]
        public void StudentOperatorPercent()
        {
            // Arrange
            var student = new Studentcs("Иван", 20, 4.5);
            string newName = "Мария";

            // Act
            var newStudent = student % newName;

            // Assert
            Assert.AreEqual(newName, newStudent.Name);
            Assert.AreEqual(student.Age, newStudent.Age);
            Assert.AreEqual(student.Gpa, newStudent.Gpa);
        }

       
        [TestMethod]
        public void StudentOperatorMinus1()
        {
            // Arrange
            var student = new Studentcs("Иван", 20, 4.5);
            double decreaseValue = 1.5;

            // Act
            student = student - decreaseValue;

            // Assert
            Assert.AreEqual(3.0, student.Gpa);
        }

       
        [TestMethod]
        public void StudentOperatorMinus2()
        {
            // Arrange
            var student = new Studentcs("Иван", 20, 1.5);
            double decreaseValue = 2.0;

            // Act
            student = student - decreaseValue;

            // Assert
            Assert.AreEqual(0.0, student.Gpa);

        }

        [TestMethod]
        public void StudentintExplicit1()
        {
            // Arrange
            var student = new Studentcs("Иван", 20, 1.5);

            // Act
            var result = (int) student;

            // Assert
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void StudentintExplicit2()
        {
            // Arrange
            var student = new Studentcs("Иван", 6, 1.5);

            // Act
            var result = (int)student;

            // Assert
            Assert.AreEqual(-1, result);

        }

        [TestMethod]
        public void StudentintExplicit3()
        {
            // Arrange
            var student = new Studentcs("Иван", 30, 1.5);

            // Act
            var result = (int)student;

            // Assert
            Assert.AreEqual(-1, result);

        }

        [TestMethod]
        public void Studentbool1()
        {
            // Arrange
            var student = new Studentcs("Иван", 30, 1.5);

            // Act
            var result = (bool)student;

            // Assert
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void Studentbool2()
        {
            // Arrange
            var student = new Studentcs("Иван", 30, 7);

            // Act
            var result = (bool)student;

            // Assert
            Assert.AreEqual(false, result);

        }


    }
}

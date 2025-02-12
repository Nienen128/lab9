using Student;
namespace Test1
{
    [TestClass]
    public class UnitTest3
    {
        
        [TestMethod]
        public void ReadIntInput()
        {
            // Arrange
            var input = new StringReader("42");
            Console.SetIn(input);

            // Act
            int result = UserInterface.ReadInt("Введите число:");

            // Assert
            Assert.AreEqual(42, result);
        }
        

        [TestMethod]
        public void IsNumberInDiapasonNumberInRange()
        {
            // Arrange
            int number = 5;
            int left = 1;
            int right = 10;

            // Act
            bool result = UserInterface.IsNumberInDiapason(number, left, right);

            // Assert
            Assert.IsTrue(result);
        }

       
        [TestMethod]
        public void IsNumberInDiapasonNumberOutOfRange()
        {
            // Arrange
            int number = 15;
            int left = 1;
            int right = 10;

            // Act
            bool result = UserInterface.IsNumberInDiapason(number, left, right);

            // Assert
            Assert.IsFalse(result);
        }

       
        [TestMethod]
        public void FindOldestStudentWithHighGPA1()
        {
            // Arrange
            var students = new StudentArray(3);
            students[0] = new Studentcs("Иван", 20, 9.0);
            students[1] = new Studentcs("Мария", 22, 7.5);
            students[2] = new Studentcs("Алексей", 21, 8.5);

            // Act
            var result = UserInterface.FindOldestStudentWithHighGPA(students);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Алексей", result.Name);
            Assert.AreEqual(21, result.Age);
            Assert.AreEqual(8.5, result.Gpa);
        }

       
        [TestMethod]
        public void FindOldestStudentWithHighGPA2()
        {
            // Arrange
            var students = new StudentArray(3);
            students[0] = new Studentcs("Иван", 20, 7.0);
            students[1] = new Studentcs("Мария", 22, 7.5);
            students[2] = new Studentcs("Алексей", 21, 6.5);

            // Act
            var result = UserInterface.FindOldestStudentWithHighGPA(students);

            // Assert
            Assert.IsNull(result);
        }
    }
}

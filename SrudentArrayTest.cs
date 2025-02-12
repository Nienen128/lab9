using Student;
namespace Test1
{
    [TestClass]
    public class UnitTest2
    {
        
        [TestMethod]
        public void StudentArrayDefaultConstructor()
        {
            // Arrange & Act
            var studentArray = new StudentArray();

            // Assert
            Assert.AreEqual(0, studentArray.Length);
        }

       
        [TestMethod]
        public void StudentArrayParameterizedConstructor()
        {
            // Arrange & Act
            var studentArray = new StudentArray(5);

            // Assert
            Assert.AreEqual(5, studentArray.Length);
        }

        
        [TestMethod]
        public void StudentArrayCopy()
        {
            // Arrange
            var originalArray = new StudentArray(3);
            originalArray[0] = new Studentcs("Иван", 20, 4.5);

            // Act
            var copiedArray = new StudentArray(originalArray);

            // Assert
            Assert.AreEqual(originalArray.Length, copiedArray.Length);
            Assert.AreEqual(originalArray[0].Name, copiedArray[0].Name);
            Assert.AreEqual(originalArray[0].Age, copiedArray[0].Age);
            Assert.AreEqual(originalArray[0].Gpa, copiedArray[0].Gpa);

            originalArray[0].Name = "Мария";
            Assert.AreNotEqual(originalArray[0].Name, copiedArray[0].Name);
        }

        
        [TestMethod]
        public void StudentArrayIndex1()
        {
            // Arrange
            var studentArray = new StudentArray(3);
            var student = new Studentcs("Иван", 20, 4.5);
            studentArray[0] = student;

            // Act
            var result = studentArray[0];

            // Assert
            Assert.AreEqual(student, result);
        }

        
        [TestMethod]
        public void StudentArrayIndex2()
        {
            // Arrange
            var studentArray = new StudentArray(3);
            var student = new Studentcs("Иван", 20, 4.5);

            // Act
            studentArray[0] = student;

            // Assert
            Assert.AreEqual(student, studentArray[0]);
        }

        
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void StudentArrayIndex3()
        {
            // Arrange
            var studentArray = new StudentArray(3);

            // Act
            var result = studentArray[10]; // Неверный индекс

            // Assert (ожидается исключение)

        }

       
        [TestMethod]
        public void StudentArrayHasStudents1()
        {
            // Arrange
            var studentArray = new StudentArray(3);
            studentArray[0] = new Studentcs("Иван", 20, 9.0);
            studentArray[1] = new Studentcs("Мария", 22, 7.5);
            studentArray[2] = new Studentcs("Алексей", 21, 8.5);

            // Act
            var result = studentArray.HasStudentsWithHighGPA();

            // Assert
            Assert.IsTrue(result);
        }

       
        [TestMethod]
        public void StudentArrayHasStudents2()
        {
            // Arrange
            var studentArray = new StudentArray(3);
            studentArray[0] = new Studentcs("Иван", 20, 7.0);
            studentArray[1] = new Studentcs("Мария", 22, 7.5);
            studentArray[2] = new Studentcs("Алексей", 21, 6.5);

            // Act
            var result = studentArray.HasStudentsWithHighGPA();

            // Assert
            Assert.IsFalse(result);
        }

        
        [TestMethod]
        public void StudentArrayHasStudents3()
        {
            // Arrange
            var studentArray = new StudentArray(3);
            studentArray[0] = new Studentcs("Иван", 20, 7.0);
            studentArray[1] = new Studentcs("Мария", 25, 7.5);
            studentArray[2] = new Studentcs("Алексей", 21, 6.5);

            // Act
            var result = studentArray.HasStudentsOlderThan(22);

            // Assert
            Assert.IsTrue(result);
        }

        
        [TestMethod]
        public void StudentArrayHasStudents5()
        {
            // Arrange
            var studentArray = new StudentArray(3);
            studentArray[0] = new Studentcs("Иван", 20, 7.0);
            studentArray[1] = new Studentcs("Мария", 22, 7.5);
            studentArray[2] = new Studentcs("Алексей", 21, 6.5);

            // Act
            var result = studentArray.HasStudentsOlderThan(25);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

using lab10;
using LibAnimals;

namespace lab10
{
    [TestClass]
    public class MammalTests
    {
        [TestMethod]
        public void TestMammalConstructor()
        {
            var mammal = new Mammal();
            Assert.IsNotNull(mammal);
            Assert.AreEqual(default(string), mammal.Name);
            Assert.AreEqual(default(string), mammal.Gender);
            Assert.AreEqual(default(int), mammal.Age);
            Assert.AreEqual(0, mammal.Id.Number);
            Assert.AreEqual(default(double), mammal.Weight);
        }

        [TestMethod]
        public void TestMammalConstructorWithParametrs()
        {
            var mammal = new Mammal("Тоша", "Самец", 5, 10.5, 1);
            Assert.AreEqual("Тоша", mammal.Name);
            Assert.AreEqual("Самец", mammal.Gender);
            Assert.AreEqual(5, mammal.Age);
            Assert.AreEqual(1, mammal.Id.Number);
            Assert.AreEqual(10.5, mammal.Weight);
        }

        [TestMethod]
        public void TestMammalShow()
        {
            var mammal = new Mammal("Тоша", "Самец", 5, 10.5, 1);
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                mammal.Show();
                var result = sw.ToString().Trim();
                Assert.AreEqual("\nИмя: Тоша, пол: Самец, возраст: 5\nВес: 10.5 кг", result);
            }
        }
        [TestMethod]
        public void TestMammalInit()
        {
            var mammal = new Mammal();
            using (var sr = new StringReader("Тоша\nСамец\n5\n1\n10.5"))
            {
                Console.SetIn(sr);
                mammal.Init();
                Assert.AreEqual("Тоша", mammal.Name);
                Assert.AreEqual("Самец", mammal.Gender);
                Assert.AreEqual(5, mammal.Age);
                Assert.AreEqual(1, mammal.Id.Number);
                Assert.AreEqual(10.5, mammal.Weight);
            }
        }
        [TestMethod]
        public void TestMammalRandomInit()
        {
            var mammal = new Mammal();
            mammal.RandomInit();
            Assert.IsNotNull(mammal.Name);
            Assert.IsNotNull(mammal.Gender);
            Assert.IsTrue(mammal.Age >= 1 && mammal.Age <= 44);
            Assert.IsTrue(mammal.Id.Number >= 1 && mammal.Id.Number <= 100);
            Assert.IsTrue(mammal.Weight >= 1 && mammal.Weight <= 100);
        }
        [TestMethod]
        public void TestMammalEquals()
        {
            var mammal1 = new Mammal("Тоша", "Самец", 5, 10.5, 1);
            var mammal2 = new Mammal("Тоша", "Самец", 5, 10.5, 1);
            var mammal3 = new Mammal("Федя", "Самец", 5, 10.5, 1);
            var mammal4 = new Mammal("Тоша", "Самец", 5, 15.5, 1);
            Assert.IsTrue(mammal1.Equals(mammal2));
            Assert.IsFalse(mammal1.Equals(mammal3));
            Assert.IsFalse(mammal1.Equals(mammal4));
        }
        [TestMethod]
        public void TestMammalToString()
        {
            var mammal = new Mammal("Тоша", "Самец", 5, 10.5, 1);
            var result = mammal.ToString();
            Assert.AreEqual("Имя: Тоша, пол: Самец, возраст: 5, Id: 1, вес: 10.5 кг", result);
        }
    }
}
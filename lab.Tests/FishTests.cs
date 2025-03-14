using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAnimals;

namespace lab10
{
    [TestClass]
    public class FishTests
    {
        [TestMethod]
        public void TestFishConstructor()
        {
            var fish = new Fish();
            Assert.IsNotNull(fish);
            Assert.AreEqual(default(string), fish.Name);
            Assert.AreEqual(default(string), fish.Gender);
            Assert.AreEqual(default(int), fish.Age);
            Assert.AreEqual(0, fish.Id.Number);
            Assert.AreEqual(default(bool), fish.IsMarine);
            Assert.AreEqual(default(int), fish.FinCount);
        }
        [TestMethod]
        public void TestFishConstructorWP()
        {
            var fish = new Fish("Немо", "Самец", 1, true, 5, 1);
            Assert.AreEqual("Немо", fish.Name);
            Assert.AreEqual("Самец", fish.Gender);
            Assert.AreEqual(1, fish.Age);
            Assert.AreEqual(true, fish.IsMarine);
            Assert.AreEqual(5, fish.FinCount);
            Assert.AreEqual(1, fish.Id.Number);
        }
        [TestMethod]
        public void TestFishShow()
        {
            var fish = new Fish("Немо", "Самец", 1, true, 5, 1);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                fish.Show();
                var result = sw.ToString().Trim();
                Assert.AreEqual("\nИмя: Немо, пол: Самец, возраст: 1\nМорская?: True, Кол-во плавников: 5", result);
            }
        }
        [TestMethod]
        public void TestFishInit()
        {
            var fish = new Fish();

            using (var sr = new StringReader("Немо\nСамец\n2\n1\ntrue\n5\n1"))
            {
                Console.SetIn(sr);
                fish.Init();
                Assert.AreEqual("Немо", fish.Name);
                Assert.AreEqual("Самец", fish.Gender);
                Assert.AreEqual(2, fish.Age);
                Assert.AreEqual(true, fish.IsMarine);
                Assert.AreEqual(5, fish.FinCount);
                Assert.AreEqual(1, fish.Id.Number);
            }
        }
        [TestMethod]
        public void TestFishRandomInit()
        {
            var fish = new Fish();
            fish.RandomInit();
            Assert.IsNotNull(fish.Name);
            Assert.IsNotNull(fish.Gender);
            Assert.IsTrue(fish.Age >= 1 && fish.Age <= 44);
            Assert.IsTrue(fish.IsMarine || !fish.IsMarine);
            Assert.IsTrue(fish.FinCount >= 1 && fish.FinCount <= 10);
        }
        [TestMethod]
        public void TestFishEquals()
        {
            var fish1 = new Fish("Немо", "Самец", 1, true, 5, 1);
            var fish2 = new Fish("Немо", "Самец", 1, true, 5, 1);
            var fish3 = new Fish("Дори", "Самка", 2, true, 5, 1);
            Assert.IsTrue(fish1.Equals(fish2));
            Assert.IsFalse(fish1.Equals(fish3));
        }
        [TestMethod]
        public void TestFishToString()
        {
            var fish = new Fish("Немо", "Самец", 1, true, 5, 1);
            var result = fish.ToString();
            Assert.AreEqual("Имя: Немо, пол: Самец, возраст: 1, Id: 1, Морская?: True, кол-во плавников: 5", result);
        }
    }
}

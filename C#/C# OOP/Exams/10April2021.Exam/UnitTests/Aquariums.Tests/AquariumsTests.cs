namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class AquariumsTests
    {
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("Aquarium", 50);
        }

        [Test]
        public void Initialize_WorksCorrectly()
        {
            this.aquarium = new Aquarium("Kondio", 100);

            Assert.AreEqual("Kondio", aquarium.Name);
            Assert.AreEqual(100, aquarium.Capacity);
            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void NameProperty_Empty_ThrowsException()
        {
            string value = "";

            // Act and Assert
            string expectedExceptionMessage = new ArgumentNullException(nameof(value), "Invalid aquarium name!").Message;
            string actualExceptionMessage = Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium(value, 10)).Message;
            Assert.AreEqual(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void NameProperty_Null_ThrowsException()
        {
            string value = null;

            // Act and Assert
            string expectedExceptionMessage = new ArgumentNullException(nameof(value), "Invalid aquarium name!").Message;
            string actualExceptionMessage = Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium(value, 10)).Message;
            Assert.AreEqual(expectedExceptionMessage, actualExceptionMessage);
        }


        [Test]
        public void CapacityProperty_NegativeNumber_ThrowsException()
        {
            Assert.That(() => this.aquarium = new Aquarium("Kondio", -1),
                Throws.ArgumentException.With.Message.EqualTo("Invalid aquarium capacity!"));
        }


        [Test]
        public void AddMethod_WorksCorrectly()
        {
            string fishName = "Kondio";
            Fish fish = new Fish(fishName);

            this.aquarium.Add(fish);
            List<Fish> collection = GetFishCollection();

            Assert.AreEqual(1, this.aquarium.Count);
            Assert.That(() => collection.Contains(fish));
        }

        [Test]
        public void AddMethod_FullCapacity_ThrowsException()
        {
            this.aquarium = new Aquarium("Aquarium", 2);
            this.aquarium.Add(new Fish("Kondio"));
            this.aquarium.Add(new Fish("Amet"));

            Assert.That(() => this.aquarium.Add(new Fish("Zarko")),
                Throws.InvalidOperationException.With.Message.EqualTo("Aquarium is full!"));
        }



        [Test]
        public void RemoveMethod_WorksCorrectly()
        {
            string fishName = "Kondio";
            Fish fish = new Fish(fishName);

            this.aquarium.Add(fish);
            Assert.AreEqual(1, this.aquarium.Count);

            List<Fish> collection = GetFishCollection();

            this.aquarium.RemoveFish(fishName);
            Assert.AreEqual(0, this.aquarium.Count);
            Assert.That(() => !collection.Contains(fish));
        }

        [Test]
        public void RemoveMethod_NonExistentName_ThrowsException()
        {
            string fishName = "Kondio";
            Fish fish = new Fish(fishName);

            this.aquarium.Add(fish);
            Assert.AreEqual(1, this.aquarium.Count);
            Assert.That(() => this.aquarium.Report().Contains(fishName));

            Assert.That(() => this.aquarium.RemoveFish("Amet"),
                Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name Amet doesn't exist!"));
        }



        [Test]
        public void SellFishMethod_WorksCorrectly()
        {
            string fishName = "Kondio";
            Fish fish = new Fish(fishName);

            this.aquarium.Add(fish);
            this.aquarium.SellFish(fishName);

            List<Fish> collection = GetFishCollection();
            Fish actualFish = collection.FirstOrDefault(f => f.Name == fishName);

            Assert.AreEqual(false, actualFish.Available);
        }

        private List<Fish> GetFishCollection()
        {
            FieldInfo[] fields = typeof(Aquarium).GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);

            var collection = fields.First(f => f.Name == "fish").GetValue(this.aquarium) as List<Fish>;
            return collection;
        }

        [Test]
        public void SellFishMethod_InvalidFish_ThrowsException()
        {
            string fishName = "Kondio";
            Fish fish = new Fish(fishName);

            this.aquarium.Add(fish);
            string name = "Amet";
            ;

            Assert.That(() => this.aquarium.SellFish(name),
                Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name {name} doesn't exist!"));
        }



        [Test]
        public void Report_WorksCorrectly()
        {
            string fishName1 = "Kondio";
            Fish fish1 = new Fish(fishName1);

            string fishName2 = "Amet";
            Fish fish2 = new Fish(fishName2);

            string fishName3 = "Zarko";
            Fish fish3 = new Fish(fishName3);

            this.aquarium.Add(fish1);
            this.aquarium.Add(fish2);
            this.aquarium.Add(fish3);

            string fishNames = fish1.Name + ", " + fish2.Name + ", " + fish3.Name;

            string expectedReport = $"Fish available at {aquarium.Name}: {fishNames}";
            string actualReport = this.aquarium.Report();
            Assert.AreEqual(expectedReport, actualReport);
        }


    }
}

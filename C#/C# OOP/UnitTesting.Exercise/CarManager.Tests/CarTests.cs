using NUnit.Framework;

namespace Tests
{
    using CarManager;

    public class CarTests
    {
        private const string make = "WolkSwagen";
        private const string model = "Golf";
        private const double fuelConsumption = 7.8;
        private const double fuelCapacity = 100;

        private Car car;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConstructorTest_WorksCorrectly()
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.Pass();
        }

        [Test]
        public void EmptyMakeArgument_ThrowsException()
        {
            Car car;
            Assert.That(() => car = new Car("", model, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void NullMakeArgument_ThrowsException()
        {
            Car car;
            Assert.That(() => car = new Car(null, model, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }



        [Test]
        public void EmptyModelArgument_ThrowsException()
        {
            Car car;
            Assert.That(() => car = new Car(make, "", fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void NullModelArgument_ThrowsException()
        {
            Car car;
            Assert.That(() => car = new Car(make, null, fuelConsumption, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }



        [Test]
        public void ZeroFuelConsumption_ThrowsException()
        {
            Car car;
            Assert.That(() => car = new Car(make, model, 0, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void NegativeFuelConsumption_ThrowsException()
        {
            Car car;
            Assert.That(() => car = new Car(make, model, -1, fuelCapacity),
                Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }



        [Test]
        public void ZeroFuelCapacity_ThrowsException()
        {
            Car car;
            Assert.That(() => car = new Car(make, model, fuelConsumption, 0),
                Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void NegativeFuelCapacity_ThrowsException()
        {
            Car car;
            Assert.That(() => car = new Car(make, model, fuelConsumption, -1),
                Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }



        [Test]
        public void Refuel_WorksCorrectly()
        {
            //Arrange
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            // Act
            this.car.Refuel(10);

            // Assert
            double expectedFuelAmount = 10;
            double actualFuelAmount = this.car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void RefuelWithNegativeAmount_ThrowsException()
        {
            //Arrange
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            // Act and Assert
            Assert.That(() => this.car.Refuel(-1),
                Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelMoreThanCapacity_WorksCorrectly()
        {
            //Arrange
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            // Act
            this.car.Refuel(102);

            // Assert
            double expectedFuelAmount = fuelCapacity;
            double actualFuelAmount = this.car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }


        [Test]
        public void Drive_WorksCorrectly()
        {
            // Arrange
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            // Act
            this.car.Refuel(60);
            this.car.Drive(40);

            // Assert
            double expectedFuelAmount = 56.88;
            double actualFuelAmount = this.car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void DriveWithEmptyBottle_ThrowsException()
        {
            // Arrange
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            // Act and Assert
            Assert.That(() => this.car.Drive(40),
                Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }



    }
}
namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class RobotsTests
    {
        private RobotManager robotManager;
        private const int capacity = 20;
        private Robot[] robots;

        [SetUp]
        public void SetUp()
        {
            this.robotManager = new RobotManager(capacity);
            this.robots = CreateRobots(capacity);
        }

        [Test]
        public void InitializeRobot_WorksCorrectly()
        {
            Robot robot = new Robot("Kondio", 100);
            Assert.AreEqual("Kondio", robot.Name);
            Assert.AreEqual(100, robot.MaximumBattery);
        }

        [Test]
        public void InitializeRobotManager_WorksCorrectly()
        {
            Assert.AreEqual(20, this.robotManager.Capacity);
            Assert.AreEqual(0, this.robotManager.Count);
        }

        [Test]
        public void InitializeRobotManager_NegativeCapacity_ThrowsException()
        {
            Assert.That(() => this.robotManager = new RobotManager(-2),
                Throws.ArgumentException.With.Message.EqualTo("Invalid capacity!"));
        }



        [Test]
        public void AddMethod_ValidCredentials_CountWorksCorrectly()
        {
            Robot robot = new Robot("Kondio", 100);

            this.robotManager.Add(robot);

            Assert.AreEqual(1, this.robotManager.Count);
        }

        [Test]
        public void AddMethod_ValidCredentials_ItemExists()
        {
            Robot robot = new Robot("Kondio", 100);

            this.robotManager.Add(robot);
            List<Robot> robots = GetPrivateField("robots") as List<Robot>;

            Assert.That(() => robots.Contains(robot));
        }

        [Test]
        public void AddMethod_AlreadyExistentItem_ThrowsException()
        {
            Robot robot = new Robot("Kondio", 100);

            this.robotManager.Add(robot);

            Assert.That(() => this.robotManager.Add(robot),
                Throws.InvalidOperationException.With.Message.EqualTo($"There is already a robot with name {robot.Name}!"));
        }

        [Test]
        public void AddMethod_AddSomeItems_CountWorksCorrectly()
        {
            foreach (Robot robot in this.robots)
            {
                this.robotManager.Add(robot);
            }

            Assert.AreEqual(capacity, this.robotManager.Count);
        }

        [Test]
        public void AddMethod_AddSomeItems_CompareItems()
        {
            foreach (Robot robot in this.robots)
            {
                this.robotManager.Add(robot);
            }

            List<Robot> robots = GetPrivateField("robots") as List<Robot>;

            int robotsCounter = 0;

            foreach (var robot in robots)
            {
                Assert.AreEqual(this.robots[robotsCounter++], robot);
            }
        }

        [Test]
        public void AddMethod_AddMoreItemsThanCapacity_ThrowsException()
        {
            foreach (Robot robot in this.robots)
            {
                this.robotManager.Add(robot);
            }

            Assert.That(() => this.robotManager.Add(new Robot("Kondio", 100)),
                Throws.InvalidOperationException.With.Message.EqualTo("Not enough capacity!"));
        }



        [Test]
        public void RemoveMethod_ExistentItem_CountWorksCorrectly()
        {
            for (int i = 0; i < 3; i++)
            {
                this.robotManager.Add(this.robots[i]);
            }

            this.robotManager.Remove(this.robots[0].Name);

            Assert.AreEqual(2, this.robotManager.Count);
        }

        [Test]
        public void RemoveMethod_ExistentItem_ItemDoesntExistsAnymore()
        {
            for (int i = 0; i < 3; i++)
            {
                this.robotManager.Add(this.robots[i]);
            }

            this.robotManager.Remove(this.robots[0].Name);

            List<Robot> robots = GetPrivateField("robots") as List<Robot>;

            Assert.That(() => !robots.Contains(this.robots[0]));
        }

        [Test]
        public void RemoveMethod_NonExistentItem_ThrowsException()
        {
            string name = "Kondio";

            foreach (var robot in this.robots)
            {
                this.robotManager.Add(robot);
            }

            Assert.That(() => this.robotManager.Remove(name),
                Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name {name} doesn't exist!"));
        }




        [Test]
        public void WorkMethod_ExistentItem_DecreasingBatteryCorrectly()
        {
            Robot robot = new Robot("Kondio", 100);
            this.robotManager.Add(robot);

            this.robotManager.Work(robot.Name, "DoesntMatter", 20);

            List<Robot> robots = GetPrivateField("robots") as List<Robot>;
            Robot trueRobot = robots.First(x => x.Name == robot.Name);

            Assert.AreEqual(80, trueRobot.Battery);
        }

        [Test]
        public void WorkMethod_NonExistentItem_ThrowsException()
        {
            Robot robot = new Robot("Kondio", 100);
            this.robotManager.Add(robot);

            string robotName = "Amet";

            Assert.That(() => this.robotManager.Work(robotName, "DoesntMatter", 20),
                Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name {robotName} doesn't exist!"));
        }

        [Test]
        public void WorkMethod_ExistentItemWithNotEnoughBattery_ThrowsException()
        {
            Robot robot = new Robot("Kondio", 100);
            this.robotManager.Add(robot);

            Assert.That(() => this.robotManager.Work(robot.Name, "DoesntMatter", 120),
                Throws.InvalidOperationException.With.Message.EqualTo($"{robot.Name} doesn't have enough battery!"));
        }




        [Test]
        public void ChargeMethod_ExistentItem_WorksCorrectly()
        {
            Robot robot = new Robot("Kondio", 100);
            this.robotManager.Add(robot);

            robot.Battery -= 80;

            Assert.AreEqual(20, robot.Battery);
            Assert.AreEqual(100, robot.MaximumBattery);

            this.robotManager.Charge(robot.Name);

            List<Robot> robots = GetPrivateField("robots") as List<Robot>;
            Robot trueRobot = robots.First(x => x.Name == robot.Name);

            Assert.AreEqual(100, trueRobot.Battery);
        }

        [Test]
        public void ChargeMethod_NonExistentItem_ThrowsException()
        {
            Robot robot = new Robot("Kondio", 100);
            this.robotManager.Add(robot);

            string robotName = "Amet";

            Assert.That(() => this.robotManager.Charge(robotName),
                Throws.InvalidOperationException.With.Message.EqualTo(($"Robot with the name {robotName} doesn't exist!")));
        }



        private object GetPrivateField(string fieldName)
        {
            FieldInfo[] fields = typeof(RobotManager).GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);

            var field = fields.First(x => x.Name == fieldName).GetValue(this.robotManager);

            return field;
        }

        private Robot[] CreateRobots(int count)
        {
            Robot[] robots = new Robot[count];

            for (int i = 0; i < robots.Length; i++)
            {
                string name = GenerateRandomString(6);
                int maxBattery = GenerateRandomInteger(0, 100);
                robots[i] = new Robot(name, maxBattery);
            }

            return robots;
        }

        private int GenerateRandomInteger(int minValue, int maxValue)
        {
            Random random = new Random();

            return random.Next(minValue, maxValue);
        }
        private string GenerateRandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

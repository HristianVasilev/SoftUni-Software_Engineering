using NUnit.Framework;

namespace Tests
{
    using FightingArena;

    public class WarriorTests
    {
        private const string name = "Kondio";
        private const int damage = 100;
        private const int hp = 100;

        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorAllArgumentsAreValid_WorksCorrectly()
        {
            // Arrange
            this.warrior = new Warrior(name, damage, hp);

            Assert.Pass();
        }



        [Test]
        public void NameIsEmpty_ThrowsException()
        {
            // Arrange, Act and Assert
            Assert.That(() => this.warrior = new Warrior("", damage, hp),
                Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void NameIsNull_ThrowsException()
        {
            // Arrange, Act and Assert
            Assert.That(() => this.warrior = new Warrior(null, damage, hp),
                Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }




        [Test]
        public void DamageIsZero_ThrowsException()
        {
            // Arrange, Act and Assert
            Assert.That(() => this.warrior = new Warrior(name, 0, hp),
                Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void DamageIsNegative_ThrowsException()
        {
            // Arrange, Act and Assert
            Assert.That(() => this.warrior = new Warrior(name, -1, hp),
                Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }




        [Test]
        public void HPIsNegative_ThrowsException()
        {
            // Arrange, Act and Assert
            Assert.That(() => this.warrior = new Warrior(name, damage, -1),
                Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }


        [Test]
        public void Attack_WorksCorrectly()
        {
            // Arrange
            this.warrior = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Amet", 70, 90);

            // Act
            this.warrior.Attack(warrior);

            // Assert
            int expectedWarriorHP = 0;
            int actualWarriorHP = warrior.HP;
            Assert.AreEqual(expectedWarriorHP, actualWarriorHP);
        }

        [Test]
        public void Attack2_WorksCorrectly()
        {
            // Arrange
            this.warrior = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Amet", 70, 110);

            // Act
            this.warrior.Attack(warrior);

            // Assert
            int expectedWarriorHP = 10;
            int actualWarriorHP = warrior.HP;
            Assert.AreEqual(expectedWarriorHP, actualWarriorHP);
        }

        [Test]
        public void AttackWithHPEqualsToMIN_ThrowsException()
        {
            // Arrange
            this.warrior = new Warrior(name, damage, 30);
            Warrior warrior = new Warrior("Amet", 70, 110);

            // Act and Assert
            Assert.That(() => this.warrior.Attack(warrior),
                Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackAWarriorWithHPEqualsToMIN_ThrowsException()
        {
            // Arrange
            int MIN_ATTACK_HP = 30;
            this.warrior = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Amet", 70, MIN_ATTACK_HP);

            // Act and Assert
            Assert.That(() => this.warrior.Attack(warrior),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }

        [Test]
        public void AttackTooStrongWarrior_ThrowsException()
        {
            // Arrange;
            this.warrior = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Amet", 110, 100);

            // Act and Assert
            Assert.That(() => this.warrior.Attack(warrior),
                Throws.InvalidOperationException.With.Message
                .EqualTo("You are trying to attack too strong enemy"));
        }


    }
}
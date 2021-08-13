using NUnit.Framework;

namespace Tests
{
    using FightingArena;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArenaTests
    {
        private Arena arena;
        private Warrior[] warriors;
        private const int warriorsSetUpCount = 6;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warriors = GenerateWarriors(warriorsSetUpCount);
        }


        [Test]
        public void Ctor_InitializeSuccessfully()
        {
            this.arena = new Arena();

            Assert.Pass();
        }


        [Test]
        public void CountOnEmptyCollection_EqualsToZero()
        {
            int expectedCount = 0;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }


        [Test]
        public void EnrollNonExistentWarrior_SuccessfullyAdded()
        {
            Warrior warrior = new Warrior("Kondio", 100, 100);
            this.arena.Enroll(warrior);

            Assert.AreEqual(1, this.arena.Count);

            IReadOnlyCollection<Warrior> warriors = this.arena.Warriors;
            Assert.AreEqual(1, warriors.Count);
            Assert.AreEqual(warrior, warriors.First());
        }

        [Test]
        public void EnrollSomeNonExistentWarriors_SuccessfullyAdded()
        {
            AddWarriorsToArena(this.warriors);

            Assert.AreEqual(warriorsSetUpCount, this.arena.Count);
            var warriors = this.arena.Warriors;

            int wCount = 0;
            foreach (var warrior in warriors)
            {
                Assert.AreEqual(this.warriors[wCount++], warrior);
            }
        }

        [Test]
        public void EnrollExistentWarrior_ThrowsException()
        {
            // Arrange
            AddWarriorsToArena(this.warriors);

            // Act and Assert
            Assert.That(() => this.arena.Enroll(this.warriors[0]),
                Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }


        [Test]
        public void Fight_WorksCorrectly()
        {
            // Arrange
            Warrior attacker = new Warrior("Kondio", 100, 100);
            Warrior defender = new Warrior("Amet", 80, 90);
            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            // Act
            this.arena.Fight(attacker.Name, defender.Name);

            // Assert
            int expectedAttackerHP = 20;
            int actualAttackerHP = this.arena.Warriors.First(w => w.Equals(attacker)).HP;
            Assert.AreEqual(expectedAttackerHP, actualAttackerHP);

            int expectedDefenderHP = 0;
            int actualDefenderHP = this.arena.Warriors.First(w => w.Equals(defender)).HP;
            Assert.AreEqual(expectedDefenderHP, actualDefenderHP);
        }

        [Test]
        public void FightWithNonExistentAttacker_ThrowsException()
        {
            // Arrange
            Warrior attacker = new Warrior("Kondio", 100, 100);
            Warrior defender = new Warrior("Amet", 80, 90);
            this.arena.Enroll(defender);
            string missingName = attacker.Name;

            // Act
            Assert.That(() => this.arena.Fight(attacker.Name, defender.Name),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
        }

        [Test]
        public void FightWithNonExistentDefender_ThrowsException()
        {
            // Arrange
            Warrior attacker = new Warrior("Kondio", 100, 100);
            Warrior defender = new Warrior("Amet", 80, 90);
            this.arena.Enroll(attacker);
            string missingName = defender.Name;

            // Act
            Assert.That(() => this.arena.Fight(attacker.Name, defender.Name),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
        }



        private Warrior[] GenerateWarriors(int count)
        {
            Warrior[] warriors = new Warrior[count];
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < warriors.Length; i++)
            {
                string name = new string(Enumerable.Repeat(chars, 10)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                int damage = random.Next(100, 999);
                int hp = random.Next(1000, 9999);

                warriors[i] = new Warrior(name, damage, hp);
            }

            return warriors;
        }
        private void AddWarriorsToArena(Warrior[] warriors)
        {
            foreach (var warrior in warriors)
            {
                this.arena.Enroll(warrior);
            }
        }
    }
}

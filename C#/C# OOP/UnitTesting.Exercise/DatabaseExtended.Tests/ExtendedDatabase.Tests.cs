using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tests
{
    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person[] people;
        private Person person;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(10101010, "Ismail");
            this.people = GeneratePeople(10);
            this.database = new ExtendedDatabase(this.people);
        }

        [Test]
        public void Initialize_WorksCorrectly()
        {
            // Act
            this.database = new ExtendedDatabase();

            // Assert
            Assert.AreEqual(0, this.database.Count);
        }

        [Test]
        public void DatabaseCount_WorksCorrectly()
        {
            // Assert
            int expectedCount = 10;
            int actualCount = this.database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }


        [Test]
        public void AddExistentPersonUsername_ThrowsException()
        {
            // Act
            Person person = new Person(20202020, "Ismail");

            // Act and Assert 
            Assert.That(() => this.database.Add(person),
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddExistentPersonId_ThrowsException()
        {
            //Act
            Person person = new Person(this.person.Id, "Kun4o");

            // Act and Assert      
            Assert.That(() => this.database.Add(person),
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void AddMoreThanPersonsCapacity_ThrowsException()
        {
            // Act
            this.people = GeneratePeople(16);
            this.database = new ExtendedDatabase(this.people);
            Person person = new Person(555666777888, "Kondio");

            //Act and Assert  
            Assert.That(() => this.database.Add(person),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddPerson_WorksCorrectly()
        {
            // Act
            Person person = new Person(444555666777, "Kondio");
            this.database.Add(person);

            // Assert
            IList<Person> insideCollection;
            int count;
            GetInsideCollectionAndCount(out insideCollection, out count);

            for (int i = 0; i < count - 2; i++)
            {
                Assert.AreEqual(this.people[i], insideCollection[i]);
            }

            Assert.AreEqual(this.people[this.people.Length - 1], insideCollection[count - 2]);
            Assert.AreEqual(person, insideCollection[count - 1]);
        }


        [Test]
        public void Remove_WorksCorrectly()
        {
            // Act
            this.database.Remove();

            // Assert
            int expectedCount = 9;
            int actualCount = this.database.Count;
            Assert.AreEqual(expectedCount, actualCount);

            IList<Person> insideCollection;
            int count;
            GetInsideCollectionAndCount(out insideCollection, out count);

            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(this.people[i], insideCollection[i]);
            }
        }

        [Test]
        public void RemoveFromEmptyCollection_ThrowsException()
        {
            // Act
            this.database = new ExtendedDatabase();

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }


        [Test]
        public void FindByUsername_WorksCorrectly()
        {
            // Act
            Person person = this.database.FindByUsername(this.person.UserName);

            // Assert
            Assert.AreEqual(this.person, person);
        }

        [Test]
        public void FindByUsernameNonExistent_ThrowsException()
        {
            // Act and Assert      
            Assert.That(() => this.database.FindByUsername("Kondio"),
                Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsernameWithEmptyParameter_ThrowsException()
        {
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(""))
                .Message.Equals("Username parameter is null!");
        }

        [Test]
        public void FindByUsernameWithNullParameter_ThrowsException()
        {
            // Act and Assert        

            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null))
                    .Message.Equals("Username parameter is null!");
        }


        [Test]
        public void FindById_WorksCorretly()
        {
            // Act
            Person person = this.database.FindById(this.person.Id);

            // Assert
            Assert.AreEqual(this.person, person);
        }

        [Test]
        public void FindByIdWithInvalidId_ThrowsException()
        {
            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1)).Message
                .Equals("Id should be a positive number!");
        }

        [Test]
        public void FindByIdNonExistentId_ThrowsException()
        {
            // Act and Assert
            Assert.That(() => this.database.FindById(444),
                Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }



        private Person[] GeneratePeople(int count)
        {
            Person[] people = new Person[count];
            Random random = new Random();

            for (int i = 0; i < count - 1; i++)
            {
                long personId = random.Next(1000, 1000000);

                string username = GenerateRandomString(random);

                people[i] = new Person(personId, username);
            }

            people[count - 1] = this.person;

            return people;
        }
        private static string GenerateRandomString(Random random)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }
        private void GetInsideCollectionAndCount(out IList<Person> insideCollection, out int count)
        {
            FieldInfo[] privateFields = this.database.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            insideCollection = privateFields
                .FirstOrDefault(x => x.FieldType == typeof(Person[]))
                .GetValue(this.database) as IList<Person>;
            if (insideCollection == null)
            {
                throw new ArgumentNullException($"Private collection doesn't exists!");
            }

            count = -1;
            int.TryParse(privateFields.FirstOrDefault(x => x.FieldType == typeof(int)).GetValue(this.database).ToString(), out count);

            if (count == -1)
            {
                throw new ArgumentNullException("Private field \"count\" doesn't exists!");
            }
        }

    }
}
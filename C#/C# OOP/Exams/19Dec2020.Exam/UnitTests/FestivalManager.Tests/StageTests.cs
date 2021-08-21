// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;

    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StageTests
    {
        private const string CanNotBeNullMessage = "Can not be null!";
        private Stage stage;
        private Performer[] performers;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.performers = CreatePerformers(10);
        }

        [TearDown]
        public void Clear()
        {
            this.stage = new Stage();
        }



        [Test]
        public void Initialize_WorksSuccessfully()
        {
            this.stage = new Stage();
            Assert.AreEqual(0, this.stage.Performers.Count);
        }

        [Test]
        public void DisturbPerformersCollectionInEmptyStage_WorksSuccessfully()
        {
            int expectedCount = 0;
            int actualCount = this.stage.Performers.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }


        [Test]
        public void AddPerformer_WorksCorrectly()
        {
            // Act
            this.stage.AddPerformer(this.performers[0]);

            // Assert
            Assert.AreEqual(1, this.stage.Performers.Count);
            Assert.AreEqual(this.performers[0], this.stage.Performers.ToArray()[0]);
        }

        [Test]
        public void AddPerformer_AddCollection_Ordered()
        {
            for (int i = 0; i < this.performers.Length; i++)
            {
                this.stage.AddPerformer(this.performers[i]);
            }

            Performer[] performers = this.stage.Performers.ToArray();
            Assert.AreEqual(this.performers.Length, performers.Length);

            for (int i = 0; i < this.performers.Length; i++)
            {
                Assert.AreEqual(this.performers[i], performers[i]);
            }
        }

        [Test]
        public void AddPerformerUnder18_ThrowsException()
        {
            // Arrange
            Performer performer = new Performer("Kondio", "Savov", 17);

            // Act
            Assert.That(() => this.stage.AddPerformer(performer)
            , Throws.ArgumentException.With.Message.EqualTo("You can only add performers that are at least 18."));
        }

        [Test]
        public void AddNullPerformer_ThrowsException()
        {
            // Arrange
            Performer performer = null;

            // Act
            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(performer));
        }




        [Test]
        public void AddSong_WorksCorrectly()
        {
            // Arrange
            Song song = new Song("Doko Doko", new TimeSpan(0, 4, 53));

            // Act
            this.stage.AddSong(song);

            // Assert
            List<Song> songs = GetSongsCollection();

            bool itContains = songs.Contains(song);
            Assert.AreEqual(true, itContains);
        }

        [Test]
        public void AddNullSong_ThrowsException()
        {
            // Arrange
            Song song = null;

            // Act and Assert
            string expectedMessage = new ArgumentNullException(nameof(song), CanNotBeNullMessage).Message;
            string actualMessage = Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(song)).Message;
            //  Assert.That(() => this.stage.AddSong(song), Throws.ArgumentNullException);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void AddSongWithDurationBelow1Minute_ThrowsException()
        {
            // Arrange
            Song song = new Song("Kralica", new TimeSpan(0, 0, 57));

            // Act and Assert
            Assert.That(() => this.stage.AddSong(song),
                Throws.ArgumentException.With.Message.EqualTo("You can only add songs that are longer than 1 minute."));
        }



        [Test]
        public void AddSongToPerformer_WorksCorrectly()
        {
            // Arrange 
            Performer performer = new Performer("Kondio", "Savov", 56);
            this.stage.AddPerformer(performer);

            Song song = new Song("100 Zhivota", new TimeSpan(0, 3, 17));
            this.stage.AddSong(song);

            // Act
            string actualMessage = this.stage.AddSongToPerformer(song.Name, performer.FullName);

            // Assert
            string expectedMessage = $"{song} will be performed by {performer}";
            Assert.AreEqual(expectedMessage, actualMessage);

            bool actualResult = this.stage.Performers
                .First(x => x.Equals(performer))
                .SongList
                .Contains(song);

            Assert.AreEqual(true, actualResult);
        }

        [Test]
        public void AddSongToPerformer_NullSong_ThrowsException()
        {
            // Arrange 
            Performer performer = new Performer("Kondio", "Savov", 56);
            this.stage.AddPerformer(performer);

            string songName = null;

            // Act and Assert
            string expectedExceptionMessage = new ArgumentNullException(nameof(songName), CanNotBeNullMessage).Message;
            Assert.That(() => this.stage.AddSongToPerformer(songName, performer.FullName),
                Throws.ArgumentNullException.With.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void AddSongToPerformer_NullPerformer_ThrowsException()
        {
            // Arrange 
            Song song = new Song("100 Zhivota", new TimeSpan(0, 3, 17));
            this.stage.AddSong(song);

            string performerName = null;

            // Act and Assert
            string expectedExceptionMessage = new ArgumentNullException(nameof(performerName), CanNotBeNullMessage).Message;
            Assert.That(() => this.stage.AddSongToPerformer(song.Name, performerName),
                Throws.ArgumentNullException.With.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void AddSongToPerformer_NonExistentSong_ThrowsException()
        {
            // Arrange 
            Performer performer = new Performer("Kondio", "Savov", 56);
            this.stage.AddPerformer(performer);

            Song song = new Song("100 Zhivota", new TimeSpan(0, 3, 17));
            // this.stage.AddSong(song);

            // Act and Assert
            Assert.That(() => this.stage.AddSongToPerformer(song.Name, performer.FullName),
                Throws.ArgumentException.With.Message.EqualTo("There is no song with this name."));
        }

        [Test]
        public void AddSongToPerformer_NonExistentPerformer_ThrowsException()
        {
            // Arrange 
            Performer performer = new Performer("Kondio", "Savov", 56);
            // this.stage.AddPerformer(performer);

            Song song = new Song("100 Zhivota", new TimeSpan(0, 3, 17));
            this.stage.AddSong(song);

            // Act and Assert
            Assert.That(() => this.stage.AddSongToPerformer(song.Name, performer.FullName),
                Throws.ArgumentException.With.Message.EqualTo("There is no performer with this name."));
        }

        [Test]
        public void Play_WorksCorrectly()
        {
            int songsCount = 0;
            for (int i = 0; i < this.performers.Length; i++)
            {
                string songName = RandomString(6);
                int hours = RandomInt(0, 1);
                int minutes = RandomInt(0, 59);
                int seconds = RandomInt(0, 59);
                Song song = new Song(songName, new TimeSpan(hours, minutes, seconds));
                songsCount++;
                this.performers[i].SongList.Add(song);
            }

            for (int i = 0; i < this.performers.Length; i++)
            {
                this.stage.AddPerformer(this.performers[i]);
            }

            string expectedResult = $"{this.performers.Length} performers played {songsCount} songs";
            string actualResult = this.stage.Play();
            Assert.AreEqual(expectedResult, actualResult);
        }


        private List<Song> GetSongsCollection()
        {

            // Assert
            return typeof(Stage)
                 .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                 .FirstOrDefault(f => f.Name == "Songs")
                 .GetValue(this.stage) as List<Song>;
        }
        private Performer[] CreatePerformers(int count)
        {
            Performer[] performers = new Performer[count];

            for (int i = 0; i < performers.Length; i++)
            {
                string firstName = RandomString(6);
                string lastName = RandomString(9);
                int age = RandomInt(18, 100);

                performers[i] = new Performer(firstName, lastName, age);
            }

            return performers;
        }
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
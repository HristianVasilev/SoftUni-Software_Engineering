using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private const int health = 100;
    private const int experience = 60;

    [SetUp]
    public void Initialize()
    {
        this.dummy = new Dummy(health, experience);
    }

    [Test]
    public void DummyLosesHealthWhenIsAttacked()
    {
        // Act
        this.dummy.TakeAttack(10);

        // Assert
        int expectedResult = 90;
        int actualResult = this.dummy.Health;
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DeadDummyThrowsExceptionWhenIsAttacked()
    {
        // Arrange
        this.dummy = new Dummy(0, 4);

        // Act and Assert
        string expectedMessage = "Dummy is dead.";
        string actualMessage = Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(5)).Message;

        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void DummyIsDeadMethodWorksCorrectly()
    {
        // Arrange
        this.dummy = new Dummy(10, 5);

        // Assert
        bool expectedResult = false;
        bool actualResult = this.dummy.IsDead();

        Assert.AreEqual(expectedResult, actualResult);

        // Act
        this.dummy.TakeAttack(10);

        // Assert
        expectedResult = true;
        actualResult = this.dummy.IsDead();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DeadDummyGivesXPCorrectly()
    {
        // Act
        this.dummy = new Dummy(0, 60);
        int givenExperience = this.dummy.GiveExperience();

        // Assert
        int expectedResult = 60;
        Assert.AreEqual(expectedResult, givenExperience);
    }

    [Test]
    public void AliveDummyCantGivesXP()
    {
        //Act and Assert
        string actualExceptionMessage = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience()).Message;
        string expectedExceptionMessage = "Target is not dead.";

        Assert.AreEqual(expectedExceptionMessage, actualExceptionMessage);
    }

}

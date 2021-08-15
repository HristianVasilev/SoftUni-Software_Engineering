using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private const int attackPoints = 10;
    private const int durability = 50;

    private Dummy dummy;
    private const int health = 100;
    private const int experience = 60;

    [SetUp]
    public void Initialize()
    {
        this.axe = new Axe(attackPoints, durability);
        this.dummy = new Dummy(health, experience);
    }

    [Test]
    public void WeaponLosesDurabilityAfterOneAttack()
    {
        // Act
        this.axe.Attack(dummy);

        // Assert
        int expectedResult = 49;
        int actualResult = this.axe.DurabilityPoints;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void WeaponLosesDurabilityAfterCoupleAttacks()
    {
        // Act
        for (int i = 0; i < 10; i++)
        {
            this.axe.Attack(dummy);
        }

        // Assert
        int expectedResult = 40;
        int actualResult = this.axe.DurabilityPoints;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        // Arrange
        this.axe = new Axe(10, 0);

        // Act and Assert
        string expectedExceptiopnMessage = "Axe is broken.";
        string actualExceptionMessage = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy)).Message;

        Assert.AreEqual(expectedExceptiopnMessage, actualExceptionMessage);
    }
}
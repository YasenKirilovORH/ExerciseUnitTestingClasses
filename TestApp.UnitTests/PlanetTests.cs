using NUnit.Framework;

using System;
using System.Xml.Linq;

namespace TestApp.UnitTests;

public class PlanetTests
{
    private Planet planet;

    [SetUp]
    public void SetUp()
    {
        planet = new Planet("Earth", 12742, 149600000, 1);
    }

    [Test]
    public void Test_CalculateGravity_ReturnsCorrectCalculation()
    {
        // Arrange
        double mass = 1000;
        double radius = planet.Diameter / 2.0;
        double expectedGravity = mass * 6.67430e-11 / Math.Pow(radius, 2);

        // Act
        double actualGravity = planet.CalculateGravity(mass);

        // Assert
        Assert.That(actualGravity, Is.EqualTo(expectedGravity));
    }

    [Test]
    public void Test_GetPlanetInfo_ReturnsCorrectInfo()
    {
        // Arrange
        string expected = $"Planet: {planet.Name}" 
                          + Environment.NewLine
                          + $"Diameter: {planet.Diameter} km"
                          + Environment.NewLine
                          + $"Distance from the Sun: {planet.DistanceFromSun} km"
                          + Environment.NewLine
                          + $"Number of Moons: {planet.NumberOfMoons}";

        // Act
        string actual = planet.GetPlanetInfo();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}

using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person person;

    [SetUp]
    public void SetUp()
    {
        person = new Person();
    }

    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        string[] peopleData = 
        { 
            "Alice A001 25", 
            "Bob B002 30", 
            "Alice A001 35" 
        };

        List<Person> expectedPeopleList = new List<Person>()
        {
            new Person()
            {
                Name = "Alice",
                Id = "A001",
                Age = 35
            },
            new Person()
            {
                Name = "Bob",
                Id = "B002",
                Age = 30
            }
        };
        

        // Act
        List<Person> resultPeopleList = person.AddPeople(peopleData);

        // Assert
        Assert.That(resultPeopleList, Has.Count.EqualTo(2));
        for (int person = 0; person < resultPeopleList.Count; person++)
        {
            Assert.That(resultPeopleList[person].Name, Is.EqualTo(expectedPeopleList[person].Name));
            Assert.That(resultPeopleList[person].Id, Is.EqualTo(expectedPeopleList[person].Id));
            Assert.That(resultPeopleList[person].Age, Is.EqualTo(expectedPeopleList[person].Age));
        }
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        // Arrange
        List<Person> peopleData = new List<Person>()
        {
            new Person()
            {
                Name = "Alice",
                Id = "A001",
                Age = 35
            },
            new Person()
            {
                Name = "Bob",
                Id = "B002",
                Age = 30
            }
        };

        string expected = "Bob with ID: B002 is 30 years old."
            + Environment.NewLine + "Alice with ID: A001 is 35 years old.";

        // Act
        string actual = person.GetByAgeAscending(peopleData);

        // Assert
        Assert.That(actual,Is.EqualTo(expected));
    }
}

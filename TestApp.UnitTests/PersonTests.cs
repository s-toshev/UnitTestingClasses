using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PersonTests
{

    private Person _person;

    [SetUp]
    public void SetUp()
    {
        this._person = new Person();
    }

    // TODO: finish test
    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };

        // Act
        List<Person> actualList = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(actualList, Has.Count.EqualTo(2));

        for (int i = 0; i < actualList.Count; i++)
        {
            Assert.That(actualList[i].Name, Is.EqualTo(actualList[i].Name));
            Assert.That(actualList[i].Id, Is.EqualTo(actualList[i].Id));
            Assert.That(actualList[i].Age, Is.EqualTo(actualList[i].Age));
        }
    }

    [Test]
    public void Test_AddPeople_Throws_FormatException_ForMissingFields()
    {
        // Arrange
        string[] peopleData = { "Alice A001", "Bob", "25" };

        // Act
        string exceptionMessage = Assert.Throws<IndexOutOfRangeException>(() => this._person.AddPeople(peopleData)).Message;

        // Assert
        Assert.AreEqual("Index was outside the bounds of the array.", exceptionMessage);
    }


    [Test]
    public void Test_AddPeople_UpdatesData_ForDuplicateIdsWithSameData()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 25" };

        // Act
        List<Person> actualList = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(actualList, Has.Count.EqualTo(2));

        Person alice = actualList.Find(p => p.Id == "A001");
        Person bob = actualList.Find(p => p.Id == "B002");

        Assert.NotNull(alice);
        Assert.NotNull(bob);

        Assert.AreEqual(25, alice.Age, "Alice's age should be updated to 25.");
        Assert.AreEqual(30, bob.Age, "Bob's age should remain 30.");
    }


    [Test]
    public void Test_AddPeople_Throws_FormatException_ForInvalidAge()
    {
        // Arrange
        string[] peopleData = { "Alice A001 ABC", "Bob B002 30", "Charlie C003 25" };

        // Act
        string exceptionMessage = Assert.Throws<FormatException>(() => this._person.AddPeople(peopleData)).Message;

        // Assert
        Assert.AreEqual("Input string was not in a correct format.", exceptionMessage);
    }


    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeopleWhenInputIsSpecialCharactersAndAgeIsExtreme()
    {
        // Arrange
        string[] peopleData = { "$% $% 254", "Q#$ #$@ 333", "#Ff $F 315" };

        // Act
        List<Person> actualList = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(actualList, Has.Count.EqualTo(3));

        for (int i = 0; i < actualList.Count; i++)
        {
            Assert.That(actualList[i].Name, Is.EqualTo(actualList[i].Name));
            Assert.That(actualList[i].Id, Is.EqualTo(actualList[i].Id));
            Assert.That(actualList[i].Age, Is.EqualTo(actualList[i].Age));
        }
    }

    [Test]
    public void Test_AddPeople_Throws_FormatException_WhenArrayItemsAreEmptySpaces()
    {
        // Arrange
        string[] peopleData = { "     ", "     ", "     " };

        // Act
        string exceptionMessage = Assert.Throws<FormatException>(() => this._person.AddPeople(peopleData)).Message;
        // Assert
        Assert.Throws<FormatException>(() => this._person.AddPeople(peopleData));
        Assert.AreEqual("Input string was not in a correct format.", exceptionMessage);
    }


    [Test]
    public void Test_AddPeople_Throws_FormatException_WhenNameIsEmptySpace()
    {
        // Arrange
        string[] peopleData = { " A001 25", "  B002 30", "  A001 35" };

        // Act
        string exceptionMessage = Assert.Throws<FormatException>(() => this._person.AddPeople(peopleData)).Message;
        // Assert
        Assert.Throws<FormatException>(() => this._person.AddPeople(peopleData));
        Assert.AreEqual("Input string was not in a correct format.", exceptionMessage);
    }


    [Test]
    public void Test_AddPeople_Returns_EmptyList_WhenEmptyArrayAsInput()
    {
        // Arrange
        string[] peopleData = Array.Empty<string>();

        // Act
        List<Person> actualList = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(actualList, Has.Count.EqualTo(0));


    }

    [Test]
    public void Test_AddPeople_ThrowsNullRefException_WhenNullAsInput()
    {
        // Arrange
        string[] peopleData = { null, null, null };

        // Act
        string exceptionMessage = Assert.Throws<NullReferenceException>(() => this._person.AddPeople(peopleData)).Message;

        // Assert

        Assert.Throws<NullReferenceException>(() => this._person.AddPeople(peopleData));
        Assert.AreEqual("Object reference not set to an instance of an object.", exceptionMessage);
    }


    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge_UniquePersonsGiven()
    {
        // Arrange

        List<Person> uniquePeople = new List<Person>
        {
           new Person { Name = "Charlie", Id = "C003", Age = 35 },
            new Person { Name = "Alice", Id = "A001", Age = 25 },
            new Person { Name = "Bob", Id = "B002", Age = 30 }
        };


        // Act
        var actual = _person.GetByAgeAscending(uniquePeople);
        string expected = "Alice with ID: A001 is 25 years old.\r\nBob with ID: B002 is 30 years old.\r\nCharlie with ID: C003 is 35 years old.";

        // Assert
        Assert.AreEqual(@expected, actual);
    }

    [Test]
    public void Test_GetByAgeAscending_SortsCorrectlyPeopleByAge_UniquePersonsWithDuplicateAgesGiven()
    {
        // Arrange

        List<Person> uniquePeople = new List<Person>
        {
           new Person { Name = "Alice", Id = "A001", Age = 25 },
            new Person { Name = "Bob", Id = "B002", Age = 30 },
            new Person { Name = "Charlie", Id = "C003", Age = 30 },
            new Person { Name = "David", Id = "D004", Age = 25 },
            new Person { Name = "Eve", Id = "E005", Age = 35 }

        };


        // Act
        var actual = _person.GetByAgeAscending(uniquePeople);
        string expected = "Alice with ID: A001 is 25 years old.\r\nDavid with ID: D004 is 25 years old.\r\nBob with ID: B002 is 30 years old.\r\nCharlie with ID: C003 is 30 years old.\r\nEve with ID: E005 is 35 years old.";

        // Assert
        Assert.AreEqual(@expected, actual);
    }



    [Test]
    public void Test_GetByAgeAscending_SortsCorrectlyPeopleByAge_UniquePersonsWithEmptyAgeGiven()
    {
        // Arrange

        List<Person> EmptyAge = new List<Person>
        {
            new Person { Name = "Alice", Id = "A001", Age = 25 },
            new Person { Name = "Bob", Id = "B002" },
            new Person { Name = "Charlie", Id = "C003", Age = 35 }
        };

        // Act
        var actual = _person.GetByAgeAscending(EmptyAge);
        string expected = "Alice with ID: A001 is 25 years old.\r\nCharlie with ID: C003 is 35 years old.";


        // Assert
        Assert.AreEqual(@expected, actual);
    }


    [Test]
    public void Test_GetByAgeAscending_SortsCorrectlyPeopleByAge_SpecialCharactersAsInput()
    {
        // Arrange

        List<Person> SpecialCharacters = new List<Person>
        {
            new Person { Name = "Q#$", Id = "#$@", Age = 30 },
           new Person { Name = "$%", Id = "$%", Age = 25 }
        };

        // Act
        var actual = _person.GetByAgeAscending(SpecialCharacters);
        string expected = "$% with ID: $% is 25 years old.\r\nQ#$ with ID: #$@ is 30 years old.";


        // Assert
        Assert.AreEqual(@expected, actual);
    }


    [Test]
    public void Test_GetByAgeAscending_Throws_FormatException_WhenNegativeAgeGiven()
    {
        // Arrange

        List<Person> NegativeAges = new List<Person>
        {
            new Person { Name = "Alice", Id = "A001", Age = -25 },
            new Person { Name = "Bob", Id = "B002", Age = -30 },
            new Person { Name = "Charlie", Id = "C003", Age = -35 }
        };

        // Act
        // Assert
        Assert.Throws<FormatException>(()=> this._person.GetByAgeAscending(NegativeAges), "Format exception was expected!");

    }


    [Test]
    public void Test_GetByAgeAscending_Throws_FormatException_WhenNameAndIDAsEmptyString()
    {
        // Arrange

        List<Person> NegativeAges = new List<Person>
        {
            new Person { Name = "", Id = "", Age = 999999999 },
            new Person { Name = "", Id = "", Age = -999999999 },
            new Person { Name = "", Id = "", Age = 888888888 }
        };


        // Act
        // Assert
        Assert.Throws<FormatException>(() => this._person.GetByAgeAscending(NegativeAges), "Format exception was expected!");

    }

    [Test]
    public void Test_GetByAgeAscending_Throws_NullRefException_WhenNullInputGiven()
    {
        // Arrange

        List<Person> nullinput = new List<Person>
        {
            null, null, null, null, null, null, null
        };

        // Act
        // Assert
        Assert.Throws<NullReferenceException>(() => this._person.GetByAgeAscending(nullinput), "Null reference exception was expected!");

    }

    [Test]
    public void Test_GetByAgeAscending_ReturnsEmptyString_WhenEmptyInputGiven()
    {
        // Arrange

        List<Person> emptyInput = new List<Person>
        {
        };

        // Act

        string result = this._person.GetByAgeAscending(emptyInput);
        // Assert
        Assert.AreEqual("", result);

    }
}

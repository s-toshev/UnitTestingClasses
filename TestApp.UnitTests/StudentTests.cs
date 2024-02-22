using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class StudentTests
{
    private Student _student;

    [SetUp]
    public void SetUp()
    {
        this._student = new();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndGetByCity_ReturnsStudentsInCity_WhenCityExists()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia" };
        string wantedTown = "Sofia";
        string expected = $"John Doe is 25 years old.{Environment.NewLine}Alice Johnson is 20 years old.";

        // Act
        string actual = this._student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsCorrectStudentInfo_WithExtremeAgeValues()
    {
        // Arrange
        string[] students = { "John Doe 215 Sofia", "Jane Smith 242 Varna", "Alice Johnson 120 Sofia" };
        string wantedTown = "Sofia";
        string expected = $"John Doe is 215 years old.{Environment.NewLine}Alice Johnson is 120 years old.";

        // Act
        string actual = this._student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsStudentsInCity_WhenMultipleStudentsInTheSameCity()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Sofia", "Alice Johnson 20 Sofia", "Naomi Jameson 44 Varna", "Versachi Ivanov 13 Sofia" };
        string wantedTown = "Sofia";
        string expected = "John Doe is 25 years old.\r\nJane Smith is 22 years old.\r\nAlice Johnson is 20 years old.\r\nVersachi Ivanov is 13 years old.";

        // Act
        string actual = this._student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.AreEqual(expected, actual);
    }


    [Test]
    public void Test_AddAndGetByCity_ReturnsCorrectStudentsInCity_WhenStudentsWithTheSameNameAgeDifferentCity()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jon Doe 25 Varna", "John Doe 25 Pleven" };
        string wantedTown = "Pleven";
        string expected = "John Doe is 25 years old.";

        // Act
        string actual = this._student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.AreEqual(expected, actual);
    }


    [Test]
    public void Test_AddAndGetByCity_ThrowsFormatException_WhenInputIsEmptySpace()
    {
        // Arrange
        string[] students = { "  ", "   ", "   " };
        string wantedTown = "   ";



        // Assert
        Assert.Throws<FormatException>(() => this._student.AddAndGetByCity(students, wantedTown));
    }


    [Test]
    public void Test_AddAndGetByCity_ThrowsFormatException_WhenInputIsNull()
    {
        // Arrange
        string[] students = { null, null,null };

        string wantedTown = null;



        // Assert
        Assert.Throws<NullReferenceException>(() => this._student.AddAndGetByCity(students, wantedTown));
    }



    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenCityDoesNotExist()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia" };
        string wantedTown = "ThisCityDoesNotExist";
        string expected = "";

        // Act
        string actual = this._student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenNoStudentsGiven()
    {
        // Arrange
        string[] students = Array.Empty<string>();

        string wantedTown = "Sofia";
        string expected = "";

        // Act
        string actual = this._student.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

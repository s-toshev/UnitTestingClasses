using NUnit.Framework;

using System;

using TestApp.Vehicle;

namespace TestApp.UnitTests;

public class VehicleTests
{
    private Vehicles _vehicle;

    // TODO: write the setup method
    [SetUp]
    public void SetUp()
    {
        this._vehicle = new Vehicles();
    }
    // TODO: finish test
    [Test]
    public void Test_AddAndGetCatalogue_ReturnsCorrectOutputWhenCarAndTruckBrandAndModelAreEmptySpace()
    {
        // Arrange
        string[] input = {"Car/ / /120", "Car/ / /150","Truck/ / /500"};

        string expected = "Cars:\r\n :   - 120hp\r\n :   - 150hp\r\nTrucks:\r\n :   - 500kg";

        // Act
        string actual = this._vehicle.AddAndGetCatalogue(input);
        // Assert
        Assert.AreEqual(expected, actual);

    }


    [Test]
    public void Test_AddAndGetCatalogue_ReturnsSortedCatalogue()
    {
        // Arrange
        string[] input = { "Car/Ford/Focus/120", "Car/Toyota/Camry/150", "Truck/Volvo/VNL/500" };

        string expected = $"Cars:{Environment.NewLine}Ford: Focus - 120hp{Environment.NewLine}Toyota: Camry - 150hp{Environment.NewLine}Trucks:{Environment.NewLine}Volvo: VNL - 500kg";

        // Act
        string actual = this._vehicle.AddAndGetCatalogue(input);
        // Assert
        Assert.AreEqual(expected, actual);

    }


    [Test]
    public void Test_AddAndGetCatalogue_ThrowsArgumentException_WhenWrongVehicleTypeAsInput()
    {
        // Arrange
        string[] input = { "Bike/Ford/Focus/120", "Lawnmower/Toyota/Camry/150", "Bycicle/Volvo/VNL/500" };

       

        // Act
        // Assert
        Assert.Throws<ArgumentException>(() => this._vehicle.AddAndGetCatalogue(input), "Expected a ArgumentException with a specific message.");
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsEmptyCatalogue_WhenNoDataGiven()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        string expected = "Cars:\r\nTrucks:";

        // Act
        string actual = this._vehicle.AddAndGetCatalogue(input);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndGetCatalogue_ThrowsNullReferenceExceptionWhenNullInputGiven()
    {
        // Arrange
        string[] input = { null, null, null };


        // Act
        string exception = Assert.Throws<NullReferenceException>(() => this._vehicle.AddAndGetCatalogue(input)).Message;

        // Assert
        Assert.Throws<NullReferenceException>(()=> this._vehicle.AddAndGetCatalogue(input));
        Assert.AreEqual("Object reference not set to an instance of an object.", exception, "Expected a NullReferenceException with a specific message.");

    }

    [Test]
    public void Test_AddAndGetCatalogue_ThrowsFormatException_WhenSeparatedEmptyStringsDataGiven()
    {
        // Arrange
        string[] input = {" / / / ", " / / / ", " / / / "};


        // Act
        string exception = Assert.Throws<FormatException>(() => this._vehicle.AddAndGetCatalogue(input)).Message;

        // Assert
        Assert.Throws<FormatException>(()=> this._vehicle.AddAndGetCatalogue(input));
        Assert.AreEqual("Input string was not in a correct format.", exception);

    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsCorrectOutput_WhenSeparatedEmptyStringsDataGivenAndHpOrWeightIsCorrect()
    {
        // Arrange
        string[] input = { " / / /120", " / / /121", " / / /114" };

        string expected = "Cars:\r\n :   - 120hp\r\n :   - 121hp\r\n :   - 114hp\r\nTrucks:";

        // Act
        string actual = this._vehicle.AddAndGetCatalogue(input);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Catalogue_ReturnsEmpty_ForMalformedInputStrings()
    {
        // Arrange
        string[] input = { "InvalidInput", "123", "Car/Ford/Focus/120" };

        // Act
        string exceptionMessage = Assert.Throws<IndexOutOfRangeException>(() => this._vehicle.AddAndGetCatalogue(input)).Message;

        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => this._vehicle.AddAndGetCatalogue(input));
        Assert.AreEqual("Index was outside the bounds of the array.", exceptionMessage);
    }

    [Test]
    public void Test_Catalogue_ReturnsSortedCatalogue_WithExtremeValues()
    {
        // Arrange
        string[] input = { "Car/Ford/Focus/-100", "Car/Toyota/Camry/9999", "Truck/Volvo/VNL/1000000" };

        string expected = $"Cars:{Environment.NewLine}Ford: Focus - -100hp{Environment.NewLine}Toyota: Camry - 9999hp{Environment.NewLine}Trucks:{Environment.NewLine}Volvo: VNL - 1000000kg";

        // Act
        string actual = this._vehicle.AddAndGetCatalogue(input);

        // Assert
        Assert.AreEqual(expected, actual, "Expected the catalogue to handle extreme values correctly.");
    }

    [Test]
    public void Test_Catalogue_ReturnsEmpty_ForInputWithUnexpectedCharacters()
    {
        // Arrange
        string[] input = { "Car/Ford@%/Focus/120", "Truck/Toyota/Camry/150" };

        // Act
        string actual = this._vehicle.AddAndGetCatalogue(input);

        // Assert
        Assert.AreEqual("Cars:\r\nFord@%: Focus - 120hp\r\nTrucks:\r\nToyota: Camry - 150kg", actual, "Expected an empty catalogue for input strings with unexpected characters.");
    }


}

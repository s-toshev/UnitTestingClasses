﻿using NUnit.Framework;

using System;

using TestApp.Store;

namespace TestApp.UnitTests;

public class ShopTests
{
    private Shop _shop;

    [SetUp]
    public void SetUp()
    {
        this._shop = new Shop();
    }
    // TODO: write setup method

    // TODO: finish test
    [Test]
    public void Test_AddAndGetBoxes_ReturnsSortedBoxes()
    {
        // Arrange
        string[] input = { "12345 Widget 5 10.00", "54321 Gadget 3 15.00", "98765 Gizmo 2 8.00" };

        string expected = $"12345{Environment.NewLine}-- Widget - $10.00: 5{Environment.NewLine}-- $50.00{Environment.NewLine}54321{Environment.NewLine}-- Gadget - $15.00: 3{Environment.NewLine}-- $45.00{Environment.NewLine}98765{Environment.NewLine}-- Gizmo - $8.00: 2{Environment.NewLine}-- $16.00";

        // Act
        string actual = this._shop.AddAndGetBoxes(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsEmptyString_WhenNoProductsGiven()
    {
        //Arrange
        string[] input = Array.Empty<string>();

        //Act
        string actual  = _shop.AddAndGetBoxes(input);
        string expected = string.Empty;

        //Assert
        Assert.AreEqual(expected, actual);
    }


    [Test]
    public void Test_AddAndGetBoxes_Throws_NullReferenceException()
    {
        //Arrange
        string[] input = { null,null,null,null };

        //Act

        //Assert
        Assert.Throws<NullReferenceException>(() => _shop.AddAndGetBoxes(input));
    }

    [Test]
    public void Test_AddAndGetBoxes_ThrowsSystemFormatException()
    {
        // Arrange
        string[] input = { "         ", "                 ", "            " };

      
        // Act

        // Assert

        Assert.Throws<FormatException>(() => _shop.AddAndGetBoxes(input));
    }

}


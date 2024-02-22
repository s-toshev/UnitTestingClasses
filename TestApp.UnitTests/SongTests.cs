using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class SongTests
{
    private Song _song;

    [SetUp]
    public void Setup()
    {
        this._song = new();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndListSongs_ReturnsAllSongs_WhenWantedListIsAll()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };
        string wantedList = "All";
        string expected = $"Song1{Environment.NewLine}Song2{Environment.NewLine}Song3";

        // Act
        string actual = this._song.AddAndListSongs(songs, wantedList);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsFilteredSongs_WhenWantedListIsSpecific()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };
        string wantedList = "Pop";
        string expected = $"Song1{Environment.NewLine}Song3";

        // Act
        string actual = this._song.AddAndListSongs(songs, wantedList);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenNoSongsMatchWantedList()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };
        string wantedList = "InTheMix";
        string expected = "";

        // Act
        string actual = this._song.AddAndListSongs(songs, wantedList);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndListSongs_ThrowsIndexOutOfRangeExceptionWhenTimeMissingFromSong()
    {
        // Arrange
        string[] songs = { "Pop_Song1", "Rock_Song2", "Pop_Song3" };
        string wantedList = "Pop";

        // Act
        // Assert
        Assert.Throws<IndexOutOfRangeException>(()=> this._song.AddAndListSongs(songs, wantedList));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenWantedListIsEmpty()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };
        string wantedList = string.Empty;
        string expected = "";

        // Act
        string actual = this._song.AddAndListSongs(songs, wantedList);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenWantedListIsNull()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Pop_Song3_3:00" };
        string wantedList = null;
        string expected = "";

        // Act
        string actual = this._song.AddAndListSongs(songs, wantedList);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenSongsInputIsEmptyArray()
    {
        // Arrange
        string[] songs = Array.Empty<string>();

        string wantedList = "Pop";
        string expected = "";

        // Act
        string actual = this._song.AddAndListSongs(songs, wantedList);
        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndListSongs_ShouldntReturnSongs_WhenSongsInputIsEmptySeparatedStrings()
    {
        // Arrange
        string[] songs = {" _  _ ", " _  _    ", " _    _   " };

        string wantedList = "all";
        string expected = "";

        // Act
        string actual = this._song.AddAndListSongs(songs, wantedList);
        // Assert
        Assert.AreEqual(expected, actual);
        Assert.IsNotEmpty(actual);
    }

    [Test]
    public void Test_AddAndListSongs_ShouldntReturnSongs_WhenSongsInputIsEmptyStrings()
    {
        // Arrange
        string[] songs = { "    ", "      ", "       " };

        string wantedList = "all";

        // Act
      
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => this._song.AddAndListSongs(songs, wantedList));
    }


    [Test]
    public void Test_AddAndListSongs_ThrowsNullReferenceExceptionWhenInputIsNull()
    {
        // Arrange
        string[] songs = {null,null,null };

        string wantedList = "Pop";

        // Act
        // Assert
        Assert.Throws<NullReferenceException>(() => this._song.AddAndListSongs(songs, wantedList));
    }

}

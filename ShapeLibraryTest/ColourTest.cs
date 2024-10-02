using ShapeLibrary;

namespace ShapeLibraryTest;

[TestClass]
public class ColourTest
{
    [TestMethod]
    public void invalidConstructorParamTooBig()
    {
        try
        {
            var colour1 = new Colour(256, 100, 100);
            Assert.Fail();
        }
        catch (Exception e){}
        try
        {
            var colour1 = new Colour(-5, 100, 100);
            Assert.Fail();
        }
        catch (Exception e) { }
    }

    [TestMethod]
    public void AddColourTest()
    {
        var colour1 = new Colour(100, 100, 100);
        var colour2 = new Colour(50, 50, 50);
        var result = colour1 + colour2;

        Assert.AreEqual(150, result.Red);
        Assert.AreEqual(150, result.Green);
        Assert.AreEqual(150, result.Blue);
    }
    [TestMethod]
    public void AddColourBiggerThan255()
    {
        var colour1 = new Colour(200, 200, 200);
        var colour2 = new Colour(100, 100, 100);
        var result = colour1 + colour2;

        Assert.AreEqual(255, result.Red);
        Assert.AreEqual(255, result.Green);
        Assert.AreEqual(255, result.Blue);
    }
    [TestMethod]
    public void SubstractColourTest()
    {
        var colour1 = new Colour(200, 200, 200);
        var colour2 = new Colour(100, 100, 100);
        var result = colour1 - colour2;

        Assert.AreEqual(100, result.Red);
        Assert.AreEqual(100, result.Green);
        Assert.AreEqual(100, result.Blue);
    }
    [TestMethod]
    public void SubstractColourLessThan0Test()
    {
        var colour1 = new Colour(100, 100, 100);
        var colour2 = new Colour(150, 150, 150);
        var result = colour1 - colour2;

        Assert.AreEqual(0, result.Red);
        Assert.AreEqual(0, result.Green);
        Assert.AreEqual(0, result.Blue);
    }
    [TestMethod]
    public void MultiplyColourTest()
    {
        var colour = new Colour(100, 100, 100);
        var result = 2 * colour;

        Assert.AreEqual(200, result.Red);
        Assert.AreEqual(200, result.Green);
        Assert.AreEqual(200, result.Blue);
    }
    [TestMethod]
    public void MultiplyColourTestLessThan0()
    {
        var colour = new Colour(150, 150, 150);
        var result = -1 * colour;

        Assert.AreEqual(0, result.Red);
        Assert.AreEqual(0, result.Green);
        Assert.AreEqual(0, result.Blue);
    }
    [TestMethod]
    public void MultiplyColourMoreThan255()
    {
        var colour = new Colour(150, 150, 150);
        var result = 2 * colour;

        Assert.AreEqual(255, result.Red);
        Assert.AreEqual(255, result.Green);
        Assert.AreEqual(255, result.Blue);
    }

    [TestMethod]
    public void EqualsTest()
    {
        var colour1 = new Colour(100, 150, 200);
        var colour2 = new Colour(100, 150, 200);
        var colour3 = new Colour(0, 0, 0);

        Assert.IsTrue(colour1 == colour2);
        Assert.IsFalse(colour1 == colour3);
    }
    [TestMethod]
    public void NotEqualsTest()
    {
        var colour1 = new Colour(100, 150, 200);
        var colour2 = new Colour(0, 0, 0);

        Assert.IsTrue(colour1 != colour2);
    }
    [TestMethod]
    public void ToStringTest()
    {
        var colour = new Colour(255, 128, 64);
        var result = colour.ToString();

        Assert.AreEqual("Red: 255, Green: 128, Blue: 64", result);
    }
}
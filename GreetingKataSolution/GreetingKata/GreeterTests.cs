
using GreetingKata;
using System.Xml.Linq;

namespace GreetingKata;

public class GreeterTests
{
    [Theory]
    [InlineData("Windom", "Hello, Windom!")]
    [InlineData("Chris", "Hello, Chris!")]
    [InlineData("Lisa", "Hello, Lisa!")]
    public void GreetsSingleName(string name, string expected)
    {
        var greeter = new Greeter();

        string greeting = greeter.Greet(name);

        Assert.Equal(expected, greeting);
    }

    [Fact]
    public void GreetsNullName()
    {
        var greeter = new Greeter();

        string greeting = greeter.Greet(null);

        Assert.Equal("Hello, Chief!", greeting);
    }

    [Theory]
    [InlineData("BOB", "HELLO, BOB!")]
    [InlineData("CHRIS", "HELLO, CHRIS!")]
    [InlineData("LISA", "HELLO, LISA!")]
    public void GreetsBackShouting(string name, string expected)
    {
        var greeter = new Greeter();

        string greeting = greeter.Greet(name);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData("Chris", "Lisa", "Hello, Chris and Lisa!")]
    [InlineData("Bob", "James", "Hello, Bob and James!")]
    public void GreetsTwoNames(string name1, string name2, string expected)
    {
        var greeter = new Greeter();

        string greeting = greeter.Greet(name1, name2);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData("Chris, Lisa", "James", "Hello, Chris, Lisa, and James!")]
    [InlineData("Bob,Lisa,James", "James", "Hello, Bob, Lisa, James, and James!")]
    public void GreetsSplitNames(string name1, string name2, string expected)
    {
        var greeter = new Greeter();

        string greeting = greeter.Greet(name1, name2);

        Assert.Equal(expected, greeting);
    }

    [Theory]
    [InlineData(new string[] { }, new string[] { })]
    [InlineData(new string[] { "James" }, new string[] { "James" })]
    [InlineData(new string[] { "Chris", "LISA" }, new string[] { "Chris", "LISA" })]
    [InlineData(new string[] { "LISA", "Chris" }, new string[] { "Chris", "LISA" })]
    public void SortsNamesByCaps(string[] names, string[] expected)
    {
        var result = Greeter.SortNamesByCaps(names.ToList());

        Assert.Equal(expected, result);
    }
}

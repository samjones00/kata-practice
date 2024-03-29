using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

public class Kata
{
    public static string TitleCase(string title, string minorWords = "")
    {
        var excludedWords = minorWords.Split(' ');
        var words = title.Split(' ');

        var result = new List<string>();
        for (var i = 0; i < words.Count(); i++)
        {
            result.Add(Capitalise(words[i], excludedWords));
        }

        return string.Join(' ', result);
    }

    private static string Capitalise(string value, string[] excludedWords)
    {
        TestContext.WriteLine($"input: {value}");
        if (excludedWords.Contains(value))
        {
            TestContext.WriteLine($"output: {value}, ignoring");
            return value;
        }

        value = value.ToLower();
        var ch = value.Split();
        ch[0] = ch[0].ToLower();

        var result = string.Join("", ch);
        TestContext.WriteLine($"output: {result}");

        return result;
    }
}

namespace Solution
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SolutionTest
    {
        [TestCase("a clash of KINGS", "a an the of", "A Clash of Kings")]
        [TestCase("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
        public void MyTest(string sampleTitle, string sampleMinorWords, string expected)
        {
            Assert.AreEqual(expected, Kata.TitleCase(sampleTitle, sampleMinorWords));
        }
        [Test]
        public void MyTest2()
        {
            Assert.AreEqual("", Kata.TitleCase(""));
        }
        [Test]
        public void MyTest3()
        {
            Assert.AreEqual("The Quick Brown Fox", Kata.TitleCase("the quick brown fox"));
        }
    }
}
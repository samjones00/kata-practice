namespace Katas.Tests;

public class Palindrome
{
    [TestCase("aba", true)]
    [TestCase("abc", false)]
    public void Version1(string value, bool expected)
    {
        static bool Invoke(string value)
        {
            for (int i = 0; i < value.Length - 1; i++)
            {
                var first = value[i];
                var last = value[value.Length - 1 - i];

                if (first != last)
                {
                    return false;
                }
            }

            return true;
        }

        Assert.That(Invoke(value), Is.EqualTo(expected));
    }

    [TestCase("aba", true)]
    [TestCase("abc", false)]
    public void Version2(string value, bool expected)
    {
        static bool Invoke(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

        Assert.That(Invoke(value), Is.EqualTo(expected));
    }
}
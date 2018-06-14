using System;
using System.Collections.Generic;
using HeadSpringApplication.Lib;

namespace AdvFizzBuzzFrog
{
    /// <summary>
    /// Write a second console application demonstrating advanced usage of SuperFizzBuzz that
    /// performs the following:
    /// a.Print the numbers from -12 through 145.
    /// b.For multiples of 3, print “Fizz”
    /// c.For Multiples of 7, print “Buzz”
    /// d.For Multiples of 38, print “Bazz”
    /// e.Print the appropriate combination of tokens for any number that matches more than
    ///   one of those rules
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> customTokens = new Dictionary<int, string>();
            customTokens.Add(3, "Fizz");
            customTokens.Add(7, "Buzz");
            customTokens.Add(38, "Bazz");

            var basicFizzBuzz = new SuperFizzBuzz(new WriteLog(), new FizzBuzzConfig { CustomToken = customTokens });
            basicFizzBuzz.FizzBuzzByRange(-12, 145);
        }
    }
    public class WriteLog : ISuperFizzBuzzLogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}

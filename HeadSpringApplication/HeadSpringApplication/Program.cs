using System;
using HeadSpringApplication.Lib;

namespace HeadSpringApplication
{
    /// <summary>
    /// Fizz buzz basics.
    /// FizzBuzz – The Basics
    /// Regular fizzbuzz output is typically described as 
    /// “Write a program that prints the numbers from 1 to 100. 
    /// But for multiples of 3, print “Fizz” instead of the number.
    /// For multiples of 5, print “Buzz”. 
    /// For Multiples of 3 and 5, print “FizzBuzz”. Typical fizzbuzz output looks like:
    /// 1
    /// 2
    /// Fizz
    /// 4
    /// Buzz
    /// 
    /// 88
    /// 89
    /// FizzBuzz
    /// 91
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var basicFizzBuzz = new SuperFizzBuzz(new WriteLog(), new FizzBuzzConfig());
            basicFizzBuzz.FizzBuzzByRange(1, 100);
        }
        public class WriteLog : ISuperFizzBuzzLogger
        {
            public void Log(string text)
            {
                Console.WriteLine(text);
            }   
        }
    }
}

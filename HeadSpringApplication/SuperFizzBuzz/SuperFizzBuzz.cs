using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace HeadSpringApplication.Lib
{
    /// <summary>
    /// Can produce fizzbuzz output for a user-supplied range of numbers 
    /// – e.g., from 2 to 35, or from 1 to 1,000,000,000, or from -1 to -35, etc.
    /// Can produce output for a user supplied set of integers, even if they’re not sequential.
    /// Can generate tokens other than “Fizz” and “Buzz” 
    /// and can evaluate division by numbers other than 3 and 5. 
    /// Maybe a user wants to test division by 4, 13, and 9,
    ///  and output “Frog”, “Duck,” and “Chicken” for 
    /// them(e.g., in this case, 52 would ouput “FrogDuck”, 
    /// 36 would output “FrogChicken”, 468 would output “FrogDuckChicken”, etc.)
    /// </summary>
    public class SuperFizzBuzz{
        ISuperFizzBuzzLogger output;
        FizzBuzzConfig config;
        public SuperFizzBuzz(ISuperFizzBuzzLogger output, FizzBuzzConfig config){
            this.output = output;
            this.config = config;
        }
        public void FizzBuzzByRange(int start, int end)
        {
            #region config tokens
            int[] tokens;
            string[] labels;
            setUpTokens(out tokens, out labels);
            #endregion
            int i = start + (start<end?-1:1);
            do
            {
                i = start < end ? i + 1 : i - 1;
                printFizzBuzz(tokens, labels, i);

            } while (i != end);
        }

        private void printFizzBuzz(int[] tokens, string[] labels, int i)
        {
            string fizzbuzzmsg = string.Empty;
            for (int j = 0; j < tokens.Length; j++)
            {
                if (i % tokens[j] == 0)
                    fizzbuzzmsg += labels[j];
            }
            if (string.Empty != fizzbuzzmsg)
                output.Log(fizzbuzzmsg);
            else
                output.Log(i.ToString());
        }

        public void FizzBuzzFromArray(int[] numbers)
        {
            #region config tokens
            int[] tokens;
            string[] labels;
            setUpTokens(out tokens, out labels);
            Array.ForEach(numbers, i => printFizzBuzz(tokens, labels, i));
            #endregion
        }

        private void setUpTokens(out int[] tokens, out string[] labels)
        {
            if (config.UseDefaultTokens == false)
            {
                tokens = new int[2];
                labels = new string[2];
                tokens[0] = 3;
                labels[0] = "Fizz";
                tokens[1] = 5;
                labels[1] = "Buzz";
            }
            else
            {
                tokens = new int[config.CustomToken.Count];
                labels = new string[config.CustomToken.Count];
                config.CustomToken.Keys.CopyTo(tokens, 0);
                config.CustomToken.Values.CopyTo(labels, 0);
            }
        }
    }
    public interface ISuperFizzBuzzLogger{
        void Log(string text);
    }
    public class FizzBuzzConfig{
        private Dictionary<int, string> customTokens;
        public System.Collections.Generic.Dictionary<int, string> CustomToken
        {
            get { return customTokens; }
            set { UseDefaultTokens = false; customTokens = value; }
        }
        public bool UseDefaultTokens
        {
            get;set;
        }
        public FizzBuzzConfig(){
            UseDefaultTokens = false;
       }
    }
    
}

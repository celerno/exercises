using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadSpringApplication.Lib;
using NSubstitute;
namespace SuperFizzBuzzTests
{
    
    [TestClass]
    public class FizzBuzzBasicsTest
    {
        private SuperFizzBuzz spf;
        ISuperFizzBuzzLogger logger;
        [TestInitialize]
        public void TestInit()
        {
            logger = Substitute.For<ISuperFizzBuzzLogger>();
            spf = new SuperFizzBuzz(logger, new FizzBuzzConfig());
        }
    
        [TestMethod]
        public void GivenArrayFizzBuzz()
        {
            spf.FizzBuzzFromArray(new int[] { 1,5,9, 21, 25 });
            logger.Received(2).Log(Arg.Is<string>(x => x.Equals("Fizz")));
            logger.Received(2).Log(Arg.Is<string>(x => x.Equals("Buzz")));
            logger.Received(0).Log(Arg.Is<string>(x => x.Equals("FizzBuzz")));
        }
        [TestMethod]
        public void GivenRangeFizzBuzz()
        {
            spf.FizzBuzzByRange(1, 15);
            logger.Received(2).Log(Arg.Is<string>(x => x.Equals("Buzz")));
            logger.Received(4).Log(Arg.Is<string>(x => x.Equals("Fizz")));
            logger.Received(1).Log(Arg.Is<string>(x => x.Equals("FizzBuzz")));

        }
        [TestMethod]
        public void GivenLimitsFizzBuzz(){
            spf.FizzBuzzByRange(999999990, 1000000000);
            logger.Received(1).Log(Arg.Is<string>(x => x.Equals("999999998")));
        }
    }
}

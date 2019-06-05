using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void userInputNonNumerical()
        {
            var photoDisplayTest = new photoDisplay("This is Not a Number");
            string expected = "Your input was not a number. Please try again.";
            Assert.AreEqual(expected, photoDisplayTest.displayResult);
        }
        [TestMethod]
        public void userInputNumerical()
        {
            var photoDisplayTest = new photoDisplay("60");
            string notExpected = "Your input was not a number. Please try again.";
            Assert.AreNotEqual(notExpected, photoDisplayTest.displayResult);
        }
        [TestMethod]
        public void userInputEmptyAlbum()
        {
            var photoDisplayTest = new photoDisplay("500");
            string expected = "There are no photos in that album.";
            Assert.AreEqual(expected, photoDisplayTest.displayResult);
        }
    }
}

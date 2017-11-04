using Xunit;

namespace MainWebApplicationUnitTests
{
    public class SampleUnitTest
    {
        [Fact]
        public void TwoPlusThreeEqualsFive()
        {
            //Arrange
            var expectedResult = 5;

            //Act
            var result = 2 + 3;

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}

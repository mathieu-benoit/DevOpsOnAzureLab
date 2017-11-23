using MainWebApplication.Services;
using Xunit;

namespace MainWebApplicationUnitTests
{
    public class AdditionServiceUnitTest
    {
        IAdditionService additionService;

        public AdditionServiceUnitTest()
        {
            additionService = new AdditionService();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(1, 2)]
        public void Test_Add(int x, int y)
        {
            //Arrange
            var expectedResult = x + y;

            //Act
            var actualResult = additionService.Add(x, y);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

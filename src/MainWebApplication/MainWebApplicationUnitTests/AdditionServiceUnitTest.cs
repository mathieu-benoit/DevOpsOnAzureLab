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
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(2, 1, 3)]
        [InlineData(1, 2, 3)]
        public void Test_Add(int x, int y, int result)
        {
            //Arrange
            var expectedResult = x + y;

            //Act
            var realResult = additionService.Add(x, y);

            //Assert
            Assert.Equal(expectedResult, realResult);
        }
    }
}

using System;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace BoardGame.UnitTests
{
    public class BoardGameUnitTests
    {

        [Theory]
        [Trait("Category", "Unit")]
        [InlineData("MRMLMMRLMLLLRMM" ,"1 2 S")]
        [InlineData("MMMMRM", "1 4 E")]
        [InlineData("MMMMRMMRM", "2 3 S")]
        [InlineData("LLLMMMMMMMMMMMMMMM", "4 0 E")]
        [InlineData("MMMMM", "0 4 N")]
        public void RunGameSuccessTest1(string input, string expected)
        {
            var mockBoardGame = new Mock<BoardGame>();
            var result = mockBoardGame.Object.RunGame(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void RunGame_Throws_ArgumentException_For_Invalid_InputTest()
        {
            var mockBoardGame = new Mock<BoardGame>();
            Assert.Throws<ArgumentException>(() => mockBoardGame.Object.RunGame(It.IsAny<string>()));
        }
    }
}

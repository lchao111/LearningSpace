using Moq;
using System;
using Xunit;

namespace LearningTDD.UnitTest
{
    public class FizzBuzzPracticeTest
    {
        [Fact]
        public void IfNumberIsNotDividableForThreeAndFiveReturnItSelf()
        {
            var mockValidator = new Mock<IHonk>();
            mockValidator.Setup(x => x.IsValidNumber(It.IsAny<int>())).Returns(false);
            mockValidator.Setup(x => x.Noise).Returns("Honk");
            FizzBuzzPractice fbp = new FizzBuzzPractice(mockValidator.Object);
            string expected = fbp.MakeNoise(3);
            Assert.Equal(expected, "Fizz");
        }
    }
}

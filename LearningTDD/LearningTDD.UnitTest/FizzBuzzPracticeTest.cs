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
            mockValidator.Setup(x => x.Sound.Noise.NoiseSound).Returns(GetNoiseString);
            FizzBuzzPractice fbp = new FizzBuzzPractice(mockValidator.Object);
            string expected = fbp.MakeNoise(3);
            Assert.Equal(expected, "Fizz");
        }

        [Fact]
        public void IfNumberIsDiviableFor100ReturnHonk()
        {
            var mockValidator = new Mock<IHonk>();
            mockValidator.Setup(x => x.Sound.Noise.NoiseSound).Returns("Honk");
            mockValidator.Setup(x => x.IsValidNumber(100)).Returns(true);
            FizzBuzzPractice fbp = new FizzBuzzPractice(mockValidator.Object);
            var actual = fbp.MakeNoise(100);
            Assert.Equal(actual, "Honk");
        }

        [Fact]
        public void IfNumberIsDiviableFor3ReturnFizz()
        {
            var mockValidator = new Mock<IHonk>();
            mockValidator.Setup(x => x.Sound.Noise.NoiseSound).Returns("Honk");
            mockValidator.Setup(x=>x.IsValidNumber(It.IsAny<int>())).Returns(false);
            FizzBuzzPractice fbp = new FizzBuzzPractice(mockValidator.Object);
            var actual = fbp.MakeNoise(9);
            Assert.Equal(actual, "Fizz");
        }

        [Fact]
        public void IfNumberIsDiviableFor5ReturnFizz()
        {
            var mockValidator = new Mock<IHonk>();
            mockValidator.Setup(x => x.Sound.Noise.NoiseSound).Returns("Honk");
            mockValidator.Setup(x => x.IsValidNumber(It.IsAny<int>())).Returns(false);
            FizzBuzzPractice fbp = new FizzBuzzPractice(mockValidator.Object);
            var actual = fbp.MakeNoise(5);
            Assert.Equal(actual, "Buzz");
        }
        string GetNoiseString()
        {
            return "Honk";
        }
    }
}

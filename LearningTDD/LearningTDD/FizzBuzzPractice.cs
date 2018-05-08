using System;

namespace LearningTDD
{
    public class FizzBuzzPractice
    {
        private IHonk _validator;
        public FizzBuzzPractice(IHonk validator)
        {
            _validator = validator;
        }
        public string MakeNoise(int n)
        {
            var isValid = _validator.IsValidNumber(n);
            if (_validator.Sound.Noise.NoiseSound != "Honk")
            {
                return "Not a Honk!";
            }
            else if (isValid)
            {
                return "Honk";
            }
            else if (DivideByThreeAndFive(n) == 0)
            {
                return "FizzBuzz";
            }
            else if (DivideByThree(n) == 0)
            {
                return "Fizz";
            }
            else if (DivideByFive(n) == 0)
            {
                return "Buzz";
            }
            return n.ToString();
        }

        private int DivideByThree(int n)
        {
            return n % 3;
        }

        private int DivideByFive(int n)
        {
            return n % 5;
        }

        private int DivideByThreeAndFive(int n)
        {
            return n%15;
        }

        public string TestHandler(Func<string, string> test)
        {
            return test("123");
        }

        public string ReadFromFile(string x)
        {
            return x;
        }
    }
}

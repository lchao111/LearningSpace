﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LearningTDD
{
    public class Honk : IHonk
    {
        public void IsValidNumber(int number, out bool isValidate)
        {
            throw new NotImplementedException("Not implemented");
            //isValidate = number % 100 == 0 ? true : false;
        }

        public bool IsValidNumber(int number)
        {
            var isValidate = number % 100 == 0 ? true : false;
            return isValidate;
        }

        public String Noise
        {
            get
            {
                throw new NotImplementedException("not implemented yet");
            }
        }
    }
}

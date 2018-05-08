using System;
using System.Collections.Generic;
using System.Text;

namespace LearningTDD
{
    public interface IHonk
    {
        void IsValidNumber(int n, out bool IsValidate);
        bool IsValidNumber(int n);

        ISound Sound { get; }
    }
}

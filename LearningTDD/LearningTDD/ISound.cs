using System;
using System.Collections.Generic;
using System.Text;

namespace LearningTDD
{
    public interface ISound
    {
        INoiseData Noise { get; set; }
    }
}

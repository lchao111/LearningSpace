using System;
using System.Collections.Generic;
using System.Text;

namespace LearningTDD
{
    public class SoundGenerator
    {
        private ISound _sound;
        public SoundGenerator(ISound sound)
        {
            _sound = sound;
        }

        public bool ValidateThisSound()
        {
            return true;
        }

        public enum ValidSound
        {
            Honk,
            Mu       
        }
    }
}

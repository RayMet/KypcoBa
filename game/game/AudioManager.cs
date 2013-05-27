﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace BatlleSpace
{
    class AudioManager
    {
        private static AudioEngine engine;
        private static SoundBank soundBank;
        private static WaveBank waveBank;
        private static Cue mainTheme;

        static AudioManager()
        {
            engine = new AudioEngine(@"Content\Audio\BatlleSpace.xgs");
            soundBank = new SoundBank(engine, @"Content\Audio\Sound Bank.xsb");
            waveBank = new WaveBank(engine, @"Content\Audio\Wave Bank.xwb");
        }
        public static void Update()
        {
            engine.Update();
        }
        public static void PlayShootSound()
        {
          
        }
        public static void StartMainTheme()
        {
            if (mainTheme == null)
            {
                mainTheme = soundBank.GetCue("space");
                mainTheme.Play();
            }
        }
        public static void StopMainTheme()
        {
            if (mainTheme != null)
            {
                mainTheme.Stop(AudioStopOptions.Immediate);
            }
        }
    }
}
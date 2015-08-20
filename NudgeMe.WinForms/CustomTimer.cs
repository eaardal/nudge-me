using System;
using System.Timers;

namespace NudgeMe.WinForms
{
    class CustomTimer : Timer
    {
        private IBalloonTipAdapter _balloonTipAdapter;
        public TimerSettings Settings { get; set; }

        public IBalloonTipAdapter BalloonTipAdapter
        {
            get
            {
                if (_balloonTipAdapter == null)
                    throw new InvalidOperationException("BalloonTipAdapter was null when trying to use its value");

                return _balloonTipAdapter;
            }
            set { _balloonTipAdapter = value; }
        }

        public CustomTimer(TimerSettings settings) : base(settings.IntervalInMs)
        {
            Settings = settings;
        }
    }
}
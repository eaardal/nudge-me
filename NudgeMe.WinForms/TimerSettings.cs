using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace NudgeMe.WinForms
{
    class TimerSettings
    {
        public DateTime StartTime { get; set; }
        public int IntervalInMs { get; set; }
        public int IntervalRaw { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public IntervalUnit IntervalUnit { get; set; }

        public static IEnumerable<TimerSettings> CreateFromAppSettings()
        {
            var appSettingEntries = ReadAppSettingEntries();

            var settings = new List<TimerSettings>();

            foreach (var entry in appSettingEntries)
            {
                var elements = entry.Split(';');

                var startTimeElement = elements.ElementAt(0);
                var intervalElement = elements.ElementAt(1);
                var intervalUnitElement = elements.ElementAt(2);
                var headerElement = elements.ElementAt(3);
                var textElement = elements.ElementAt(4);

                var startTime = ParseAndValidateStartTime(startTimeElement);
                var interval = ParseAndValidateInterval(intervalElement);
                var intervalUnit = ParseAndValidateIntervalUnit(intervalUnitElement);
                var intervalInMilliseconds = TimeConverters.GetMillisecondsForIntervalUnit(intervalUnit, interval);
                var headerText = ParseAndValidateHeaderText(headerElement);
                var text = ParseAndValidateText(textElement);

                var settingEntry = new TimerSettings
                {
                    StartTime = startTime,
                    IntervalInMs = intervalInMilliseconds,
                    IntervalRaw = interval,
                    Header = headerText,
                    Text = text,
                    IntervalUnit = intervalUnit
                };

                settings.Add(settingEntry);
            }

            return settings;
        }

        public static IEnumerable<CustomTimer> CreateTimers(IEnumerable<TimerSettings> timerConfigs, IBalloonTipAdapter balloonTipAdapter)
        {
            return timerConfigs.Select(c =>
            {
                var timer = new CustomTimer(c);

                timer.Elapsed += OnTimerTick;
                timer.BalloonTipAdapter = balloonTipAdapter;

                return timer;
            });
        }

        private static void OnTimerTick(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var customTimer = (CustomTimer)sender;

            var balloonTip = customTimer.BalloonTipAdapter;
            
            balloonTip.ShowBalloonTip(50000, customTimer.Settings.Header, customTimer.Settings.Text, ToolTipIcon.Info);
        }

        private static IntervalUnit ParseAndValidateIntervalUnit(string intervalUnitElement)
        {
            IntervalUnit intervalUnit;
            var parsed = Enum.TryParse(intervalUnitElement, true, out intervalUnit);
            if (parsed)
            {
                return intervalUnit;
            }
            throw new ParseValidationException("input unit");
        }

        private static string ParseAndValidateText(string textElement)
        {
            if (!string.IsNullOrEmpty(textElement))
            {
                return textElement;
            }
            throw new ParseValidationException("text");
        }

        private static string ParseAndValidateHeaderText(string headerElement)
        {
            if (!string.IsNullOrEmpty(headerElement))
            {
                return headerElement;
            }
            throw new ParseValidationException("header text");
        }

        private static int ParseAndValidateInterval(string intervalElement)
        {
            int interval;
            var parsed = int.TryParse(intervalElement, out interval);
            if (parsed)
            {
                return interval;
            }
            throw new ParseValidationException("interval");
        }

        private static DateTime ParseAndValidateStartTime(string startTimeElement)
        {
            DateTime startTime;
            var parsed = DateTime.TryParse(startTimeElement, out startTime);
            if (parsed)
            {
                return startTime;
            }
            throw new ParseValidationException("start time");
        }

        private static IEnumerable<string> ReadAppSettingEntries()
        {
            var appSettingEntries =
                ConfigurationManager.AppSettings.AllKeys.Where(k => k.StartsWith("timer."))
                    .Select(k => ConfigurationManager.AppSettings[k]);
            return appSettingEntries;
        }
    }
}
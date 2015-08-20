using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NudgeMe.WinForms
{
    sealed class TaskbarApplicationContext : ApplicationContext
    {
        private NotifyIcon _notify;

        public TaskbarApplicationContext()
        {
            InitializeContext();
        }

        private void InitializeContext()
        {
            CreateNotifyIcon();
            var timers = CreateAndStartTimers();
            DisplayInitializationResultToUser(timers);
        }

        private void DisplayInitializationResultToUser(CustomTimer[] timers)
        {
            var text = GenerateTextToDisplay(timers);

            _notify.ShowBalloonTip(8000, "NudgeMe started", text, ToolTipIcon.Info);
        }

        private static string GenerateTextToDisplay(CustomTimer[] timers)
        {
            var aggregated = string.Empty;

            for (var i = 0; i < timers.Length; i++)
            {
                var timer = timers[i];

                aggregated +=
                    $"Timer #{i + 1} starting @ {timer.Settings.StartTime.ToShortTimeString()}, nudging every {timer.Settings.IntervalRaw}{timer.Settings.IntervalUnit.ToString().ToLower()}\n";
            }
            return aggregated;
        }

        private void CreateNotifyIcon()
        {
            var container = new Container();

            _notify = new NotifyIcon(container)
            {
                Visible = true,
                Icon = SystemIcons.Information,
                ContextMenuStrip = BuildContextMenu(container)
            };
        }

        private CustomTimer[] CreateAndStartTimers()
        {
            var timerSettings = TimerSettings.CreateFromAppSettings();

            var balloonTipAdapter = new NotifyIconBalloonTipAdapter(_notify);
            var timers = TimerSettings.CreateTimers(timerSettings, balloonTipAdapter).ToArray();

            foreach (var timer in timers)
            {
                timer.Start();
            }

            return timers;
        }

        private ContextMenuStrip BuildContextMenu(Container container)
        {
            var contextMenu = new ContextMenuStrip(container);
   
            var exitButton = new ToolStripButton("Exit");
            exitButton.Click += OnExitClicked;

            contextMenu.Items.Add(exitButton);

            return contextMenu;
        }

        private void OnExitClicked(object sender, EventArgs eventArgs)
        {
            var exitButton = (ToolStripButton) sender;
            exitButton.Click -= OnExitClicked;

            _notify.Visible = false;
            _notify.Dispose();

            Application.Exit();
        }
    }
}
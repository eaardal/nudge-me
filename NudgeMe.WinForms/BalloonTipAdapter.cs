using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NudgeMe.WinForms
{
    class NotifyIconBalloonTipAdapter : IBalloonTipAdapter
    {
        private readonly NotifyIcon _notify;

        public NotifyIconBalloonTipAdapter(NotifyIcon notify)
        {
            if (notify == null) throw new ArgumentNullException(nameof(notify));
            _notify = notify;
        }

        public void ShowBalloonTip(int duration, string headerText, string contentText, ToolTipIcon icon)
        {
            _notify.ShowBalloonTip(duration, headerText, contentText, icon);
        }
    }
}

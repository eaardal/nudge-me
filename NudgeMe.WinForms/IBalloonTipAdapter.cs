using System.Windows.Forms;

namespace NudgeMe.WinForms
{
    internal interface IBalloonTipAdapter
    {
        void ShowBalloonTip(int duration, string headerText, string contentText, ToolTipIcon icon);
    }
}
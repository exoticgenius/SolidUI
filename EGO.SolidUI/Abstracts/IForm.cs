using System;
using System.Drawing;
using System.Windows.Forms;

namespace EGO.SolidUI
{
    public partial class IForm : Form, IThemeReference
    {
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")] public static extern bool ReleaseCapture();
        public void MouseKeyDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 161, 2, 0);
            }
        }
        private void Sync(object sender, ControlEventArgs e)
        {
            if (e.Control is IThemeReference)
                ((IThemeReference)e.Control).Sync();
        }
        public IForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            DoubleBuffered = true;
            ControlAdded += Sync;
            SolidSettings.AliveItems.Add(this);
            Sync();
        }
        ~IForm()
        {
            SolidSettings.AliveItems.Remove(this);
        }




        public ThemeStatus Status = new ThemeStatus();
        public bool Inverted
        {
            get => Status.Inverted;
            set
            {

                Status.Inverted = value;
                PerformStyle();

            }
        }
        public bool DarkTheme
        {
            get => Status.DarkTheme;
            set
            {
                Status.DarkTheme = value;
                PerformStyle();
            }
        }
        public Color ThemeColor
        {
            get => Status.ThemeColor;
            set
            {
                Status.ThemeColor = value;
                PerformStyle();
            }
        }
        public bool ManualInvert
        {
            get
            {
                return Status.ManualInvert;
            }
            set
            {
                Status.ManualInvert = value;
            }
        }
        public bool ReverseInvertAction
        {
            get => Status.ReverseInvertAction;
            set => Status.ReverseInvertAction = value;
        }
        public bool ReverseDarkTheme
        {
            get => Status.ReverseDarkTheme;
            set => Status.ReverseDarkTheme = value;
        }
        public bool ManualDarkTheme
        {
            get => Status.ManualDarkTheme;
            set => Status.ManualDarkTheme = value;
        }
        public bool ManualThemeColor
        {
            get => Status.ManualThemeColor;
            set => Status.ManualThemeColor = value;
        }

        public void Sync()
        {
            if (!ManualThemeColor) Status.ThemeColor = SolidSettings.ThemeColor;
            if (!ManualDarkTheme) Status.DarkTheme = (ReverseDarkTheme) ? !SolidSettings.DarkTheme : SolidSettings.DarkTheme;
            if (!ManualInvert) Status.Inverted = (ReverseInvertAction) ? !SolidSettings.Inverted : SolidSettings.Inverted;
            PerformStyle();
        }
        public void PerformStyle()
        {
            SuspendLayout();
            if (Status.Inverted)
            {
                BackColor = Status.ThemeColor;

                if (Status.DarkTheme)
                {
                    ForeColor = SolidSettings.ReverseColorDark;
                }
                else
                {
                    ForeColor = SolidSettings.ReverseColorLight;
                }
            }
            else
            {
                ForeColor = Status.ThemeColor;

                if (Status.DarkTheme)
                {
                    BackColor = SolidSettings.ReverseColorDark;
                }
                else
                {
                    BackColor = SolidSettings.ReverseColorLight;
                }
            }
            ResumeLayout(true);
            ChildSync();
        }
        public void ChildSync()
        {
            foreach (object CT in Controls)
            {
                if (CT is IThemeReference)
                {
                    ((IThemeReference)CT).Sync();
                }
            }
        }
    }
}

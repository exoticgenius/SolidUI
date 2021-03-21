using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.SolidUI
{
    [DefaultEvent("Click")]
    public partial class SwitchButton : UserControl, IThemeReference
    {
        public SwitchButton()
        {
            InitializeComponent();
            DarkTheme = true; ;
            ThemeColor = Color.White;
            Enable = false;
            ParentChanged += Sync;
        }
        private bool _Switch_state;
        public bool Enable
        {
            get => _Switch_state;
            set
            {
                _Switch_state = value;
                mover.Start();
                Sync();
            }
        }
#pragma warning disable CS0108
        public event EventHandler Click;
#pragma warning restore CS0108
        private void SwitchButton_Click(object sender, EventArgs e)
        {
            Enable = !Enable;
            Click?.Invoke(sender, e);
            Sync();
        }
        private void Mover_Tick(object sender, EventArgs e)
        {
            if (!Enable)
            {
                if (dot.Left > 3)
                    dot.Left -= 3;
                else
                {
                    dot.Left = 3;
                    mover.Enabled = false;
                }
            }
            else
            {
                if (dot.Left < 28)
                    dot.Left += 3;
                else
                {
                    dot.Left = 29;
                    mover.Enabled = false;
                }
            }
        }
        private void Sync(object sender, EventArgs e) => Sync();




        private ThemeStatus Status = new ThemeStatus();
        public bool Inverted
        {
            get => Status.Inverted;
            set
            {
                Status.Inverted = value;
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
            if (Parent is IThemeReference)
            {
                if (!ManualThemeColor) Status.ThemeColor = ((IThemeReference)Parent).ThemeColor;
                if (!ManualDarkTheme) Status.DarkTheme = (ReverseDarkTheme) ? !((IThemeReference)Parent).DarkTheme : ((IThemeReference)Parent).DarkTheme;
                if (!ManualInvert) Status.Inverted = (ReverseInvertAction) ? !((IThemeReference)Parent).Inverted : ((IThemeReference)Parent).Inverted;
                PerformStyle();
            }
        }
        public void PerformStyle()
        {

            if (Inverted)
            {
                if (Enable)
                {
                    body.BackColor = row.BackColor = (DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight;
                    dot.BackColor = Status.ThemeColor;
                }
                else
                {
                    body.BackColor = dot.BackColor = (DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight; ;
                    row.BackColor = Status.ThemeColor;
                }
            }
            else
            {
                if (Enable)
                {
                    body.BackColor = row.BackColor = Status.ThemeColor;
                    dot.BackColor = (DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight; ;
                }
                else
                {
                    body.BackColor = dot.BackColor = Status.ThemeColor;
                    row.BackColor = (DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight; ;
                }
            }
            ChildSync();

        }
        public void ChildSync()
        {

        }
    }
}

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
    public partial class ThirdButton : Button, IThemeReference
    {
        public ThirdButton() : base()
        {
            Font = new Font("Segoe UI Light", 12F);
            Size = new Size(100, 38);
            DoubleBuffered = true;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            MouseDownDegree = 40;
            MouseMoveDegree = 20;
            MouseDown += MouseKeyDown;
            MouseUp += MouseKeyUp;
            MouseMove += MouseKeyMove;
            MouseLeave += MouseKeyLeave;
            ParentChanged += Sync;
            BackColorChanged += ColorSync;
            ForeColorChanged += ColorSync;
        }
        private void MouseKeyLeave(object sender, EventArgs e) => Inverted = Inverted;
        private void MouseKeyMove(object sender, EventArgs e)
        {
            if (Inverted)
            {
                BackColor = SolidSettings.Fixer(ThemeColor, MouseMoveDegree);
                ForeColor = SolidSettings.Fixer((DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight, MouseMoveDegree);
            }
            else
            {
                ForeColor = SolidSettings.Fixer(ThemeColor, MouseMoveDegree);
                BackColor = SolidSettings.Fixer((DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight, MouseMoveDegree);
            }
        }

        private void MouseKeyDown(object sender, MouseEventArgs e)
        {
            if (Inverted)
            {
                BackColor = SolidSettings.Fixer(ThemeColor, MouseDownDegree);
                ForeColor = SolidSettings.Fixer((DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight, MouseDownDegree);
            }
            else
            {
                ForeColor = SolidSettings.Fixer(ThemeColor, MouseDownDegree);
                BackColor = SolidSettings.Fixer((DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight, MouseDownDegree);
            }
        }
        private void MouseKeyUp(object sender, MouseEventArgs e) => Inverted = Inverted;
        private void ColorSync(object sender, EventArgs e)
        {
            FlatAppearance.MouseOverBackColor = FlatAppearance.MouseDownBackColor = BackColor;
            FlatAppearance.BorderColor = ForeColor;
        }
        public byte MouseDownDegree
        {
            get; set;
        }
        public byte MouseMoveDegree
        {
            get; set;
        }
        public float FontSize
        {
            get => Font.Size; set => Font = new Font(Font.FontFamily, value);
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
                if (!Inverted)
                    ForeColor = Status.ThemeColor = value;
                else
                    BackColor = Status.ThemeColor = value;
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

            if (Status.Inverted)
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
            else
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
            ChildSync();

        }
        public void ChildSync()
        {

        }
    }
}

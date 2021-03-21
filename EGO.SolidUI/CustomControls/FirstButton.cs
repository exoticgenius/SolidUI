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
    public class FirstButton : Button, IThemeReference
    {
        public float FontSize
        {
            get => Font.Size; set => Font = new Font(Font.FontFamily, value);
        }
        private void ColorSync(object sender, EventArgs e)
        {
            FlatAppearance.MouseOverBackColor = FlatAppearance.MouseDownBackColor = BackColor;
            FlatAppearance.BorderColor = ForeColor;
        }
        private void MouseKeyDown(object sender, MouseEventArgs e)
        {
            FlatAppearance.BorderSize = 1;
            if (Inverted)
            {
                BackColor = ThemeColor;
                ForeColor = (DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight;
            }
            else
            {
                ForeColor = ThemeColor;
                BackColor = (DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight;
            }
        }
        private void MouseKeyUp(object sender, MouseEventArgs e)
        {
            FlatAppearance.BorderSize = 0;
            Inverted = Inverted;
        }
        private void Sync(object sender, EventArgs e) => Sync();
        public FirstButton()
        {
            ManualInvert = false;
            Font = new Font("Segoe UI Light", 12F);
            Size = new Size(100, 38);
            FlatStyle = FlatStyle.Flat;
            DoubleBuffered = true;
            FlatAppearance.BorderSize = 0;
            MouseDown += MouseKeyDown;
            MouseUp += MouseKeyUp;
            ParentChanged += Sync;
            BackColorChanged += ColorSync;
            ForeColorChanged += ColorSync;
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

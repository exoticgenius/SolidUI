using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EGO.SolidUI
{
    [DefaultEvent("Click")]
    public partial class FirstPanel : Panel, IThemeReference
    {

        public Image _DarkImage;
        public Image _LightImage;
        public Image _DarkImage_Inverted;
        public Image _LightImage_Inverted;
        public Image DarkImage
        {
            get => _DarkImage;
            set
            {
                _DarkImage = (Inverted && DarkTheme) ? BackgroundImage = value : value;
            }
        }
        public Image LightImage
        {
            get => _LightImage;
            set
            {
                _LightImage = (Inverted && !DarkTheme) ? BackgroundImage = value : value;
            }
        }
        public Image DarkImageInverted
        {
            get => _DarkImage_Inverted;
            set
            {
                _DarkImage_Inverted = (!Inverted && DarkTheme) ? BackgroundImage = value : value;
            }
        }
        public Image LightImageInverted
        {
            get => _LightImage_Inverted;
            set
            {
                _LightImage_Inverted = (!Inverted && !DarkTheme) ? BackgroundImage = value : value;
            }
        }
        public FirstPanel()
        {
            ManualInvert = true;
            if (TopLevelControl is IThemeReference)
            {
                DarkTheme = (TopLevelControl as IThemeReference).DarkTheme;
                ThemeColor = (TopLevelControl as IThemeReference).ThemeColor;
            }
            else
            {
                Inverted = false;
                DarkTheme = true;
                ThemeColor = Color.Blue;
            }
            BackgroundImageLayout = ImageLayout.Stretch;
            DoubleBuffered = true;
            ControlAdded += Controladded;
            ParentChanged += Sync;
        }
        private void Controladded(object sender, ControlEventArgs e)
        {
            if (e.Control is IThemeReference)
                ((IThemeReference)e.Control).Sync();
        }
        private void Sync(object sender, EventArgs e) => Sync();
        private bool _AlwaysThemeToBack = false;
        public bool AlwaysThemeToBack
        {
            get => _AlwaysThemeToBack;
            set
            {
                _AlwaysThemeToBack = value;
                PerformStyle();
            }
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
                BackColor = Status.ThemeColor;

                if (Status.DarkTheme)
                {
                    ForeColor = SolidSettings.ReverseColorDark;
                    BackgroundImage = DarkImageInverted;
                }
                else
                {
                    ForeColor = SolidSettings.ReverseColorLight;
                    BackgroundImage = LightImageInverted;
                }
            }
            else
            {
                ForeColor = Status.ThemeColor;

                if (Status.DarkTheme)
                {
                    BackColor = SolidSettings.ReverseColorDark;
                    BackgroundImage = DarkImage;
                }
                else
                {
                    BackColor = SolidSettings.ReverseColorLight;
                    BackgroundImage = LightImage;
                }
            }

            if (AlwaysThemeToBack) BackColor = ThemeColor;
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
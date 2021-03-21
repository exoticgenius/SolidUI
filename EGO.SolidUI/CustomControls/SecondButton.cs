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
    public partial class SecondButton : UserControl, IThemeReference
    {
        public System.Windows.Forms.Label TextArea { get => LblText; set => LblText = value; }

        public SecondButton()
        {
            InitializeComponent();
            ManualInvert = false;
            DoubleBuffered = true;

            splitContainer1.Click += KeyClick;
            PicIcon.Click += KeyClick;
            LblText.Click += KeyClick;

            splitContainer1.MouseDown += MouseKeyDown;
            PicIcon.MouseDown += MouseKeyDown;
            LblText.MouseDown += MouseKeyDown;

            splitContainer1.MouseUp += MouseKeyUp;
            PicIcon.MouseUp += MouseKeyUp;
            LblText.MouseUp += MouseKeyUp;
        }

        private void KeyClick(object sender, EventArgs e) => OnClick(e);
        private void MouseKeyDown(object sender, MouseEventArgs e)
        {
            Inverted = !Inverted;
            right.BackColor = left.BackColor = top.BackColor = down.BackColor = BackColor;
        }
        private void MouseKeyUp(object sender, MouseEventArgs e) => Sync();

        public Image _DarkImage;
        public Image _LightImage;
        public Image _DarkImage_Inverted;
        public Image _LightImage_Inverted;
        public string Textes
        {
            get => LblText.Text;
            set => LblText.Text = value;
        }

        public Image DarkImage
        {
            get => _DarkImage;
            set
            {
                _DarkImage = (Inverted && DarkTheme) ? PicIcon.Image = value : value;
            }
        }
        public Image LightImage
        {
            get => _LightImage;
            set
            {
                _LightImage = (Inverted && !DarkTheme) ? PicIcon.Image = value : value;
            }
        }
        public Image DarkImageInverted
        {
            get => _DarkImage_Inverted;
            set
            {
                _DarkImage_Inverted = (!Inverted && DarkTheme) ? PicIcon.Image = value : value;
            }
        }
        public Image LightImageInverted
        {
            get => _LightImage_Inverted;
            set
            {
                _LightImage_Inverted = (!Inverted && !DarkTheme) ? PicIcon.Image = value : value;
            }
        }

        ThemeStatus Status = new ThemeStatus();
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
                BackColor = LblText.BackColor = PicIcon.BackColor = Status.ThemeColor;
                if (Status.DarkTheme)
                {
                    right.BackColor = left.BackColor = top.BackColor = down.BackColor = LblText.ForeColor = SolidSettings.ReverseColorDark;
                    BackgroundImage = _DarkImage;
                }
                else
                {
                    right.BackColor = left.BackColor = top.BackColor = down.BackColor = LblText.ForeColor = SolidSettings.ReverseColorLight;
                    BackgroundImage = _LightImage;
                }
            }
            else
            {
                right.BackColor = left.BackColor = top.BackColor = down.BackColor = LblText.ForeColor = Status.ThemeColor = ThemeColor;
                if (Status.DarkTheme)
                {
                    BackColor = LblText.BackColor = SolidSettings.ReverseColorDark;
                    BackgroundImage = _DarkImage_Inverted;
                }
                else
                {
                    BackColor = LblText.BackColor = SolidSettings.ReverseColorLight;
                    BackgroundImage = _LightImage_Inverted;
                }
            }
            PicIcon.BackColor = ThemeColor;
            ChildSync();

        }
        public void ChildSync()
        {

        }
    }
}
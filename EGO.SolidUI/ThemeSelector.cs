using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGO.SolidUI
{
    public partial class ThemeSelector : IForm
    {
        Color reverse_dark;
        Color reverse_light;
        ChangeWhich _ColorToChange = ChangeWhich.ThemeColor;
        ChangeWhich ColorToChange
        {
            get => _ColorToChange;
            set
            {
                _ColorToChange = value;
                if (Width == 300) Width = MaximumSize.Width;
            }
        }
        public ThemeSelector()
        {
            InitializeComponent();
            lbl_head.MouseDown += MouseKeyDown;
            reverse_dark = SolidSettings.ReverseColorDark_NoTrigger;
            reverse_light = SolidSettings.ReverseColorLight_NoTrigger;

            foreach (KnownColor cc in Enum.GetValues(typeof(KnownColor)))
            {
                string item = Enum.GetName(typeof(KnownColor), cc);
                Color c = Color.FromKnownColor(cc);
                if (c.A == 255)
                {
                    FirstButton bc = new FirstButton();
                    bc.Text = item;
                    bc.MouseClick += Bc_MouseClick;
                    bc.Width = 160;
                    bc.Margin = new Padding(0, 0, 0, 5);
                    bc.ManualInvert = true;
                    bc.ManualThemeColor = true;
                    bc.ManualDarkTheme = true;
                    bc.ThemeColor = c;
                    bc.DarkTheme = true;
                    bc.Inverted = false;
                    lst_known_color.Controls.Add(bc);
                }
            }
        }

        private void Bc_MouseClick(object sender, MouseEventArgs e)
        {
            Color color = ((FirstButton)sender).ThemeColor;
            SetColor(color);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Color color = ((Panel)sender).BackColor;
            SetColor(color);
        }

        private void SetColor(Color color)
        {
            if (ColorToChange == ChangeWhich.ThemeColor)
            {
                ThemeColor = color;
            }
            else if (ColorToChange == ChangeWhich.ReverseDark)
            {
                reverse_dark = color;
            }
            else if (ColorToChange == ChangeWhich.ReverseLight)
            {
                reverse_light = color;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            swb_dark_theme.Enable = SolidSettings.DarkTheme;
            swb_invert.Enable = SolidSettings.Inverted;
            Width = 300;
            this.Sync();
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            SolidSettings.ThemeColor_NoTrigger = ThemeColor;
            SolidSettings.DarkTheme_NoTrigger = DarkTheme;
            SolidSettings.Inverted_NoTrigger = Inverted;
            SolidSettings.ReverseColorDark_NoTrigger = reverse_dark;
            SolidSettings.ReverseColorLight_NoTrigger = reverse_light;
            SolidSettings.SetStyle();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_reset.PerformClick();
            Hide();
        }

        enum ChangeWhich
        {
            ThemeColor,
            ReverseDark,
            ReverseLight
        }

        private void btn_theme_color_Click(object sender, EventArgs e)
        {
            lbl_current_color.Text = "Theme color";
            ColorToChange = ChangeWhich.ThemeColor;
        }

        private void btn_reverse_dark_Click(object sender, EventArgs e)
        {
            lbl_current_color.Text = "Dark color";
            ColorToChange = ChangeWhich.ReverseDark;
        }

        private void btn_reverse_light_Click(object sender, EventArgs e)
        {
            lbl_current_color.Text = "Light color";
            ColorToChange = ChangeWhich.ReverseLight;
        }

        private void swb_dark_theme_Click(object sender, EventArgs e)
        {
            DarkTheme = swb_dark_theme.Enable;
        }

        private void swb_invert_Click(object sender, EventArgs e)
        {
            Inverted = swb_invert.Enable;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_reset.PerformClick();
            Hide();
        }
        private void ThemeSelector_VisibleChanged(object sender, EventArgs e)
        {
            Sync();
            swb_dark_theme.Enable = SolidSettings.DarkTheme;
            swb_invert.Enable = SolidSettings.Inverted;
        }
    }
}

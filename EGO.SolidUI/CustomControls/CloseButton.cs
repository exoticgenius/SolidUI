﻿using System;
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
    public partial class CloseButton : PictureBox, IThemeReference
    {

        private static volatile Bitmap Dark = Properties.Resources.close_btn_Dark;
        private static volatile Bitmap Light = Properties.Resources.close_btn_Light;
        private static volatile Bitmap Dark_Inverted = Properties.Resources.close_btn_Dark_Inverted;
        private static volatile Bitmap Light_Inverted = Properties.Resources.close_btn_Light_Inverted;

        private void Sync(object sender, EventArgs e) => Sync();

        private void MouseKeyDown(object sender, MouseEventArgs e)
        {
            MouseOn = true;
        }
        private void MouseKeyUp(object sender, MouseEventArgs e)
        {
            MouseOn = false;
        }
        public CloseButton()
        {
            ManualInvert = false;
            BackgroundImageLayout = ImageLayout.Stretch;
            DoubleBuffered = true;
            Size = new Size(38, 38);
            MouseDown += MouseKeyDown;
            MouseUp += MouseKeyUp;
            ParentChanged += Sync;
        }

        private bool _mouseOn = false;
        public bool MouseOn
        {
            get => _mouseOn;
            set
            {
                _mouseOn = value;
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
            BackColor = ThemeColor;
            if (Status.Inverted)
            {
                if (Status.DarkTheme)
                {
                    BackgroundImage = Dark_Inverted;
                }
                else
                {
                    BackgroundImage = Light_Inverted;
                }
            }
            else
            {
                if (Status.DarkTheme)
                {
                    BackgroundImage = Dark;
                }
                else
                {
                    BackgroundImage = Light;
                }
            }
            if (MouseOn)
            {
                if (Inverted)
                {
                    BackgroundImage = (DarkTheme) ? Light_Inverted : Dark_Inverted;
                }
                else
                {
                    BackColor = (DarkTheme) ? SolidSettings.ReverseColorLight : SolidSettings.ReverseColorDark;
                }

            }
        }
        public void ChildSync()
        {

        }
    }
}

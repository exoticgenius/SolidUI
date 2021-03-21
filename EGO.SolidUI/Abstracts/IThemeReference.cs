using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGO.SolidUI
{
    public partial interface IThemeReference
    {
        bool Inverted { get; set; }
        bool ReverseInvertAction { get; set; }
        bool ReverseDarkTheme { get; set; }
        bool ManualInvert { get; set; }
        bool ManualDarkTheme { get; set; }
        bool ManualThemeColor { get; set; }
        bool DarkTheme { get; set; }
        Color ThemeColor { get; set; }

        void Sync();
        void ChildSync();
        void PerformStyle();
    }
    public struct ThemeStatus
    {

        public bool Inverted
        {
            get; set;
        }
        public bool ReverseInvertAction
        {
            get; set;
        }
        public bool ReverseDarkTheme
        {
            get; set;
        }
        public bool ManualInvert
        {
            get; set;
        }
        public bool ManualDarkTheme
        {
            get; set;
        }
        public bool ManualThemeColor
        {
            get; set;
        }
        public bool DarkTheme
        {
            get; set;
        }
        public Color ThemeColor
        {
            get; set;
        }
    }
}

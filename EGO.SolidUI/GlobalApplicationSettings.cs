using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGO.SolidUI
{
    public delegate void SettingEvent();
    public static class SolidSettings
    {
        public static event SettingEvent ThemeColorChange;
        public static event SettingEvent ReverseDarkColorChange;
        public static event SettingEvent ReverseLightColorChange;
        public static event SettingEvent DarkThemeChange;
        public static event SettingEvent InvertedChange;
        public static event SettingEvent SetStyleCalled;

        public static ThemeSelector ThemeSelector { get; set; }

        public static Color ReverseColorDark_NoTrigger { get; set; } = Color.FromArgb(10, 10, 10);
        public static Color ReverseColorLight_NoTrigger { get; set; } = Color.FromArgb(245, 245, 245);
        public static Color ThemeColor_NoTrigger { get; set; } = Color.Purple;
        public static bool DarkTheme_NoTrigger { get; set; } = false;
        public static bool Inverted_NoTrigger { get; set; } = false;
        private static bool SetStyleRunning = false;
        static SolidSettings()
        {
            ThemeSelector = new ThemeSelector();
        }
        public static Color ReverseColorDark
        {
            get
            {
                return ReverseColorDark_NoTrigger;
            }
            set
            {
                ReverseColorDark_NoTrigger = value;
                SetStyle();
                ReverseDarkColorChange?.Invoke();
            }
        }
        public static Color ReverseColorLight
        {
            get
            {
                return ReverseColorLight_NoTrigger;
            }
            set
            {
                ReverseColorLight_NoTrigger = value;
                SetStyle();
                ReverseLightColorChange?.Invoke();
            }
        }
        public static Color ThemeColor
        {
            get
            {
                return ThemeColor_NoTrigger;
            }
            set
            {
                ThemeColor_NoTrigger = value;
                SetStyle();
                ThemeColorChange?.Invoke();
            }
        }
        public static bool DarkTheme
        {
            get
            {
                return DarkTheme_NoTrigger;
            }
            set
            {
                DarkTheme_NoTrigger = value;
                SetStyle();
                DarkThemeChange?.Invoke();
            }
        }
        public static bool Inverted
        {
            get
            {
                return Inverted_NoTrigger;
            }
            set
            {
                Inverted_NoTrigger = value;
                SetStyle();
                InvertedChange?.Invoke();
            }
        }

        public static List<IForm> AliveItems { get; set; } = new List<IForm>();

        public static async void SetStyle()
        {
            if (!SetStyleRunning)
            {
                SetStyleRunning = true;
                await Task.Run(Style);
                SetStyleRunning = false;
            }
        }

        private static void Style()
        {
            lock (AliveItems)
            {
                List<IForm> DeadItems = new List<IForm>();
                for (int i = 0, J = AliveItems.Count; i < J; i++)
                {
                    if (AliveItems[i] != null && !AliveItems[i].IsDisposed)
                    {
                        AliveItems[i].Sync();
                    }
                    else DeadItems.Add(AliveItems[i]);
                }

                DeadItems.ForEach(x => AliveItems.Remove(x));
                DeadItems.Clear();
                SetStyleCalled?.Invoke();
            }
        }

        public static Color Fixer(Color themeColor, byte degree)
        {
            int Brightness(Color c) => (int)Math.Sqrt(c.R * c.R * 0.241 + c.G * c.G * 0.691 + c.B * c.B * 0.068);
            int BN = Brightness(themeColor);

            return Color.FromArgb(
                BN > 127 && themeColor.R > degree ? themeColor.R - degree : BN < 127 && themeColor.R + degree < 256 ? themeColor.R + degree : themeColor.R,
                BN > 127 && themeColor.G > degree ? themeColor.G - degree : BN < 127 && themeColor.G + degree < 256 ? themeColor.G + degree : themeColor.G,
                BN > 127 && themeColor.B > degree ? themeColor.B - degree : BN < 127 && themeColor.B + degree < 256 ? themeColor.B + degree : themeColor.B);
        }
    }
}

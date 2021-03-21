using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EGO.SolidUI
{
    [DefaultEvent("TextChanged")]
    public partial class FirstTextbox : UserControl, IThemeReference
    {
        public override bool Focused => TXT.Focused;
#pragma warning disable CS0108
        public event EventHandler TextChanged;
        public event KeyEventHandler KeyDown;
        public event MouseEventHandler MouseDown;
#pragma warning restore CS0108
        public bool HideSelection
        {
            get => TXT.HideSelection;
            set => TXT.HideSelection = value;
        }
        public bool EnableResponsiveStyle { get; set; }
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public Font Font { get => TXT.Font; set => TXT.Font = value; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        public bool BorderTop { get => top.Visible; set => top.Visible = value; }
        public bool BorderRight { get => right.Visible; set => right.Visible = value; }
        public bool BorderLeft { get => left.Visible; set => left.Visible = value; }
        public bool BorderBottom { get => down.Visible; set => down.Visible = value; }
        public char PasswordChar { get => TXT.PasswordChar; set => TXT.PasswordChar = value; }
        public int SelectionStart { get => TXT.SelectionStart; set => TXT.SelectionStart = value; }
        public bool MultiLine { get => TXT.Multiline; set => TXT.Multiline = value; }
        public string Textes { get => TXT.Text; set => TXT.Text = value; }
        public TextBox ActualTextBox { get => TXT; set => TXT = value; }
        private void TXT_KeyDown(object sender, KeyEventArgs e) => KeyDown?.Invoke(sender, e);
        private void MouseKeyDown(object sender, MouseEventArgs e)
        {
            MouseDown?.Invoke(sender, e);
        }
        private void OnChange(object sender, EventArgs e) => TextChanged?.Invoke(sender, e);
        private void MouseKeyEnter(object sender, EventArgs e)
        {
            if (EnableResponsiveStyle)
            {
                MouseOn = true;
            }
        }
        private void MouseKeyLeave(object sender, EventArgs e)
        {
            if (EnableResponsiveStyle)
            {
                MouseOn = false;
            }
        }
        private void Sync(object sender, EventArgs e) => Sync();
        private void DoResize(object sender, EventArgs e)
        {
            if (TXT.Multiline)
                TXT.Height = Height - 11 - TXT.Margin.Top - TXT.Margin.Bottom;
            else
                Height = TXT.Height + 11 + TXT.Margin.Top + TXT.Margin.Bottom;
            TXT.Width = Width - 4 - TXT.Margin.Left - TXT.Margin.Right;

            TXT.Location = new Point(2 + TXT.Margin.Left, 2 + TXT.Margin.Top);
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
        public FirstTextbox()
        {
            InitializeComponent();
            ManualInvert = false;
            DoubleBuffered = true;
            EnableResponsiveStyle = true;

            Resize += DoResize;
            TXT.Resize += DoResize;
            TXT.BackColor = BackColor;
            ParentChanged += Sync;

            MouseEnter += MouseKeyEnter;
            TXT.MouseEnter += MouseKeyEnter;
            left.MouseEnter += MouseKeyEnter;
            right.MouseEnter += MouseKeyEnter;
            top.MouseEnter += MouseKeyEnter;
            down.MouseEnter += MouseKeyEnter;

            MouseLeave += MouseKeyLeave;
            TXT.MouseLeave += MouseKeyLeave;
            left.MouseLeave += MouseKeyLeave;
            right.MouseLeave += MouseKeyLeave;
            top.MouseLeave += MouseKeyLeave;
            down.MouseLeave += MouseKeyLeave;

            TXT.MouseDown += MouseKeyDown;
            left.MouseDown += MouseKeyDown;
            right.MouseDown += MouseKeyDown;
            top.MouseDown += MouseKeyDown;
            down.MouseDown += MouseKeyDown;

            TXT.TextChanged += OnChange;

        }




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


            TXT.BackColor = BackColor;
            TXT.ForeColor = top.BackColor = down.BackColor = right.BackColor = left.BackColor = ForeColor;

            if (MouseOn)
            {
                if (Inverted)
                {
                    TXT.BackColor = BackColor = (DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight;
                    TXT.ForeColor = ThemeColor;
                }
                else
                {
                    TXT.BackColor = BackColor = ThemeColor;
                    TXT.ForeColor = (DarkTheme) ? SolidSettings.ReverseColorDark : SolidSettings.ReverseColorLight;
                }

            }

            ChildSync();

        }
        public void ChildSync()
        {

        }
    }
}

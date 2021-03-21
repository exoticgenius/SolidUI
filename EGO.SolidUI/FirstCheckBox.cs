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
    public partial class FirstCheckBox : UserControl
    {
        private ThemeStatus Status = new ThemeStatus();
        public FirstCheckBox()
        {
            InitializeComponent();
        }

        public bool Inverted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool ManualInvert { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool ReverseInvertAction
        {
            get => Status.ReverseInvertAction;
            set => Status.ReverseInvertAction = value;
        }
        public bool DarkTheme { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Color ThemeColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Color ReverseColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ChildSync()
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            throw new NotImplementedException();
        }
    }
}

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
    partial class FirstTextbox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.down = new System.Windows.Forms.PictureBox();
            this.top = new System.Windows.Forms.PictureBox();
            this.right = new System.Windows.Forms.PictureBox();
            this.left = new System.Windows.Forms.PictureBox();
            this.TXT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).BeginInit();
            this.SuspendLayout();
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.Transparent;
            this.down.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.down.Location = new System.Drawing.Point(2, 36);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(266, 2);
            this.down.TabIndex = 7;
            this.down.TabStop = false;
            // 
            // top
            // 
            this.top.BackColor = System.Drawing.Color.Transparent;
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Location = new System.Drawing.Point(2, 0);
            this.top.Margin = new System.Windows.Forms.Padding(0);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(266, 2);
            this.top.TabIndex = 6;
            this.top.TabStop = false;
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.Transparent;
            this.right.Dock = System.Windows.Forms.DockStyle.Right;
            this.right.Location = new System.Drawing.Point(268, 0);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(2, 38);
            this.right.TabIndex = 5;
            this.right.TabStop = false;
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.Transparent;
            this.left.Dock = System.Windows.Forms.DockStyle.Left;
            this.left.Location = new System.Drawing.Point(0, 0);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(2, 38);
            this.left.TabIndex = 4;
            this.left.TabStop = false;
            // 
            // TXT
            // 
            this.TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT.BackColor = System.Drawing.Color.White;
            this.TXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXT.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT.ForeColor = System.Drawing.Color.White;
            this.TXT.Location = new System.Drawing.Point(2, 2);
            this.TXT.Margin = new System.Windows.Forms.Padding(0);
            this.TXT.Name = "TXT";
            this.TXT.Size = new System.Drawing.Size(266, 27);
            this.TXT.TabIndex = 0;
            this.TXT.Text = "||||||";
            this.TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TXT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_KeyDown);
            // 
            // FirstTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.down);
            this.Controls.Add(this.top);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.TXT);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FirstTextbox";
            this.Size = new System.Drawing.Size(270, 38);
            ((System.ComponentModel.ISupportInitialize)(this.down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public TextBox TXT;
        public PictureBox down;
        public PictureBox top;
        public PictureBox right;
        public PictureBox left;

        #endregion

#pragma warning disable CS0108
#pragma warning restore CS0108
    }
}

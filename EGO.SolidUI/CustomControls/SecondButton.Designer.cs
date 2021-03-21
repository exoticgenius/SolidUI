
namespace EGO.SolidUI
{
    partial class SecondButton
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
            this.right = new System.Windows.Forms.PictureBox();
            this.left = new System.Windows.Forms.PictureBox();
            this.top = new System.Windows.Forms.PictureBox();
            this.down = new System.Windows.Forms.PictureBox();
            this.PicIcon = new System.Windows.Forms.PictureBox();
            this.LblText = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.White;
            this.right.Dock = System.Windows.Forms.DockStyle.Right;
            this.right.Location = new System.Drawing.Point(78, 0);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(2, 80);
            this.right.TabIndex = 1;
            this.right.TabStop = false;
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.White;
            this.left.Dock = System.Windows.Forms.DockStyle.Left;
            this.left.Location = new System.Drawing.Point(0, 0);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(2, 80);
            this.left.TabIndex = 0;
            this.left.TabStop = false;
            // 
            // top
            // 
            this.top.BackColor = System.Drawing.Color.White;
            this.top.Dock = System.Windows.Forms.DockStyle.Top;
            this.top.Location = new System.Drawing.Point(2, 0);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(76, 2);
            this.top.TabIndex = 2;
            this.top.TabStop = false;
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.White;
            this.down.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.down.Location = new System.Drawing.Point(2, 78);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(76, 2);
            this.down.TabIndex = 3;
            this.down.TabStop = false;
            // 
            // PicIcon
            // 
            this.PicIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicIcon.Location = new System.Drawing.Point(0, 0);
            this.PicIcon.Margin = new System.Windows.Forms.Padding(0);
            this.PicIcon.Name = "PicIcon";
            this.PicIcon.Size = new System.Drawing.Size(80, 50);
            this.PicIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicIcon.TabIndex = 4;
            this.PicIcon.TabStop = false;
            // 
            // LblText
            // 
            this.LblText.AccessibleName = "TextArea";
            this.LblText.AutoEllipsis = true;
            this.LblText.BackColor = System.Drawing.Color.Transparent;
            this.LblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblText.ForeColor = System.Drawing.Color.White;
            this.LblText.Location = new System.Drawing.Point(0, 0);
            this.LblText.Name = "LblText";
            this.LblText.Size = new System.Drawing.Size(80, 29);
            this.LblText.TabIndex = 5;
            this.LblText.Text = "Text";
            this.LblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PicIcon);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LblText);
            this.splitContainer1.Size = new System.Drawing.Size(80, 80);
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 6;
            // 
            // SecondButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.down);
            this.Controls.Add(this.top);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "SecondButton";
            this.Size = new System.Drawing.Size(80, 80);
            ((System.ComponentModel.ISupportInitialize)(this.right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicIcon)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox left;
        private System.Windows.Forms.PictureBox right;
        private System.Windows.Forms.PictureBox top;
        private System.Windows.Forms.PictureBox down;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.PictureBox PicIcon;

        public System.Windows.Forms.Label LblText;
    }
}


namespace EGO.SolidUI
{
    partial class SwitchButton
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
            this.components = new System.ComponentModel.Container();
            this.mover = new System.Windows.Forms.Timer(this.components);
            this.body = new System.Windows.Forms.Panel();
            this.row = new System.Windows.Forms.Panel();
            this.dot = new System.Windows.Forms.Panel();
            this.body.SuspendLayout();
            this.row.SuspendLayout();
            this.SuspendLayout();
            // 
            // mover
            // 
            this.mover.Interval = 4;
            this.mover.Tick += new System.EventHandler(this.Mover_Tick);
            // 
            // body
            // 
            this.body.BackColor = System.Drawing.Color.White;
            this.body.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.body.Controls.Add(this.row);
            this.body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body.Location = new System.Drawing.Point(0, 0);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(56, 30);
            this.body.TabIndex = 0;
            this.body.Click += new System.EventHandler(this.SwitchButton_Click);
            // 
            // row
            // 
            this.row.BackColor = System.Drawing.Color.Black;
            this.row.Controls.Add(this.dot);
            this.row.Location = new System.Drawing.Point(2, 2);
            this.row.Margin = new System.Windows.Forms.Padding(0);
            this.row.Name = "row";
            this.row.Size = new System.Drawing.Size(52, 26);
            this.row.TabIndex = 0;
            this.row.Click += new System.EventHandler(this.SwitchButton_Click);
            // 
            // dot
            // 
            this.dot.BackColor = System.Drawing.Color.White;
            this.dot.Location = new System.Drawing.Point(29, 3);
            this.dot.Margin = new System.Windows.Forms.Padding(0);
            this.dot.Name = "dot";
            this.dot.Size = new System.Drawing.Size(20, 20);
            this.dot.TabIndex = 1;
            this.dot.Click += new System.EventHandler(this.SwitchButton_Click);
            // 
            // SwitchButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.body);
            this.Name = "SwitchButton";
            this.Size = new System.Drawing.Size(56, 30);
            this.body.ResumeLayout(false);
            this.row.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer mover;
        private System.Windows.Forms.Panel body;
        private System.Windows.Forms.Panel row;
        private System.Windows.Forms.Panel dot;
    }
}

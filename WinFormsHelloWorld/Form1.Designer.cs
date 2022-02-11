
namespace WinFormsHelloWorld
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxShowHello = new System.Windows.Forms.TextBox();
            this.buttonSayHello = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxShowHello
            // 
            this.textBoxShowHello.Location = new System.Drawing.Point(134, 12);
            this.textBoxShowHello.Name = "textBoxShowHello";
            this.textBoxShowHello.Size = new System.Drawing.Size(552, 23);
            this.textBoxShowHello.TabIndex = 0;
            this.textBoxShowHello.TextChanged += new System.EventHandler(this.textBoxShowHello_TextChanged);
            // 
            // buttonSayHello
            // 
            this.buttonSayHello.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonSayHello.Location = new System.Drawing.Point(134, 57);
            this.buttonSayHello.Name = "buttonSayHello";
            this.buttonSayHello.Size = new System.Drawing.Size(552, 23);
            this.buttonSayHello.TabIndex = 1;
            this.buttonSayHello.Text = "Click Me";
            this.buttonSayHello.UseVisualStyleBackColor = true;
            this.buttonSayHello.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSayHello);
            this.Controls.Add(this.textBoxShowHello);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Form1";
            this.Text = "Click Me";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxShowHello;
        private System.Windows.Forms.Button buttonSayHello;
    }
}


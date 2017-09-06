namespace ChromeForDoNet
{
    partial class frmSYS_WebBrowerChrome
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webKitBrower4Net21 = new ChromeForDoNet.WebKitBrower4Net2();
            this.SuspendLayout();
            // 
            // webKitBrower4Net21
            // 
            this.webKitBrower4Net21.AllowDrop = true;
            this.webKitBrower4Net21.BackColor = System.Drawing.Color.White;
            this.webKitBrower4Net21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webKitBrower4Net21.Location = new System.Drawing.Point(0, 0);
            this.webKitBrower4Net21.Name = "webKitBrower4Net21";
            this.webKitBrower4Net21.Password = null;
            this.webKitBrower4Net21.PrivateBrowsing = false;
            this.webKitBrower4Net21.Size = new System.Drawing.Size(659, 417);
            this.webKitBrower4Net21.TabIndex = 0;
            this.webKitBrower4Net21.Url = null;
            this.webKitBrower4Net21.Username = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 417);
            this.Controls.Add(this.webKitBrower4Net21);
            this.Name = "Chrome2";
            this.Text = "Chrome2";
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
           
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WebKitBrower4Net2 webKitBrower4Net21;
    }
}


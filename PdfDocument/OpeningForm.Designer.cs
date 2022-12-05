
namespace PdfDocument
{
    partial class OpeningForm
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
            this.CreateOrderBtn = new System.Windows.Forms.Button();
            this.PreviousOrdersBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateOrderBtn
            // 
            this.CreateOrderBtn.Location = new System.Drawing.Point(152, 324);
            this.CreateOrderBtn.Name = "CreateOrderBtn";
            this.CreateOrderBtn.Size = new System.Drawing.Size(278, 138);
            this.CreateOrderBtn.TabIndex = 0;
            this.CreateOrderBtn.Text = "Sipariş Oluştur";
            this.CreateOrderBtn.UseVisualStyleBackColor = true;
            this.CreateOrderBtn.Click += new System.EventHandler(this.CreateOrderBtn_Click);
            // 
            // PreviousOrdersBtn
            // 
            this.PreviousOrdersBtn.Location = new System.Drawing.Point(603, 324);
            this.PreviousOrdersBtn.Name = "PreviousOrdersBtn";
            this.PreviousOrdersBtn.Size = new System.Drawing.Size(278, 138);
            this.PreviousOrdersBtn.TabIndex = 1;
            this.PreviousOrdersBtn.Text = "Geçmiş Siparişler";
            this.PreviousOrdersBtn.UseVisualStyleBackColor = true;
            this.PreviousOrdersBtn.Click += new System.EventHandler(this.PreviousOrdersBtn_Click);
            // 
            // OpeningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 602);
            this.Controls.Add(this.PreviousOrdersBtn);
            this.Controls.Add(this.CreateOrderBtn);
            this.Name = "OpeningForm";
            this.Text = "OpeningForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateOrderBtn;
        private System.Windows.Forms.Button PreviousOrdersBtn;
    }
}
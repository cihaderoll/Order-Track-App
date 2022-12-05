
namespace PdfDocument
{
    partial class PreviousOrdersForm
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
            this.PreviousOrderList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PreviousOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviousOrderList
            // 
            this.PreviousOrderList.AllowUserToAddRows = false;
            this.PreviousOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PreviousOrderList.Location = new System.Drawing.Point(12, 140);
            this.PreviousOrderList.Name = "PreviousOrderList";
            this.PreviousOrderList.ReadOnly = true;
            this.PreviousOrderList.RowTemplate.Height = 25;
            this.PreviousOrderList.Size = new System.Drawing.Size(776, 298);
            this.PreviousOrderList.TabIndex = 0;
            // 
            // PreviousOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PreviousOrderList);
            this.Name = "PreviousOrdersForm";
            this.Text = "PreviousOrdersForm";
            this.Load += new System.EventHandler(this.PreviousOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreviousOrderList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PreviousOrderList;
    }
}
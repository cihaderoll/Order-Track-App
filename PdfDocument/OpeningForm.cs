using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfDocument
{
    public partial class OpeningForm : Form
    {
        public OpeningForm()
        {
            InitializeComponent();
        }

        private void CreateOrderBtn_Click(object sender, EventArgs e)
        {
            GeneralInfoForm generalInfoForm = new GeneralInfoForm();

            generalInfoForm.Show();
        }

        private void PreviousOrdersBtn_Click(object sender, EventArgs e)
        {
            PreviousOrdersForm previousOrdersForm = new PreviousOrdersForm();

            previousOrdersForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfDocument
{
    public partial class GeneralInfoForm : Form
    {
        public static GeneralInfoForm GeneralInfoFormInstance;
        public static TextBox FormTitle { get; set; }
        public static TextBox FormAddress { get; set; }
        public static TextBox FormOrderNumber { get; set; }
        public static DateTimePicker FormOrderDate { get; set; }
        public static DateTimePicker FormDeliverDate { get; set; }
        public static TextBox FormCustomerName { get; set; }
        public static TextBox FormPhoneNumber { get; set; }
        public static RadioButton FormIsPaidYes { get; set; }
        public static RadioButton FormIsPaidNo { get; set; }

        public GeneralInfoForm()
        {
            InitializeComponent();
            GeneralInfoFormInstance = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTitle = titleInput;
            FormAddress = addressInput;
            FormOrderNumber = orderNumberInput;
            FormOrderDate = orderDateInput;
            FormDeliverDate = deliverDateInput;
            FormCustomerName = customerNameInput;
            FormPhoneNumber = phoneNumberInput;
            FormIsPaidYes = isPaidYesInput;
            FormIsPaidNo = isPaidNoInput;

            OrderListForm orderListForm = new OrderListForm();

            orderListForm.Show();
        }
    }
}

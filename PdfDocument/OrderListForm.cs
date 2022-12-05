using Domain;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PdfDocument
{
    public partial class OrderListForm : Form
    {
        MongoClient mongoClient;
        IMongoDatabase mongoDatabase;
        IMongoCollection<Order> orderCollection;

        public OrderListForm()
        {
            InitializeComponent();


            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://OrderForm1234:KzvMejSpZeC7zbrD@orderformcluster.etjdb2v.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            mongoClient = new MongoClient(settings);
            mongoDatabase = mongoClient.GetDatabase("OrderForm");
            orderCollection = mongoDatabase.GetCollection<Order>("Orders");
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            OrderList.View = View.Details;
            OrderList.GridLines = true;
            OrderList.FullRowSelect = true;
            OrderList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            OrderList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            OrderList.Columns.Add("Özellikler");
            OrderList.Columns.Add("Kilogram");
            OrderList.Columns.Add("Birim Fiyat");
            OrderList.Columns.Add("Toplam");

            var totalWidth = OrderList.Width;

            OrderList.Columns[0].Width = totalWidth / 10 * 4;
            OrderList.Columns[1].Width = totalWidth / 10 * 2;
            OrderList.Columns[2].Width = totalWidth / 10 * 2;
            OrderList.Columns[3].Width = totalWidth / 10 * 2;

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var productName = ProductTitle.Text;
            var unitPrice = UnitPrice.Value;
            var weight = Weight.Value;

            //validation
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Lütfen ürün adını giriniz.");
                return;
            }
            else if (unitPrice <= 0)
            {
                MessageBox.Show("Birim fiyatı 0 veya daha küçük olamaz");
                return;
            }
            else if (weight <= 0)
            {
                MessageBox.Show("Ürünün kilogramı 0'dan küçük olamaz");
                return;
            }

            var totalPrice = weight * unitPrice;

            string[] row = { productName, unitPrice.ToString(), weight.ToString(), totalPrice.ToString() };
            var data = new ListViewItem(row);
            OrderList.Items.Add(data);
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            #region Collect Data

            var allData = new OrderInfoDto
            {
                Title = GeneralInfoForm.FormTitle.Text,
                Address = GeneralInfoForm.FormAddress.Text,
                OrderNumber = GeneralInfoForm.FormOrderNumber.Text,
                OrderDate = GeneralInfoForm.FormOrderDate.Value,
                CustomerName = GeneralInfoForm.FormCustomerName.Text,
                PhoneNumber = GeneralInfoForm.FormPhoneNumber.Text,
                DeliverDate = GeneralInfoForm.FormDeliverDate.Value,
                IsPaid = GeneralInfoForm.FormIsPaidYes.Checked,
            };

            var orderList = new List<OrderDto>();

            foreach (ListViewItem item in OrderList.Items)
            {
                var order = new OrderDto
                {
                    OrderName = item.Text,
                    OrderWeight = item.SubItems[1].Text,
                    UnitPrice = item.SubItems[2].Text,
                    TotalPrice = item.SubItems[3].Text
                };

                orderList.Add(order);
            }

            allData.OrderList = orderList;

            #endregion

            #region Db Insert

            var totalPrice = default(decimal);

            foreach (var item in orderList)
            {
                if (decimal.TryParse(item.TotalPrice, out var priceDecimal))
                    totalPrice += priceDecimal;
            }

            var orderEntity = new Order
            {
                OrderNumber = allData.OrderNumber,
                OrderDate = allData.OrderDate,
                DeliverDate = allData.DeliverDate,
                IsPaid = allData.IsPaid,
                TotalPrice = totalPrice,
                CustomerFullName = allData.CustomerName
            };

            var orderProductList = new List<OrderProduct>();

            foreach (var orderItem in orderList)
            {
                var orderRecord = new OrderProduct
                {
                    OrderName = orderItem.OrderName
                };

                if (decimal.TryParse(orderItem.UnitPrice, out var unitPriceDecimal))
                    orderRecord.UnitPrice = unitPriceDecimal;
                if (decimal.TryParse(orderItem.OrderWeight, out var orderWeightDecimal))
                    orderRecord.Weight = orderWeightDecimal;

                orderProductList.Add(orderRecord);
            }

            orderEntity.OrderProducts = orderProductList;

            //adding entity to db
            orderCollection.InsertOne(orderEntity);

            #endregion

            #region Creating Pdf

            var pdfString = GetTableHtmlString(allData);

            var desktopEnv = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            var pdfWriter = new PdfWriter(desktopEnv + "\\SiparisFormu_" + allData.CustomerName + ".pdf", new WriterProperties());

            iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfWriter);

            Document document = new Document(pdfDocument, PageSize.A4);
            document.GetPdfDocument().SetDefaultPageSize(PageSize.A4.Rotate());

            HtmlConverter.ConvertToPdf(pdfString, pdfDocument, new ConverterProperties());

            MessageBox.Show($"SiparisFormu_{allData.CustomerName} Masaüstünde Oluşturuldu.");

            #endregion

            return;
        }

        private string GetTableHtmlString(OrderInfoDto orderInfo)
        {
            var orderList = orderInfo.OrderList;

            var orderListStr = string.Empty;

            var totalPrice = default(decimal);

            foreach (var item in orderList)
            {
                orderListStr += $"<tr><td colspan='2'>{item.OrderName}</td><td colspan='1'>{string.Format("{0:0.00}", item.OrderWeight)}</td><td colspan='1'>{string.Format("{0:0.00}", item.UnitPrice)}</td><td colspan='1'>{string.Format("{0:0.00}", item.TotalPrice)}</td></tr>";

                if (decimal.TryParse(item.TotalPrice, out var priceDecimal))
                    totalPrice += priceDecimal;
            }

            var allHtml = $"<!DOCTYPE html><html lang='en'><head><style>table{{border-spacing: 0ch; display: inline-table;}}td{{border: 2px solid black;padding: 10px;text-align: center;}}.table-div{{ width: 47%; display: inline-block;margin-right: 30px;}}</style></head><body>";

            var tableStr = $"<div class='table-div'><table><tr><td colspan='5'>{ orderInfo.Title}</td></tr><tr><td colspan='3'>{orderInfo.Address}</td><td colspan='1'>SİP NO:</td><td colspan='1'>{ orderInfo.OrderNumber}</td></tr><tr><td colspan='1'>Tarih</td><td colspan='1'>Müşteri adı</td><td colspan='3'>{orderInfo.CustomerName}</td></tr><tr><td colspan='1'>{orderInfo.OrderDate}</td><td colspan='1'>Telefon:</td><td colspan='2'>{orderInfo.PhoneNumber}</td><td colspan='1'>Evet</td></tr><tr><td colspan='1'>Teslim Tarihi</td><td colspan='1'>{orderInfo.DeliverDate}</td><td colspan='2'>Ödeme Yapıldı mı:</td><td colspan='1'>Hayır</td ></tr><tr><td colspan='2'>ÖZELLİKLER</ td ><td colspan='1'>KG</td><td colspan='1'>BR.FİYAT</td><td colspan='1'>TOPLAM</td></tr>";

            tableStr += orderListStr + $"<tr><td colspan='1'>Siparişi Alan</td><td colspan='1'></td><td colspan='2'>Genel Toplam</td><td colspan='1'>{totalPrice}</td></tr></table></div>";

            allHtml += tableStr + tableStr + $"</body></html>";

            return allHtml;
        }

        private void CopyStream(Stream stream, string destPath)
        {
            using (var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
        }

        private bool ValidateFormData(OrderInfoDto data)
        {
            if (!data.OrderList.Any())
                return false;

            Regex validatePhoneNumberRegex = new Regex("^\\+?[1-9][0-9]{7,14}$");
            validatePhoneNumberRegex.IsMatch("+12223334444"); // returns True

            return true;
        }
    }
}

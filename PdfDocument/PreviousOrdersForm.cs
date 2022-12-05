using Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PdfDocument
{
    public partial class PreviousOrdersForm : Form
    {
        MongoClient mongoClient;
        IMongoDatabase mongoDatabase;
        IMongoCollection<Order> orderCollection;
        public const int COLUMN_COUNT = 6;

        public PreviousOrdersForm()
        {
            InitializeComponent();

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://OrderForm1234:KzvMejSpZeC7zbrD@orderformcluster.etjdb2v.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            mongoClient = new MongoClient(settings);
            mongoDatabase = mongoClient.GetDatabase("OrderForm");
            orderCollection = mongoDatabase.GetCollection<Order>("Orders");
        }

        private void PreviousOrdersForm_Load(object sender, EventArgs e)
        {

            var orderList = from order in orderCollection.AsQueryable()
                            select order;

            var list = orderList.ToList().Select(k => new PreviousOrdersDto
            {
                CustomerFullName = k.CustomerFullName,
                DeliverDate = k.DeliverDate,
                IsPaid = k.IsPaid,
                OrderDate = k.OrderDate,
                OrderNumber = k.OrderNumber,
                TotalPrice = k.TotalPrice
            }).ToList();

            DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
            uninstallButtonColumn.Name = "İşlemler";
            uninstallButtonColumn.Text = "ürünler";

            PreviousOrderList.ColumnCount = COLUMN_COUNT;

            PreviousOrderList.Columns[0].Name = "Müşteri Adı";
            PreviousOrderList.Columns[1].Name = "Teslim Tarihi";
            PreviousOrderList.Columns[2].Name = "Ödeme Yapıldı Mı?";
            PreviousOrderList.Columns[3].Name = "Sipariş Tarihi";
            PreviousOrderList.Columns[4].Name = "Sipariş Numarası";
            PreviousOrderList.Columns[5].Name = "Toplam Fiyat";
            PreviousOrderList.Columns.Insert(6, uninstallButtonColumn);

            var totalWidth = PreviousOrderList.Width;
            PreviousOrderList.Columns[0].Width = totalWidth / COLUMN_COUNT;
            PreviousOrderList.Columns[1].Width = totalWidth / COLUMN_COUNT;
            PreviousOrderList.Columns[2].Width = totalWidth / COLUMN_COUNT;
            PreviousOrderList.Columns[3].Width = totalWidth / COLUMN_COUNT;
            PreviousOrderList.Columns[4].Width = totalWidth / COLUMN_COUNT;
            PreviousOrderList.Columns[5].Width = totalWidth / COLUMN_COUNT;

            foreach (var item in list)
            {
                var index = PreviousOrderList.Rows.Add();

                PreviousOrderList.Rows[index].Cells[0].Value = item.CustomerFullName;
                PreviousOrderList.Rows[index].Cells[1].Value = item.DeliverDate;
                PreviousOrderList.Rows[index].Cells[2].Value = item.IsPaid;
                PreviousOrderList.Rows[index].Cells[3].Value = item.OrderDate;
                PreviousOrderList.Rows[index].Cells[4].Value = item.OrderNumber;
                PreviousOrderList.Rows[index].Cells[5].Value = item.TotalPrice;
            }
        }
    }
}

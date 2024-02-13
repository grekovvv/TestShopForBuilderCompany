using DevExpress.XtraPivotGrid;
using DevExpress.XtraRichEdit.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestShopForBuilderCompany.Db;
using DevExpress.XtraEditors.Controls;

namespace TestShopForBuilderCompany
{
    public partial class Report : Form
    {
        private ShopSQL dbContext;
        private DateTime startDate;
        private DateTime endDate;
        private int CustomerId;
        public Report()
        {
            InitializeComponent();
            dbContext = new ShopSQL();
            lookUpEditInit();


        }
        private void lookUpEditInit()
        {
            var clients = dbContext.Clients.ToList();

            lookUpEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            lookUpEdit1.Properties.DataSource = clients;
            lookUpEdit1.Properties.DisplayMember = "Name";
            lookUpEdit1.Properties.ValueMember = "Id";
            lookUpEdit1.EditValue = 0;
            lookUpEdit1.Properties.NullText = "Выберите клиента";
        }

        private void LoadSalesReport()
        {
            dbContext = new ShopSQL();
            var salesReportData = from orderDetail in dbContext.OrderDetails
                                  join order in dbContext.Orders on orderDetail.OrderId equals order.Id
                                  join product in dbContext.Products on orderDetail.ProductId equals product.Id
                                  where order.CustomerId == CustomerId
                                        && order.OrderDate >= startDate && order.OrderDate <= endDate
                                  group orderDetail by new { Year = order.OrderDate.Year, Month = order.OrderDate.Month } into g
                                  select new
                                  {
                                      Year = g.Key.Year,
                                      Month = g.Key.Month,
                                      TotalSaleAmount = g.Sum(od => od.Quantity * od.Product.Price)
                                  };

            pivotGridControl1.DataSource = salesReportData.ToList();

            pivotGridControl1.BeginUpdate();
            pivotGridControl1.Fields.Clear();
            pivotGridControl1.Fields.AddRange(new PivotGridField[]
            {
            new PivotGridField { FieldName = "Year", Area = PivotArea.ColumnArea },
            new PivotGridField { FieldName = "Month", Area = PivotArea.ColumnArea },
            new PivotGridField { FieldName = "TotalSaleAmount", Area = PivotArea.DataArea, Caption = "Total Sale Amount" }
            });
            pivotGridControl1.EndUpdate();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateEdit1.EditValue == null)
            {
                dxErrorProvider1.SetError(dateEdit1, "Выберите дату начала");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(dateEdit1, "");
            }

            if (dateEdit2.EditValue == null)
            {
                dxErrorProvider1.SetError(dateEdit2, "Выберите дату окончания");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(dateEdit2, "");
            }

            if (lookUpEdit1.EditValue == null)
            {
                dxErrorProvider1.SetError(lookUpEdit1, "Выберите дату окончания");
                return;
            }
            else
            {
                dxErrorProvider1.SetError(lookUpEdit1, "");
            }

            startDate = dateEdit1.DateTime;
            endDate = dateEdit2.DateTime;
            CustomerId = (int)lookUpEdit1.EditValue;
            LoadSalesReport();
        }
    }
}

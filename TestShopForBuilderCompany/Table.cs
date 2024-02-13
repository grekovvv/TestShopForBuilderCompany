using DevExpress.CodeParser;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraRichEdit.Model;
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

namespace TestShopForBuilderCompany
{
    public partial class Table : Form
    {
        private ShopSQL dbContext;
        private DateTime startDate;
        private DateTime endDate;
        public Table()
        {
            InitializeComponent();
            dbContext = new ShopSQL();
        }

        private void LoadSalesSummary()
        {
            dbContext = new ShopSQL();
            var salesSummaryData = from orderDetail in dbContext.OrderDetails
                                   join order in dbContext.Orders on orderDetail.OrderId equals order.Id
                                   join product in dbContext.Products on orderDetail.ProductId equals product.Id
                                   join client in dbContext.Clients on order.CustomerId equals client.Id
                                   where order.OrderDate >= startDate && order.OrderDate <= endDate
                                   select new
                                   {
                                       ClientName = client.Name,
                                       ProductName = product.Name,
                                       SaleAmount = orderDetail.Quantity * product.Price // Сумма продажи
                                   };

            pivotGridControl1.DataSource = salesSummaryData.ToList();

            pivotGridControl1.BeginUpdate();
            pivotGridControl1.Fields.Clear();
            pivotGridControl1.Fields.AddRange(new PivotGridField[]
            {
            new PivotGridField { FieldName = "ClientName", Area = PivotArea.RowArea },
            new PivotGridField { FieldName = "ProductName", Area = PivotArea.ColumnArea },
            new PivotGridField { FieldName = "SaleAmount", Area = PivotArea.DataArea, Caption = "Total Sale Amount" }
            });
            pivotGridControl1.EndUpdate();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(dateEdit1.EditValue == null)
            {
                dxErrorProvider1.SetError(dateEdit1, "Выберите дату начала");
            }
            else
            {
                dxErrorProvider1.SetError(dateEdit1, "");
            }

            if (dateEdit2.EditValue == null)
            {
                dxErrorProvider1.SetError(dateEdit2, "Выберите дату окончания");
            }
            else
            {
                dxErrorProvider1.SetError(dateEdit2, "");
            }

            startDate = dateEdit1.DateTime;
            endDate = dateEdit2.DateTime;
            LoadSalesSummary();
        }
    }
}

using DevExpress.Pdf.Native.BouncyCastle.Asn1.BC;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
using TestShopForBuilderCompany.Model;
using TestShopForBuilderCompany.Model.DTO;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.CodeParser;
using DevExpress.Utils.Behaviors.Common;

namespace TestShopForBuilderCompany
{
    public partial class Sells : Form
    {
        private ShopSQL dbContext;
        public Sells()
        {
            InitializeComponent();
            dbContext = new ShopSQL();
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView1.InitNewRow += GridView1_InitNewRow;
            FirstInitialized();
            LoadList();
        }
        public void FirstInitialized()
        {
            var clients = dbContext.Clients.ToList();

            lookUpEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            lookUpEdit1.Properties.DataSource = clients;
            lookUpEdit1.Properties.DisplayMember = "Name";
            lookUpEdit1.Properties.ValueMember = "Id";
            lookUpEdit1.EditValue = 0;
            lookUpEdit1.Validating += lookUpEdit1_Validating;
            lookUpEdit1.Properties.NullText = "Выберите клиента";
        }


        private void GridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["Quantity"], 1);
            view.SetRowCellValue(e.RowHandle, view.Columns["DateInOrder"], DateTime.Now);
        }

        private void Sells_Load(object sender, EventArgs e)
        {
            gridView1.Columns["ClientId"].Visible = false;

            
            var products = dbContext.Products.ToList();

            var repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit.DataSource = products;
            repositoryItemLookUpEdit.ValueMember = "Id";
            repositoryItemLookUpEdit.DisplayMember = "Name";
            repositoryItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name") });

            gridView1.Columns["ProductId"].ColumnEdit = repositoryItemLookUpEdit;
            gridView1.Columns["ProductId"].ColumnEdit.NullText = "Выберите товар";
            
        }

        private void lookUpEdit1_Validating(object sender, CancelEventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            if (edit.EditValue == null || edit.EditValue.ToString() == "0")
            {
                e.Cancel = true;
                dxErrorProvider1.SetError(edit, "Выберите клиента");
            }
            else
            {
                dxErrorProvider1.SetError(edit, "");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = lookUpEdit1.GetSelectedDataRow() as Client;
                if (client == null)
                {
                    dxErrorProvider1.SetError(lookUpEdit1, "Выберите клиента");
                    return;
                }

                Order order = new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerId = client.Id, 
                    Client = client 
                };

                dbContext.Orders.Add(order);
                dbContext.SaveChanges();

                int newOrderId = order.Id;

                var productOrders = (BindingList<ProductOrder>)gridControl1.DataSource;

                foreach (var productOrder in productOrders)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = newOrderId,
                        ProductId = productOrder.ProductId,
                        Quantity = productOrder.Quantity,
                        Order = order,
                        Product = dbContext.Products.Single(x => x.Id == productOrder.ProductId)
                    };

                    dbContext.OrderDetails.Add(orderDetail);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Произошла ошибка при сохранении данных: " + ex.Message);
            }
            

            try
            {
                dbContext.SaveChanges();
                MessageBox.Show("Данные успешно сохранены.");
                LoadList();
                lookUpEdit1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении данных: " + ex.Message);
            }
        }

        private void LoadList()
        {
            gridControl1.DataSource = new BindingList<ProductOrder>();
        }
    }
}

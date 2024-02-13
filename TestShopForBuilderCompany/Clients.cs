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

namespace TestShopForBuilderCompany
{
    public partial class Clients : Form
    {
        private ShopSQL dbContext;
        public Clients()
        {
            InitializeComponent();
            dbContext = new ShopSQL();
            Load += Clients_Load;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView1.InitNewRow += GridView1_InitNewRow;
            LoadClients();
        }
        private void LoadClients()
        {
            dbContext.Clients.Load();
            gridControl1.DataSource = dbContext.Clients.Local.ToBindingList();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            gridView1.Columns["Id"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["Id"].Visible = false;
        }
        private void GridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["Name"], "Имя");
            view.SetRowCellValue(e.RowHandle, view.Columns["DateIn"], DateTime.Now);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            dbContext.SaveChanges();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                int[] selectedRowHandles = gridView1.GetSelectedRows();
                foreach (int rowHandle in selectedRowHandles)
                {
                    if (rowHandle >= 0)
                    {
                        Client clientToDelete = gridView1.GetRow(rowHandle) as Client;

                        dbContext.Clients.Remove(clientToDelete);
                    }
                }

                dbContext.SaveChanges();
                LoadClients();
            }
        }
    }
}

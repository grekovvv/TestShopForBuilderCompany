using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestShopForBuilderCompany.Db;
using TestShopForBuilderCompany.Model;

namespace TestShopForBuilderCompany
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private ShopSQL dbContext;
        public Form1()
        {
            InitializeComponent();
            dbContext = new ShopSQL();
            dbContext.Clients.Load();
            gridControl1.DataSource = dbContext.Clients.Local.ToBindingList();
            Load += Form1_Load;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView1.InitNewRow += GridView1_InitNewRow;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Makes the ID column read-only. Users cannnot edit its values.
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
    }
}

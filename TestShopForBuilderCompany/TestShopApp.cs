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
    public partial class TestShopApp : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private ShopSQL dbContext;
        private Form client;
        private Form product;
        private Form formSales;
        private Form tableSales;
        private Form report;
        public TestShopApp()
        {
            InitializeComponent();
            Load += TestShopApp_Load;
        }

        private void TestShopApp_Load(object sender, EventArgs e)
        {
            if (client == null)
            {
                client = new Clients();
            }

            var fluentContainer = this.fluentDesignFormContainer1;

            client.TopLevel = false;
            client.FormBorderStyle = FormBorderStyle.None;
            client.Dock = DockStyle.Fill;

            fluentContainer.Controls.Clear();

            fluentContainer.Controls.Add(client);

            client.Show();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            if (client == null)
            {
                client = new Clients();
            }

            var fluentContainer = this.fluentDesignFormContainer1;

            client.TopLevel = false;
            client.FormBorderStyle = FormBorderStyle.None;
            client.Dock = DockStyle.Fill;

            fluentContainer.Controls.Clear();

            fluentContainer.Controls.Add(client);

            client.Show();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            if (product == null)
            {
                product = new Products();
            }
            var fluentContainer = this.fluentDesignFormContainer1;

            product.TopLevel = false;
            product.FormBorderStyle = FormBorderStyle.None;
            product.Dock = DockStyle.Fill;

            fluentContainer.Controls.Clear();

            fluentContainer.Controls.Add(product);

            product.Show();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            if (formSales == null)
            {
                formSales = new Sells();
            }

            var fluentContainer = this.fluentDesignFormContainer1;

            formSales.TopLevel = false;
            formSales.FormBorderStyle = FormBorderStyle.None;
            formSales.Dock = DockStyle.Fill;

            fluentContainer.Controls.Clear();

            fluentContainer.Controls.Add(formSales);

            formSales.Show();
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            /*if (product == null)
            {
                product = new Products();
            }
            var fluentContainer = this.fluentDesignFormContainer1;

            product.TopLevel = false;
            product.FormBorderStyle = FormBorderStyle.None;
            product.Dock = DockStyle.Fill;

            fluentContainer.Controls.Clear();

            fluentContainer.Controls.Add(product);

            product.Show();*/
        }
    }
}

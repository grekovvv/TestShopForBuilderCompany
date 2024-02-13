namespace TestShopForBuilderCompany
{
    partial class Table
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pivotGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pivotGridControl1
            // 
            pivotGridControl1.Location = new System.Drawing.Point(12, 54);
            pivotGridControl1.Name = "pivotGridControl1";
            pivotGridControl1.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized;
            pivotGridControl1.Size = new System.Drawing.Size(735, 364);
            pivotGridControl1.TabIndex = 0;
            // 
            // dateEdit1
            // 
            dateEdit1.EditValue = null;
            dateEdit1.Location = new System.Drawing.Point(244, 28);
            dateEdit1.Name = "dateEdit1";
            dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit1.Size = new System.Drawing.Size(129, 20);
            dateEdit1.TabIndex = 1;
            // 
            // dateEdit2
            // 
            dateEdit2.EditValue = null;
            dateEdit2.Location = new System.Drawing.Point(379, 28);
            dateEdit2.Name = "dateEdit2";
            dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEdit2.Size = new System.Drawing.Size(129, 20);
            dateEdit2.TabIndex = 2;
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(333, 9);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(84, 13);
            labelControl1.TabIndex = 3;
            labelControl1.Text = "Выберие период";
            // 
            // simpleButton1
            // 
            simpleButton1.Location = new System.Drawing.Point(535, 25);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(212, 23);
            simpleButton1.TabIndex = 4;
            simpleButton1.Text = "Показать результат";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // dxErrorProvider1
            // 
            dxErrorProvider1.ContainerControl = this;
            // 
            // Table
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(simpleButton1);
            Controls.Add(labelControl1);
            Controls.Add(dateEdit2);
            Controls.Add(dateEdit1);
            Controls.Add(pivotGridControl1);
            Name = "Table";
            Text = "Table";
            ((System.ComponentModel.ISupportInitialize)pivotGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxErrorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}
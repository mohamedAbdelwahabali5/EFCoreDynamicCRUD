using EFProject.Context;
using EFProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using System.Data;
using EFProject.Utils;
using System.Collections.Generic;
namespace EFProject
{
    partial class AddForm : Form
    {
        
        private System.ComponentModel.IContainer components = null;
        public PrContext db = new PrContext();


        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private string tableName;

        public AddForm(string table)
        {
            InitializeComponent();
            tableName = table;
            this.Text = $"Add Data to {tableName}";
            Utils.Utils.loadDataFromDB(tableName,db, allData);
            allData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            allData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Utils.Utils.GenerateInsertFields( tableName, panelInputs, db, "Insert");
        }

        
        
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Create instance of the target entity dynamically
                var entityType = db.Model.GetEntityTypes()
                                    .FirstOrDefault(e => e.GetTableName() == tableName);

                if (entityType == null)
                {
                    MessageBox.Show("Invalid table name!");
                    return;
                }

                Type clrType = entityType.ClrType;
                var newEntity = Activator.CreateInstance(clrType);

                foreach (Control ctrl in panelInputs.Controls)
                {
                    if (ctrl is TextBox textBox)
                    {
                        string columnName = textBox.Name.Replace("txt_", "");
                        var property = clrType.GetProperty(columnName);

                        if (property != null)
                        {
                            Type targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                            object convertedValue = string.IsNullOrWhiteSpace(textBox.Text)
                                ? (columnName == "EmployeeId" ? 1 : null)
                                : Convert.ChangeType(textBox.Text, targetType);

                            property.SetValue(newEntity, convertedValue);
                        }
                    }
                }

                db.Add(newEntity);
                db.SaveChanges();

                MessageBox.Show("The data has been inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh DataGridView
                Utils.Utils.loadDataFromDB(tableName, db, allData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            allData = new DataGridView();
            panelInputs = new Panel();
            InsertBtn = new Button();
            ((ISupportInitialize)allData).BeginInit();
            SuspendLayout();
            // 
            // allData
            // 
            allData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            allData.Dock = DockStyle.Top;
            allData.Location = new Point(0, 0);
            allData.Name = "allData";
            allData.Size = new Size(1023, 206);
            allData.TabIndex = 16;
            // 
            // panelInputs
            // 
            panelInputs.Location = new Point(136, 250);
            panelInputs.Name = "panelInputs";
            panelInputs.Size = new Size(681, 487);
            panelInputs.TabIndex = 26;
            // 
            // InsertBtn
            // 
            InsertBtn.BackColor = Color.LightSkyBlue;
            InsertBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            InsertBtn.Location = new Point(884, 474);
            InsertBtn.Name = "InsertBtn";
            InsertBtn.Size = new Size(75, 45);
            InsertBtn.TabIndex = 27;
            InsertBtn.Text = "Insert";
            InsertBtn.UseVisualStyleBackColor = false;
            InsertBtn.Click += InsertBtn_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 749);
            Controls.Add(InsertBtn);
            Controls.Add(panelInputs);
            Controls.Add(allData);
            Name = "AddForm";
            Text = "AddForm";
            ((ISupportInitialize)allData).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView allData;
        private Panel panelInputs;
        private Button InsertBtn;
    }
}
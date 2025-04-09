using EFProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EFProject
{
    partial class UpdateForm
    {
        private System.ComponentModel.IContainer components = null;
        public PrContext db = new PrContext();
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

        private string tableName;
        public UpdateForm(string table)
        {
            InitializeComponent();
            tableName = table;
            Utils.Utils.loadDataFromDB(tableName, db, allData);
            allData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            allData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; 


            Utils.Utils.GenerateInsertFields(tableName, panelInputs, db, "Update");
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (allData.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to update!");
                    return;
                }

                var entityType = db.Model.GetEntityTypes()
                                    .FirstOrDefault(e => e.GetTableName() == tableName);

                if (entityType == null)
                {
                    MessageBox.Show("Invalid table name!");
                    return;
                }

                Type clrType = entityType.ClrType;

                int selectedId = Convert.ToInt32(allData.SelectedRows[0].Cells[0].Value);

                var entityToUpdate = db.Find(clrType, selectedId);

                if (entityToUpdate == null)
                {
                    MessageBox.Show("Entity not found!");
                    return;
                }

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
                                ? null
                                : Convert.ChangeType(textBox.Text, targetType);

                            property.SetValue(entityToUpdate, convertedValue);
                        }
                    }
                }

                // Save changes
                db.SaveChanges();

                MessageBox.Show("The data has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            updateBtn = new Button();
            panelInputs = new Panel();
            allData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)allData).BeginInit();
            SuspendLayout();
            // 
            // updateBtn
            // 
            updateBtn.BackColor = Color.LightSkyBlue;
            updateBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            updateBtn.Location = new Point(819, 324);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(96, 45);
            updateBtn.TabIndex = 30;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // panelInputs
            // 
            panelInputs.Location = new Point(108, 261);
            panelInputs.Name = "panelInputs";
            panelInputs.Size = new Size(681, 380);
            panelInputs.TabIndex = 29;
            // 
            // allData
            // 
            allData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            allData.Dock = DockStyle.Top;
            allData.Location = new Point(0, 0);
            allData.Name = "allData";
            allData.Size = new Size(1021, 251);
            allData.TabIndex = 28;
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 749);
            Controls.Add(updateBtn);
            Controls.Add(panelInputs);
            Controls.Add(allData);
            Name = "UpdateForm";
            Text = "UpdateForm";
            ((System.ComponentModel.ISupportInitialize)allData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button updateBtn;
        private Panel panelInputs;
        private DataGridView allData;
    }
}
using EFProject.Context;
using Microsoft.EntityFrameworkCore;

namespace EFProject
{
    partial class DeleteForm : Form
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

        public DeleteForm(string table)
        {
            InitializeComponent();
            tableName = table;
            Utils.Utils.loadDataFromDB(tableName, db, allData);
            allData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            allData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (allData.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to Delete!");
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

                db.Remove(entityToUpdate);

                // Save changes
                db.SaveChanges();

                MessageBox.Show("The data has been deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            deleteBtn = new Button();
            allData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)allData).BeginInit();
            SuspendLayout();
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.LightSkyBlue;
            deleteBtn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            deleteBtn.Location = new Point(471, 309);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(96, 45);
            deleteBtn.TabIndex = 33;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // allData
            // 
            allData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            allData.Dock = DockStyle.Top;
            allData.Location = new Point(0, 0);
            allData.Name = "allData";
            allData.Size = new Size(1016, 251);
            allData.TabIndex = 31;
            // 
            // DeleteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 450);
            Controls.Add(deleteBtn);
            Controls.Add(allData);
            Name = "DeleteForm";
            Text = "DeleteForm";
            ((System.ComponentModel.ISupportInitialize)allData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button deleteBtn;
        private DataGridView allData;
    }
}
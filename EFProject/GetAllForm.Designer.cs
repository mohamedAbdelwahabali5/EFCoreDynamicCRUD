using EFProject.Context;

namespace EFProject
{
    partial class GetAllForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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

        public GetAllForm(string table)
        {
            InitializeComponent();
            tableName = table;
            Utils.Utils.loadDataFromDB(tableName, db, allData);
            allData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            allData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }


        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            allData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)allData).BeginInit();
            SuspendLayout();
            // 
            // allData
            // 
            allData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            allData.Dock = DockStyle.Fill;
            allData.Location = new Point(0, 0);
            allData.Name = "allData";
            allData.Size = new Size(1020, 450);
            allData.TabIndex = 0;
            // 
            // GetAllForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 450);
            Controls.Add(allData);
            Name = "GetAllForm";
            Text = "GetAllForm";
            ((System.ComponentModel.ISupportInitialize)allData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView allData;
    }
}
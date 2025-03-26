using EFProject.Context;
using Microsoft.EntityFrameworkCore;

namespace EFProject
{
    public partial class Form1 : Form
    {
        public PrContext db = new PrContext();
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            var tableNames = db.Model.GetEntityTypes()
                            .Select(t => t.GetTableName())
                            .ToList();

            tables.DataSource = tableNames;


            string[] operations = new string[4] { "ADD", "GEtALL", "Update", "Delete" };

            crudOP.DataSource = operations;
        }

        private void go_Click(object sender, EventArgs e)
        {
            string selectedTable = tables.SelectedItem?.ToString();
            string selectedOperation = crudOP.SelectedItem?.ToString();

            


            Form targetForm = null;

            switch (selectedOperation)
            {
                case "ADD":
                    MessageBox.Show($"selectedTable: {selectedTable}, selectedOperation: {selectedOperation}");
                    targetForm = new AddForm(selectedTable);
                    targetForm.ShowDialog();
                    break;
                case "GEtALL":
                    targetForm = new GetAllForm(selectedTable);
                    targetForm.ShowDialog();
                    break;
                case "Update":
                    targetForm = new UpdateForm(selectedTable);
                    targetForm.ShowDialog();
                    break;
                case "Delete":
                    targetForm = new DeleteForm(selectedTable);
                    targetForm.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Unknown Process", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

        }
    }
}

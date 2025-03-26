using EFProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Utils
{
    public static class Utils
    {
        public static void  loadDataFromDB(string tableName, PrContext db, DataGridView allData)
        {
            switch (tableName)
            {
                case "Customers":
                    var customers = db.Customers
                        .Select(c => new
                        {
                            c.Id,
                            c.Name,
                            c.FirstName,
                            c.LastName,
                            c.Phone,
                            c.Address1,
                            c.Address2,
                            c.City,
                            c.State,
                            c.PostalCode,
                            c.Country,
                            c.CreditLimit,
                            c.EmployeeId
                        })
                        .ToList();
                    allData.DataSource = customers;
                    break;
                case "Orders":
                    var orders = db.Orders
                        .Select(o => new
                        {
                            o.Id,
                            o.OrderDate,
                            o.RequiredDate,
                            o.ShippedDate,
                            o.Status,
                            o.Commentes,
                            o.CustomerId
                        })
                        .ToList();
                    allData.DataSource = orders;
                    break;
                case "Products":
                    var products = db.Products
                        .Select(p => new
                        {
                            p.Code,
                            p.Name,
                            p.PdtDescription,
                            p.Vendor,
                            p.Scale,
                            p.BuyPrice,
                            p.QtylnStock,
                            p.MSRP,
                            p.ProductLineId,
                        })
                        .ToList();
                    allData.DataSource = products;
                    break;
                case "ProductLines":
                    var productLines = db.ProductLines
                        .Select(pl => new
                        {
                            pl.Id,
                            pl.DescinText,
                            pl.DescinHTML,
                            pl.Image
                        })
                        .ToList();
                    allData.DataSource = productLines;
                    break;
                case "Order_Products":
                    var orderProducts = db.Order_Products
                        .Select(op => new
                        {
                            op.OrderId,
                            op.ProductId,
                            ProductName = op.Product.Name,
                            op.Qty,
                            op.PriceEach
                        })
                        .ToList();
                    allData.DataSource = orderProducts;
                    break;
                case "Payments":
                    var payments = db.Payments
                        .Select(p => new
                        {
                            p.CheckNum,
                            p.PaymentDate,
                            p.Amount,
                            p.CustomerId,
                            CustomerName = p.Customer.Name
                        })
                        .ToList();
                    allData.DataSource = payments;
                    break;
                case "Offices":
                    var offices = db.Offices
                        .Select(o => new
                        {
                            o.Code,
                            o.City,
                            o.Phone,
                            o.Address1,
                            o.Address2,
                            o.State,
                            o.Country,
                            o.PostalCode,
                            o.Ternitory
                        })
                        .ToList();
                    allData.DataSource = offices;
                    break;
                case "Employees":
                    var employees = db.Employees
                        .Select(e => new
                        {
                            e.Id,
                            e.FirstName,
                            e.LastName,
                            e.Extention,
                            e.Email,
                            e.JopTitle,
                            e.ReportsTo,
                            e.OfficeId
                        })
                        .ToList();
                    allData.DataSource = employees;
                    break;
                default:
                    MessageBox.Show("this table is not exist !!!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        public static void GenerateInsertFields(string tableName, Panel panel, PrContext db, string operation)
        {
            var entityType = db.Model.GetEntityTypes()
                    .FirstOrDefault(e => e.GetTableName() == tableName);

            if (entityType == null)
            {
                MessageBox.Show("Invalid table name or entity not found!");
                MessageBox.Show(entityType.ToString());
                return;
            }

            var columnNames = entityType.GetProperties() //to get column Names 
                                        .Select(p => p.GetColumnName())
                                        .ToList();

            int y = 70;
            panel.Controls.Clear();

            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = $"{operation} {tableName} Data";
            titleLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(220, 20);
            titleLabel.AutoSize = true;
            panel.Controls.Add(titleLabel);

            for (int i = 0; i < columnNames.Count; i += 2)
            {
                if (columnNames[i].ToLower() == "id" || columnNames[i].ToLower() == "code" || columnNames[i].ToLower() == "name")
                {
                    i -= 1;
                    continue;
                }

                Label label1 = new Label();
                label1.Text = columnNames[i];
                label1.Font = new Font("Arial", 10, FontStyle.Bold);
                label1.Location = new System.Drawing.Point(50, y);
                label1.Width = 100;

                TextBox textBox1 = new TextBox();
                textBox1.Name = $"txt_{columnNames[i]}";
                textBox1.Location = new System.Drawing.Point(150, y - 3);
                textBox1.Width = 220;
                textBox1.Height = 25;

                panel.Controls.Add(label1);
                panel.Controls.Add(textBox1);

                if (i + 1 < columnNames.Count &&
                    columnNames[i + 1].ToLower() != "id" &&
                    columnNames[i + 1].ToLower() != "code" &&
                    columnNames[i].ToLower() != "name")
                {
                    Label label2 = new Label();
                    label2.Text = columnNames[i + 1];
                    label2.Font = new Font("Arial", 10, FontStyle.Bold);
                    label2.Location = new System.Drawing.Point(400, y);
                    label2.Width = 100;

                    TextBox textBox2 = new TextBox();
                    textBox2.Name = $"txt_{columnNames[i + 1]}";
                    textBox2.Location = new System.Drawing.Point(500, y - 3);
                    textBox2.Width = 220;
                    textBox2.Height = 25;

                    panel.Controls.Add(label2);
                    panel.Controls.Add(textBox2);
                }

                y += 50;
            }

            panel.BackColor = Color.WhiteSmoke;


        }
    }
}

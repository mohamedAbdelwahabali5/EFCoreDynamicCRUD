using EFProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Context
{
    public class PrContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Server=.;DataBase=EFCProject;Trusted_Connection=true;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(conn);


            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Customer Handling
            modelBuilder.Entity<Customer>(c =>
            {
                c.HasKey(c=> c.Id);
                c.Property(c => c.Id).IsRequired();
                c.Property(p => p.Name).HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
                c.Property(c => c.FirstName).HasColumnType("varchar(255)").IsRequired(false);
                c.Property(c => c.LastName).HasColumnType("varchar(255)").IsRequired(false);
                c.Property(c => c.Phone).HasColumnType("varchar(255)").IsRequired(false);
                c.Property(c => c.Address1).HasColumnType("varchar(255)").IsRequired(false);
                c.Property(c => c.Address2).HasColumnType("varchar(255)").IsRequired(false);
                c.Property(c => c.City).HasColumnType("varchar(255)").IsRequired(false);
                c.Property(c => c.State).HasColumnType("varchar(255)").IsRequired(false);
                c.Property(c => c.Country).HasColumnType("varchar(255)").IsRequired(false);
                c.Property(c => c.CreditLimit).HasColumnType("numeric(19, 0)").IsRequired(false);

                /* Relationships with Entities */
                c.HasMany(c => c.payments)
                 .WithOne(p => p.Customer)
                 .HasForeignKey(p => p.CustomerId);
            });
            #endregion

            #region Payment Handling
            modelBuilder.Entity<Payment>(p =>
            {
                p.HasKey(p => p.CheckNum);
                p.Property(p => p.CheckNum).IsRequired();
                p.Property(p => p.PaymentDate).HasColumnType("date").IsRequired(false);
                p.Property(p => p.Amount).HasColumnType("numeric(19, 0)").IsRequired(false);

                /* Relationships with Entities */
            });
            #endregion


            #region Employee Handling
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(e=>e.Id);
                e.Property(e=>e.JopTitle).HasColumnType("varchar(255)").IsRequired(false);
                e.Property(e=>e.FirstName).HasColumnType("varchar(255)").IsRequired(false);
                e.Property(e=>e.LastName).HasColumnType("varchar(255)").IsRequired(false);
                e.Property(e=>e.Email).HasColumnType("varchar(255)").IsRequired(false);
                e.Property(e=>e.Extention).HasColumnType("varchar(255)").IsRequired(false);

                /* Relationships with Entities */
                e.HasMany(e=> e.customers)
                .WithOne(c=>c.Employee)
                .HasForeignKey(e=>e.EmployeeId);

                /* Self relationship */
                e.HasOne(e => e.Manager)
                .WithMany(m => m.SubEmployees)
                .HasForeignKey(m => m.ReportsTo).IsRequired(false);

            });
            #endregion


            #region Office Handling
            modelBuilder.Entity<Office>(o =>
            {
                o.HasKey(o => o.Code);
                o.Property(o => o.City).HasColumnType("varchar(255)").IsRequired(false);
                o.Property(o => o.Phone).HasColumnType("varchar(255)").IsRequired(false);
                o.Property(o => o.Address1).HasColumnType("varchar(255)").IsRequired(false);
                o.Property(o => o.Address2).HasColumnType("varchar(255)").IsRequired(false);
                o.Property(o => o.State).HasColumnType("varchar(255)").IsRequired(false);
                o.Property(o => o.Country).HasColumnType("varchar(255)").IsRequired(false);
                o.Property(o => o.Ternitory).HasColumnType("varchar(255)").IsRequired(false);
                o.Property(o => o.PostalCode).IsRequired(false);


                /* Relationships with Entities */
                o.HasMany(o => o.Employees)
                .WithOne(e=> e.Office)
                .HasForeignKey(e=> e.OfficeId);
                


            });
            #endregion

            #region Product Handling
            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(p => p.Code);
                p.Property(p => p.Name).HasColumnType("varchar(255)").IsRequired(false);
                p.Property(p => p.Scale).IsRequired(false);
                p.Property(p => p.QtylnStock).IsRequired(false);
                p.Property(p => p.Vendor).HasColumnType("varchar(255)").IsRequired(false);
                p.Property(p => p.PdtDescription).HasColumnType("varchar(255)").IsRequired(false);
                p.Property(p => p.MSRP).HasColumnType("varchar(255)").IsRequired(false);
                p.Property(p => p.BuyPrice).HasColumnType("numeric(19,0)").IsRequired(false);



                /* Relationships with Entities */
                p.HasOne(p=> p.ProductLine)
                .WithMany(pl=> pl.products)
                .HasForeignKey(p=> p.ProductLineId);
             
            });
            #endregion

            #region ProductLine Handling
            modelBuilder.Entity<ProductLine>(pl =>
            {
                pl.HasKey(pl => pl.Id);
                pl.Property(pl => pl.DescinText).HasColumnType("varchar(255)").IsRequired(false);
                pl.Property(pl => pl.DescinHTML).HasColumnType("varchar(255)").IsRequired(false);
                pl.Property(pl => pl.Image).HasColumnType("varchar(100)").IsRequired(false);

                /* Relationships with Entities */
                pl.HasMany(p => p.products)
                .WithOne(pl => pl.ProductLine)
                .HasForeignKey(pl => pl.ProductLineId);

            });
            #endregion


            #region Order Handling
            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(o => o.Id);
                o.Property(o => o.OrderDate).HasColumnType("date").IsRequired(false);
                o.Property(o => o.RequiredDate).HasColumnType("date").IsRequired(false);
                o.Property(o => o.ShippedDate).HasColumnType("date").IsRequired(false);
                o.Property(o => o.Status).HasColumnType("varchar(255)").IsRequired(false);
                o.Property(o => o.Commentes).IsRequired(false);
               
                /* Relationships with Entities */
                o.HasOne(o=> o.Customer)
                .WithMany(or=> or.orders)
                .HasForeignKey(o => o.CustomerId);

            });
            #endregion


            #region Order_Product Handling
            modelBuilder.Entity<Order_Product>(o =>
            {
                o.HasKey(o => new { o.OrderId, o.ProductId });
                o.Property(o => o.PriceEach).HasColumnType("numeric(19,0)").IsRequired(false);
                o.Property(o => o.Qty).IsRequired(false);
               
                /* Relationships with Entities */
                o.HasOne(or => or.Order)
                .WithMany(o => o.Order_Products)
                .HasForeignKey(or => or.OrderId);

                o.HasOne(or => or.Product)
                .WithMany(o => o.Order_Products)
                .HasForeignKey(or => or.ProductId);

            });
            #endregion
            base.OnModelCreating(modelBuilder);
        }


        public virtual  DbSet<Customer> Customers { get; set; } 
        public virtual  DbSet<Product> Products { get; set; } 
        public virtual  DbSet<Order> Orders { get; set; } 
        public virtual  DbSet<Payment> Payments { get; set; }
        public virtual DbSet<ProductLine> ProductLines { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Order_Product> Order_Products { get; set; }




    }
}

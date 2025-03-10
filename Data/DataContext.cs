using Microsoft.EntityFrameworkCore;
using OnlineShoping.Models;

namespace OnlineShoping.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Orderitem> Orderitems { get; set; }
        public virtual DbSet<Paymentdetail> Paymentdetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Cart>()
        //       .HasKey(p => p.crt_int_Id);
        //    modelBuilder.Entity<Cart>()
        //       .HasOne(p => p.Prod_int_ID)
        //       .WithMany(p => p.Carts)
        //       .HasForeignKey(p => p.crt_int_prod_id);

        //    modelBuilder.Entity<Cart>()
        //       .HasKey(p => p.crt_int_Id);
        //    modelBuilder.Entity<Cart>()
        //       .HasOne(p => p.usr_int_id)
        //       .WithMany(p => p.Carts)
        //       .HasForeignKey(p => p.crt_int_usrid);

        //    modelBuilder.Entity<Orderdetails>()
        //       .HasKey(p => p.ordetail_int_id);
        //    modelBuilder.Entity<Orderdetails>()
        //       .HasOne(p => p.usr_int_id)
        //       .WithMany(p => p.Orderdetails)
        //       .HasForeignKey(p => p.ordetail_user_id);

        //    modelBuilder.Entity<Orderdetails>()
        //       .HasKey(p => p.ordetail_int_id);
        //    modelBuilder.Entity<Orderdetails>()
        //       .HasOne(p => p.pmd_int_id)
        //       .WithMany(p => p.Orderdetails)
        //       .HasForeignKey(p => p.ordetail_int_pmdid);


        //    modelBuilder.Entity<Orderitem>()
        //       .HasKey(p => p.ord_int_id);
        //    modelBuilder.Entity<Orderitem>()
        //       .HasOne(p => p.ordetail_int_id)
        //       .WithMany(p => p.Orderitems)
        //       .HasForeignKey(p => p.ord_int_orderdetailid);


        //    modelBuilder.Entity<Orderitem>()
        //       .HasKey(p => p.ord_int_id);
        //    modelBuilder.Entity<Orderitem>()
        //       .HasOne(p => p.Prod_int_ID)
        //       .WithMany(p => p.Orderitems)
        //       .HasForeignKey(p => p.ord_product_id);

        //    modelBuilder.Entity<Paymentdetails>()
        //        .HasKey(p => p.pmd_int_id);
        //    modelBuilder.Entity<Paymentdetails>()
        //       .HasOne(p => p.ordetail_int_id)
        //       .WithMany(p => p.Paymentdetails)
        //       .HasForeignKey(p => p.pmd_int_orderid);

        //    modelBuilder.Entity<Products>()
        //       .HasKey(p => p.Prod_int_ID);
        //    modelBuilder.Entity<Products>()
        //       .HasOne(p => p.disc_int_id)
        //       .WithMany(p => p.Products)
        //       .HasForeignKey(p => p.Prod_int_DiscId);


        //    modelBuilder.Entity<Users>()
        //       .HasKey(p => p.usr_int_id);

        //    modelBuilder.Entity<Discount>()
        //      .HasKey(p => p.disc_int_id);






        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.crt_int_Id);

                entity.ToTable("Cart");

                entity.HasOne(p => p.usr_int_id)
                      .WithMany(d => d.Carts)
                      .HasForeignKey(p => p.crt_int_usrid);

                entity.HasOne(p => p.Prod_int_ID)
                      .WithMany(d => d.Carts)
                      .HasForeignKey(p => p.crt_int_prod_id);

                entity.Property(e => e.crt_total)
                     .HasColumnType("money");

                entity.Property(e => e.crt_create_at)
                    .HasColumnType("datetime")
                    .HasColumnName("crt_create_at")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(p => p.disc_int_id);

               // entity.ToTable("Discount");

                entity.Property(e => e.disc_mny_price)
                     .HasColumnType("money");

                entity.Property(e => e.disc_created_at)
                    .HasColumnType("datetime")
                    .HasColumnName("disc_created_at")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.HasKey(p => p.ordetail_int_id);

              //  entity.ToTable("Orderdetails");

                entity.HasOne(p => p.usr_int_id)
                      .WithMany(d => d.Orderdetails)
                      .HasForeignKey(p => p.ordetail_user_id);

                entity.HasOne(p => p.pmd_int_id)
                      .WithMany(d => d.Orderdetails)
                      .HasForeignKey(p => p.ordetail_int_pmdid)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.ordetail_int_total)
                     .HasColumnType("money");

                entity.Property(e => e.ordetail_created_at)
                    .HasColumnType("datetime")
                    .HasColumnName("ordetail_created_at")
                    .HasDefaultValueSql("(getutcdate())");


                entity.Property(e => e.ordetail_modified_at)
                    .HasColumnType("datetime")
                    .HasColumnName("ordetail_modified_at")
                    .HasDefaultValueSql("(getutcdate())");
            });


            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.HasKey(p => p.ord_int_id);

                //entity.ToTable("Orderitem");

                entity.HasOne(d => d.ordetail_int_id)
                      .WithMany(d => d.Orderitems)
                      .HasForeignKey(d => d.ord_int_orderdetailid);

                entity.HasOne(p => p.Prod_int_ID)
                      .WithMany(d => d.Orderitems)
                      .HasForeignKey(p => p.ord_product_id);

                entity.Property(e => e.ord_created_at)
                    .HasColumnType("datetime")
                    .HasColumnName("ord_created_at")
                    .HasDefaultValueSql("(getutcdate())");


                entity.Property(e => e.ord_modified_at)
                    .HasColumnType("datetime")
                    .HasColumnName("ord_modified_at")
                    .HasDefaultValueSql("(getutcdate())");
            });


            modelBuilder.Entity<Paymentdetail>(entity =>
            {
                entity.HasKey(p => p.pmd_int_id);

              //  entity.ToTable("Paymentdetails");

                entity.HasOne(p => p.ordetail_int_id)
                      .WithMany(d => d.Paymentdetails)
                      .HasForeignKey(p => p.pmd_int_orderid);

                entity.Property(e => e.pmd_mny_amount)
                      .HasColumnType("money");

                entity.Property(e => e.pmd_created_at)
                      .HasColumnType("datetime")
                      .HasColumnName("pmd_created_at")
                      .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.pmd_modified_at)
                      .HasColumnType("datetime")
                      .HasColumnName("pmd_modified_at")
                      .HasDefaultValueSql("(getutcdate())");
            });



            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Prod_int_ID);

               // entity.ToTable("Products");

                entity.HasOne(p => p.disc_int_id)
                      .WithMany(d => d.Products)
                      .HasForeignKey(p => p.Prod_int_DiscId);



                entity.Property(e => e.Prod_mny_Price)
                      .HasColumnType("money");

                entity.Property(e => e.Prod_Created_at)
                      .HasColumnType("datetime")
                      .HasColumnName("Prod_Created_at")
                      .HasDefaultValueSql("(getutcdate())");


                entity.Property(e => e.Prod_Modified_at)
                    .HasColumnType("datetime")
                    .HasColumnName("Prod_Modified_at")
                    .HasDefaultValueSql("(getutcdate())");
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(p => p.usr_int_id);

               // entity.ToTable("Users");

                entity.Property(e => e.usr_create_at)
                      .HasColumnType("datetime")
                      .HasColumnName("usr_create_at")
                      .HasDefaultValueSql("(getutcdate())");

            });


        }
    }
}

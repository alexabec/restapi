using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace kwiqstage.Models
{
    public partial class kwiq_prodContext : DbContext
    {
        public kwiq_prodContext()
        {
        }

        public kwiq_prodContext(DbContextOptions<kwiq_prodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankDetails> BankDetails { get; set; }
        public virtual DbSet<BusinessAccount> BusinessAccount { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccount { get; set; }
        public virtual DbSet<FollowedShops> FollowedShops { get; set; }
        public virtual DbSet<ItemImages> ItemImages { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<MyCart> MyCart { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<SavedItems> SavedItems { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=productionk.mysql.database.azure.com;port=3306;user=alexa@productionk;password=SarahBechik54!;database=kwiq_production", x => x.ServerVersion("5.7.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankDetails>(entity =>
            {
                entity.ToTable("bank_details");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountNumberIban)
                    .HasColumnName("account_number_iban")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BankName)
                    .HasColumnName("bank_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BicSwift)
                    .HasColumnName("bic_swift")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BusinessId)
                    .HasColumnName("business_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<BusinessAccount>(entity =>
            {
                entity.ToTable("business_account");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BusinessAddress)
                    .HasColumnName("business_address")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.BusinessEmail)
                    .HasColumnName("business_email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShopName)
                    .HasColumnName("shop_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Carts>(entity =>
            {
                entity.ToTable("carts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerUsername)
                    .HasColumnName("customer_username")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShopName)
                    .HasColumnName("shop_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<CustomerAccount>(entity =>
            {
                entity.ToTable("customer_account");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShippingAddress)
                    .HasColumnName("shipping_address")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StripeId)
                    .HasColumnName("stripeId")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<FollowedShops>(entity =>
            {
                entity.ToTable("followed_shops");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfilePic)
                    .HasColumnName("profile_pic")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShopId)
                    .HasColumnName("shop_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ItemImages>(entity =>
            {
                entity.ToTable("item_images");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemImage)
                    .HasColumnName("item_image")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShopId)
                    .HasColumnName("shop_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Featured).HasColumnName("featured");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Hashtags)
                    .HasColumnName("hashtags")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Sale)
                    .HasColumnName("sale")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShopId)
                    .HasColumnName("shop_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShopName)
                    .HasColumnName("shop_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<MyCart>(entity =>
            {
                entity.ToTable("my_cart");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CartId)
                    .HasColumnName("cart_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemImage)
                    .HasColumnName("item_image")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ItemName)
                    .HasColumnName("item_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("item_price")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ItemSize)
                    .HasColumnName("item_size")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("order_details");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemImage)
                    .HasColumnName("item_image")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ItemName)
                    .HasColumnName("item_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("item_price")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ItemSize)
                    .HasColumnName("item_size")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Refund).HasColumnName("refund");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerUsername)
                    .HasColumnName("customer_username")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PaymentConfirmation)
                    .HasColumnName("payment_confirmation")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Refunded)
                    .HasColumnName("refunded")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Shipped).HasColumnName("shipped");

                entity.Property(e => e.ShippingAddress)
                    .HasColumnName("shipping_address")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShippingDate)
                    .HasColumnName("shipping_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShopName)
                    .HasColumnName("shop_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.ToTable("reviews");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerUsername)
                    .HasColumnName("customer_username")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ranking)
                    .HasColumnName("ranking")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Review)
                    .HasColumnName("review")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShopName)
                    .HasColumnName("shop_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<SavedItems>(entity =>
            {
                entity.ToTable("saved_items");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShopId)
                    .HasColumnName("shop_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Shops>(entity =>
            {
                entity.ToTable("shops");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProfileAddress)
                    .HasColumnName("profile_address")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProfileBio)
                    .HasColumnName("profile_bio")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProfileEmail)
                    .HasColumnName("profile_email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProfilePic)
                    .HasColumnName("profile_pic")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ShopName)
                    .HasColumnName("shop_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

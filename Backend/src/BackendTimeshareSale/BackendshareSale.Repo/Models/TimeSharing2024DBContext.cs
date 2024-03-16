using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class TimeSharing2024DBContext : DbContext
    {
        public TimeSharing2024DBContext()
        {
        }

        public TimeSharing2024DBContext(DbContextOptions<TimeSharing2024DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankTransferTransaction> BankTransferTransactions { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<BookmarkTimeShare> BookmarkTimeShares { get; set; }
        public virtual DbSet<CardTransaction> CardTransactions { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Investor> Investors { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-E9T9GDT;Uid=sa;Pwd=12345;Database=TimeSharing2024DB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BankTransferTransaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountHolderName).HasMaxLength(100);

                entity.Property(e => e.AccountNumber).HasMaxLength(30);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Bic)
                    .HasMaxLength(20)
                    .HasColumnName("BIC");

                entity.Property(e => e.Iban)
                    .HasMaxLength(50)
                    .HasColumnName("IBAN");

                entity.Property(e => e.OtherTransferDetails).HasMaxLength(200);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.TransferAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TransferDateTime).HasColumnType("datetime");

                entity.Property(e => e.TransferReference).HasMaxLength(100);

                entity.Property(e => e.TransferStatus).HasMaxLength(50);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.BankTransferTransactions)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__BankTrans__Payme__4D94879B");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Bookings__Custom__3E52440B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bookings__UserID__3F466844");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.Property(e => e.BookingDetailId).HasColumnName("BookingDetailID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingStatus).HasMaxLength(50);

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.Deposits).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__BookingDe__Booki__4316F928");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__BookingDe__Prope__4222D4EF");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__BookingDe__Staff__440B1D61");
            });

            modelBuilder.Entity<BookmarkTimeShare>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.BookmarkTimeShares)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__BookmarkT__Prope__3B75D760");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookmarkTimeShares)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BookmarkT__UserI__3A81B327");
            });

            modelBuilder.Entity<CardTransaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardHolderName).HasMaxLength(100);

                entity.Property(e => e.CardNumber).HasMaxLength(30);

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.OtherTransferDetails).HasMaxLength(100);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.TransferAmount).HasMaxLength(100);

                entity.Property(e => e.TransferDateTime).HasMaxLength(100);

                entity.Property(e => e.TransferStatus).HasMaxLength(100);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.CardTransactions)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__CardTrans__Payme__5070F446");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.ContractDate).HasColumnType("datetime");

                entity.Property(e => e.ContractExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.ContractStatus).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Signature).HasMaxLength(200);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Contracts__Booki__46E78A0C");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PK__Customer__2F187130EB78B2CC");

                entity.HasIndex(e => e.CusEmail, "UQ__Customer__60A7203FEE97A95E")
                    .IsUnique();

                entity.HasIndex(e => e.CitizenId, "UQ__Customer__6E49FBEDF7E40614")
                    .IsUnique();

                entity.Property(e => e.CusId).HasColumnName("CusID");

                entity.Property(e => e.CitizenId)
                    .HasMaxLength(50)
                    .HasColumnName("CitizenID");

                entity.Property(e => e.Country).HasMaxLength(60);

                entity.Property(e => e.CusEmail).HasMaxLength(60);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Customers__RoleI__300424B4");
            });

            modelBuilder.Entity<Investor>(entity =>
            {
                entity.HasIndex(e => e.CitizenId, "UQ__Investor__6E49FBED9C2C34F7")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Investor__A9D105347B5530BF")
                    .IsUnique();

                entity.Property(e => e.InvestorId).HasColumnName("InvestorID");

                entity.Property(e => e.CitizenId)
                    .HasMaxLength(50)
                    .HasColumnName("CitizenID");

                entity.Property(e => e.Country).HasMaxLength(60);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Investors)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Investors__RoleI__34C8D9D1");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.OrtherPaymentDetails).HasMaxLength(200);

                entity.Property(e => e.PaymentStatus).HasMaxLength(100);

                entity.Property(e => e.PaymentType).HasMaxLength(20);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Payments__Bookin__4AB81AF0");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK__Payments__Contra__49C3F6B7");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.Images).HasColumnType("image");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PropertyType).HasMaxLength(50);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__Propertie__Owner__37A5467C");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Department).HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(60);

                entity.Property(e => e.JobTitle).HasMaxLength(40);

                entity.Property(e => e.LastName).HasMaxLength(60);

                entity.Property(e => e.Salary).HasMaxLength(60);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Staffs__UserID__2B3F6F97");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress, "UQ__Users__49A14740AF311B38")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456A0046476")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CitizenId).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(60);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.FullName).HasMaxLength(60);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.HashPassword)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleID__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

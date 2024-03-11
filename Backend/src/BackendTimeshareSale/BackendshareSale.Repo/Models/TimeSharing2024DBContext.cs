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
        public virtual DbSet<BookmarkTimeShare> BookmarkTimeShares { get; set; }
        public virtual DbSet<CardTransaction> CardTransactions { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

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
                    .HasConstraintName("FK__BankTrans__Payme__4BAC3F29");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingDateTime).HasColumnType("datetime");

                entity.Property(e => e.BookingStatus).HasMaxLength(50);

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Deposits).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Bookings__Custom__3C69FB99");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__Bookings__Proper__3F466844");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Bookings__StaffI__3E52440B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bookings__UserID__3D5E1FD2");
            });

            modelBuilder.Entity<BookmarkTimeShare>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.BookmarkTimeShares)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK__BookmarkT__Prope__398D8EEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookmarkTimeShares)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BookmarkT__UserI__38996AB5");
            });

            modelBuilder.Entity<CardTransaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CardHolderName).HasMaxLength(100);

                entity.Property(e => e.CardNumber).HasMaxLength(30);

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Cvv)
                    .HasMaxLength(50)
                    .HasColumnName("CVV");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.OtherTransferDetails).HasMaxLength(100);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.TransferAmount).HasMaxLength(100);

                entity.Property(e => e.TransferDateTime).HasMaxLength(100);

                entity.Property(e => e.TransferStatus).HasMaxLength(100);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.CardTransactions)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__CardTrans__Payme__4E88ABD4");
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
                    .HasConstraintName("FK__Contracts__Booki__4222D4EF");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PK__Customer__2F187130B1BEDAB4");

                entity.HasIndex(e => e.CusEmail, "UQ__Customer__60A7203F5B4568AF")
                    .IsUnique();

                entity.HasIndex(e => e.CitizenId, "UQ__Customer__6E49FBED4BA2F377")
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
                    .HasConstraintName("FK__Customers__RoleI__32E0915F");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.OrtherPaymentDetails).HasMaxLength(200);

                entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");

                entity.Property(e => e.PaymentType).HasMaxLength(20);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Payments__Bookin__48CFD27E");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK__Payments__Contra__46E78A0C");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .HasConstraintName("FK__Payments__Paymen__47DBAE45");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("PaymentStatus");

                entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");

                entity.Property(e => e.PaymentStatusName)
                    .IsRequired()
                    .HasMaxLength(100);
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
                    .HasConstraintName("FK__Propertie__Owner__35BCFE0A");
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
                    .HasConstraintName("FK__Staffs__UserID__2A4B4B5E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress, "UQ__Users__49A1474031D1124A")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456EB4433DF")
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

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRoles__RoleI__2D27B809");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRoles__UserI__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

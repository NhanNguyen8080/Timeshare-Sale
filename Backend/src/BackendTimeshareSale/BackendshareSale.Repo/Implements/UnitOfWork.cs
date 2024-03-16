using BackendshareSale.Repo.Interfaces;
using BackendshareSale.Repo.Models;

namespace BackendshareSale.Repo.Implements
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TimeSharing2024DBContext _dbContext;
        public UnitOfWork(TimeSharing2024DBContext dBContext)
        {
            this._dbContext = dBContext;
        }
        private IGenericRepository<BankTransferTransaction> BankTransferTransactionRepository;

        private IGenericRepository<Booking> BookingRepository;

        private IGenericRepository<BookmarkTimeShare> BookmarkTimeShareRepository;

        private IGenericRepository<CardTransaction> CardTransactionRepository;

        private IGenericRepository<Contract> ContractRepository;

        private IGenericRepository<Customer> CustomerRepository;

        private IGenericRepository<Payment> PaymentRepository;

        private IGenericRepository<PaymentStatus> PaymentStatusRepository;

        private IGenericRepository<Property> PropertyRepository;

        private IGenericRepository<Role> RoleRepository;

        private IGenericRepository<Staff> StaffRepository;

        private IGenericRepository<User> UserRepository;

        private IGenericRepository<UserRole> UserRoleRepository;

        public IGenericRepository<BankTransferTransaction> BankTransferTransactionRepo
        {
            get
            {
                if(this.BankTransferTransactionRepository == null)
                {
                    this.BankTransferTransactionRepository = new GenericRepository<BankTransferTransaction>(_dbContext);
                }
                return this.BankTransferTransactionRepository;
            }
        }

        public IGenericRepository<Booking> BookingRepo
        {
            get
            {
                if (this.BookingRepository == null)
                {
                    this.BookingRepository = new GenericRepository<Booking>(_dbContext);
                }
                return this.BookingRepository;
            }
        }

        public IGenericRepository<BookmarkTimeShare> BookmarkTimeShareRepo
        {
            get
            {
                if (this.BookmarkTimeShareRepository == null)
                {
                    this.BookmarkTimeShareRepository = new GenericRepository<BookmarkTimeShare>(_dbContext);
                }
                return this.BookmarkTimeShareRepository;
            }
        }

        public IGenericRepository<CardTransaction> CardTransactionRepo
        {
            get
            {
                if (this.CardTransactionRepository == null)
                {
                    this.CardTransactionRepository = new GenericRepository<CardTransaction>(_dbContext);
                }
                return this.CardTransactionRepository;
            }
        }

        public IGenericRepository<Contract> ContractRepo
        {
            get
            {
                if (this.ContractRepository == null)
                {
                    this.ContractRepository = new GenericRepository<Contract>(_dbContext);
                }
                return this.ContractRepository;
            }
        }

        public IGenericRepository<Customer> CustomerRepo
        {
            get
            {
                if (this.CustomerRepository == null)
                {
                    this.CustomerRepository = new GenericRepository<Customer>(_dbContext);
                }
                return this.CustomerRepository;
            }
        }

        public IGenericRepository<Payment> PaymentRepo
        {
            get
            {
                if (this.PaymentRepository == null)
                {
                    this.PaymentRepository = new GenericRepository<Payment>(_dbContext);
                }
                return this.PaymentRepository;
            }
        }

        public IGenericRepository<PaymentStatus> PaymentStatusRepo
        {
            get
            {
                if (this.PaymentStatusRepository == null)
                {
                    this.PaymentStatusRepository = new GenericRepository<PaymentStatus>(_dbContext);
                }
                return this.PaymentStatusRepository;
            }
        }

        public IGenericRepository<Property> PropertyRepo
        {
            get
            {
                if (this.PropertyRepository == null)
                {
                    this.PropertyRepository = new GenericRepository<Property>(_dbContext);
                }
                return this.PropertyRepository;
            }
        }

        public IGenericRepository<Role> RoleRepo
        {
            get
            {
                if (this.RoleRepository == null)
                {
                    this.RoleRepository = new GenericRepository<Role>(_dbContext);
                }
                return this.RoleRepository;
            }
        }

        public IGenericRepository<Staff> StaffRepo
        {
            get
            {
                if (this.StaffRepository == null)
                {
                    this.StaffRepository = new GenericRepository<Staff>(_dbContext);
                }
                return this.StaffRepository;
            }
        }

        public IGenericRepository<User> UserRepo
        {
            get
            {
                if (this.UserRepository == null)
                {
                    this.UserRepository = new GenericRepository<User>(_dbContext);
                }
                return this.UserRepository;
            }
        }

        public IGenericRepository<UserRole> UserRoleRepo
        {
            get
            {
                if (this.UserRoleRepository == null)
                {
                    this.UserRoleRepository = new GenericRepository<UserRole>(_dbContext);
                }
                return this.UserRoleRepository;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

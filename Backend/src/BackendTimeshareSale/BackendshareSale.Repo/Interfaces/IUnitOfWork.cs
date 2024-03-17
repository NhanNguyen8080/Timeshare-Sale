using BackendshareSale.Repo.Models;
namespace BackendshareSale.Repo.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        IGenericRepository<BankTransferTransaction> BankTransferTransactionRepo { get; }
        IGenericRepository<Booking> BookingRepo { get; }
        IGenericRepository<BookingDetail> BookingDetailRepo { get; }
        IGenericRepository<BookmarkTimeShare> BookmarkTimeShareRepo { get; }
        IGenericRepository<CardTransaction> CardTransactionRepo { get; }
        IGenericRepository<Contract> ContractRepo { get; }
        IGenericRepository<Customer> CustomerRepo { get; }
        IGenericRepository<Payment> PaymentRepo { get; }
        IGenericRepository<Property> PropertyRepo { get; }
        IGenericRepository<Role> RoleRepo { get; }
        IGenericRepository<Staff> StaffRepo { get; }
        IGenericRepository<User> UserRepo { get; }
        IGenericRepository<Investor> InvestorRepo { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackendshareSale.Repo.Models;
namespace BackendTimeshareSale.Service.IServices
{
    public interface IUserService
    {
        void CreateUser(User user);

        void CreateUser(IEnumerable<User> list);

        void CreateOrUpdate(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        void DeleteUser(IEnumerable<User> list);

        void DeleteUser(int UserId);

        void DeleteUser(Expression<Func<User, bool>> predicated);

        User GetUser(int userId);

        User GetUser(int userId, params Expression<Func<User, object>>[] includes);

        User GetUser(Expression<Func<User, bool>> predicated);

        User GetUser(Expression<Func<User, bool>> predicated, params Expression<Func<User, object>>[] includes);

        IQueryable<User> SearchUser(Expression<Func<User, bool>> predicated);

        IQueryable<User> SearchUser(Expression<Func<User, bool>> predicated, params Expression<Func<User, object>>[] includes);

        IQueryable<User> GetAllUser();

        IQueryable<User> GetAllUser(params Expression<Func<User, object>>[] includes);
        IQueryable<User> GetAllUserByRole(Expression<Func<User, bool>> predicated, params Expression<Func<User, object>>[] includes);
    }
}

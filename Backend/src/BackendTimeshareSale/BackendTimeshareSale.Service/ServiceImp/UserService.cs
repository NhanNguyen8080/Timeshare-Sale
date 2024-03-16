using BackendshareSale.Repo.Interfaces;
using BackendshareSale.Repo.Models;
using BackendTimeshareSale.Service.IServices;
using System.Linq.Expressions;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public void CreateOrUpdate(User user)
        {
            User existedUser = _unitOfWork.UserRepo.Get(_ => _.UserId.Equals(user.UserId)).FirstOrDefault();
            if (existedUser != null)
            {
                existedUser.UserName = user.UserName;
                existedUser.HashPassword = user.HashPassword;
                existedUser.FullName = user.FullName;
                existedUser.EmailAddress = user.EmailAddress;
                existedUser.Country = user.Country;
                existedUser.Address = user.Address;
                existedUser.DateOfBirth = user.DateOfBirth;
                existedUser.Gender = user.Gender;
                existedUser.PhoneNumber = user.PhoneNumber;
                existedUser.IsActive = user.IsActive;
                existedUser.RefreshToken = user.RefreshToken;
                _unitOfWork.UserRepo.Update(existedUser);
            }
            else
            {
                _unitOfWork.UserRepo.Insert(user);
            }
        }

        public void CreateUser(User user)
        {
            _unitOfWork.UserRepo.Insert(user);
        }

        public void CreateUser(IEnumerable<User> list)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            _unitOfWork.UserRepo.Delete(user);
        }

        public void DeleteUser(IEnumerable<User> list)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int UserId)
        {
            User existedUser = _unitOfWork.UserRepo.Get(_ => _.UserId.Equals(UserId)).FirstOrDefault();
            if (existedUser != null)
            {
                _unitOfWork.UserRepo.Delete(existedUser);
            }
        }

        public void DeleteUser(Expression<Func<User, bool>> predicated)
        {
            User existedUser = _unitOfWork.UserRepo.Get(predicated).FirstOrDefault();
            if (existedUser != null)
            {
                _unitOfWork.UserRepo.Delete(existedUser);
            }
        }

        public IQueryable<User> GetAllUser()
        {
            return _unitOfWork.UserRepo.GetAll();
        }

        public IQueryable<User> GetAllUser(params Expression<Func<User, object>>[] includes)
        {
            return _unitOfWork.UserRepo.GetAll(includes);
        }

        public IQueryable<User> GetAllUserByRole(Expression<Func<User, bool>> predicated, params Expression<Func<User, object>>[] includes)
        {
            return _unitOfWork.UserRepo.GetAll(includes).Where(predicated);
        }

        public User GetUser(int userId)
        {
            return _unitOfWork.UserRepo.GetAll().Where(_ => _.UserId.Equals(userId)).FirstOrDefault();
        }

        public User GetUser(int userId, params Expression<Func<User, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public User GetUser(Expression<Func<User, bool>> predicated)
        {
            return _unitOfWork.UserRepo.Get(predicated).FirstOrDefault();
        }

        public User GetUser(Expression<Func<User, bool>> predicated, params Expression<Func<User, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> SearchUser(Expression<Func<User, bool>> predicated)
        {
            return _unitOfWork.UserRepo.GetAll().Where(predicated);
        }

        public IQueryable<User> SearchUser(Expression<Func<User, bool>> predicated, params Expression<Func<User, object>>[] includes)
        {
            return _unitOfWork.UserRepo.GetAll(includes).Where(predicated);
        }

        public void UpdateUser(User user)
        {
            _unitOfWork.UserRepo.Update(user);
        }
    }
}

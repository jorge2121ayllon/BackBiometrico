using backend.Core.CustomEntities;
using backend.Core.Entities;
using backend.Core.Interfaces;
using backend.Core.QueryFilters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;


        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            this._paginationOptions = options.Value;
        }

        public async Task<User> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.UserRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(User user)
        {
            user.Date= DateTime.Now;
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public PagedList<User> GetUsers(PostQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var users = _unitOfWork.UserRepository.GetAll().ToList();

            if (filters.filter != null)
            {
                users = users.Where(x => x.NombreUsuario.ToLower().Contains(filters.filter.ToLower())).ToList();
            }

            var pageusers = PagedList<User>.Create(users, filters.PageNumber, filters.PageSize);

            return pageusers;
        }


        public bool UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
            return true;
        }


        public async Task<User> GetUser(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }


        public string GetPassword(int id)
        {
            return _unitOfWork.UserRepository.GetById(id).Result.Clave;
        }

        public async Task<bool> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            _unitOfWork.SaveChanges();
            return true;
        }

    }
}

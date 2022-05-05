using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRM.DAL.Data;
using Microsoft.Extensions.Configuration;
using VRM.DAL.Models;
using VRM.DAL.Repos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace VRM.BLL.Services
{
    public class AccountService : IAccount
    {
        protected readonly IUserRepository _repository;
        protected readonly IMapper _mapper;

        public AccountService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var res = await _repository.GetAll();
            return _mapper.Map<IEnumerable<User>>(res);
        }

        public User GetById(string id)
        {
            var res = _repository.GetById(id);
            return _mapper.Map<User>(res);
        }

        public void Add(User obj)
        {
            var dataViewModel = _mapper.Map<User>(obj);
            _repository.Add(dataViewModel);
        }

        public void Update(User obj)
        {
            var dataViewModel = _mapper.Map<User>(obj);
            _repository.Update(dataViewModel);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }
        public void Save()
        {
            _repository.Save();
        }
    }
}
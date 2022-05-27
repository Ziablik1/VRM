using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRM.DAL.Models;
using VRM.DAL.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using AutoMapper;

namespace VRM.BLL.Services
{
    public class TestService: ITestService
    {
        protected readonly ITestRepository _repository;
        protected readonly IMapper _mapper;

        public TestService(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Test>> GetAll()
        {
            var res = await _repository.GetAll();
            return _mapper.Map<IEnumerable<Test>>(res);
        }

        public Test GetById(string id)
        {
            var res = _repository.GetById(id);
            return _mapper.Map<Test>(res);
        }

        public void Add(Test obj)
        {
            var dataViewModel = _mapper.Map<Test>(obj);
            _repository.Add(dataViewModel);
        }

        public void Update(Test obj)
        {
            var dataViewModel = _mapper.Map<Test>(obj);
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
        //public IEnumerable<Test> GetTestsByStudentId(int id)
        //{
        //}
    }
}

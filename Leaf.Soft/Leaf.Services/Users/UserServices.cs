using Leaf.Core.Data;
using Leaf.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Leaf.Core;

namespace Leaf.Services.Users
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _repository;

        public UserServices(IRepository<User> repository)
        {
            _repository = repository;
        }

        public bool Delete(User item)
        {
            return _repository.Delete(item) > 0 ? true : false;
        }

        public IEnumerable<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            return _repository.GetAll(predicate);
        }

        public bool Insert(User item)
        {
            return _repository.Insert(item) > 0 ? true : false;            
        }

        public bool Update(User item)
        {           
            return _repository.Update(item) > 0 ? true : false;
        }
        public int ExecSql(RawSqlString sql, params object[] parameters)
        {
            return _repository.ExecSql(sql, parameters);
        }

        public IPagedList<User> SearchPage(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _repository.Table;
            return new PagedList<User>(query, pageIndex, pageSize);
        }
    }
}

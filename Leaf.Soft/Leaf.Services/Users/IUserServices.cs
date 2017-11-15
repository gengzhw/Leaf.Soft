using Leaf.Core;
using Leaf.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Leaf.Services.Users
{
    public interface IUserServices
    {
        IEnumerable<User> GetAll(Expression<Func<User, bool>> predicate);
        bool Delete(User item);
        bool Update(User item);
        bool Insert(User item);

        int ExecSql(RawSqlString sql, params object[] parameters);

        IPagedList<User> SearchPage(int pageIndex = 0, int pageSize = int.MaxValue);

    }
}

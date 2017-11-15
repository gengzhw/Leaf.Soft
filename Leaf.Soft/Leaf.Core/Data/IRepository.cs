using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Leaf.Core.Data
{
    /// <summary>
    /// 
    /// gengzhw
    /// 
    /// 2017/6/26 上午11:30:13
    /// 
    /// 仓库接口
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial interface IRepository<T> where T : class
    {
        int Insert(T entity, bool isSave = true);

        int Update(T entity, bool isSave = true);

        int Delete(T entity, bool isSave = true);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        int ExecSql(RawSqlString sql, params object[] parameters);
    }
}

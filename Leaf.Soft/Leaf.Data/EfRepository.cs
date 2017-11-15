using Leaf.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Leaf.Data
{
  
  /// <summary>
  /// 
  /// gengzhw
  /// 
  /// 2017/6/26 上午11:30:13
  /// 
  /// 实体仓库
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IRepository<T> where T : class
    {
        //private readonly DbContext _context;
        private readonly DbContext _context;
        private DbSet<T> _entities;

        #region 构造函数
        public EfRepository(DbContext context)
        {
            //  this._context = new LsyiObjectContext();
            this._context = context;
        }
        //public EfRepository()
        //{
        //    //  this._context = new LsyiObjectContext();
        //    this._context = new LeafObjectContext();
        //}
        //public Repository(LsyiObjectContext context)
        //{
        //    _context = context;
        //}
        #endregion

        #region 属性
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }
        #endregion

        #region 增删查改
        public int Insert(T entity, bool isSave = true)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            
            this._context.Add(entity);
            if (isSave)
            {
                return this._context.SaveChanges();
            }
            return 0;
        }

        public int Update(T entity, bool isSave = true)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            this._context.Update<T>(entity);
            if (isSave)
            {
                return this._context.SaveChanges();
            }
            return 0;
        }

        public int Delete(T entity, bool isSave = true)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            this._context.Remove<T>(entity);
            if (isSave)
            {
                return this._context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            
            return this.Table.Where(predicate);
        }

        public int ExecSql( RawSqlString sql,params object[] parameters)
        {
           return this._context.Database.ExecuteSqlCommand(sql, parameters);
        }

        #endregion


        //public virtual IQueryable<T> Table
        //{
        //    get
        //    {
        //        return this.Entities;
        //    }
        //}

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }
    }
}

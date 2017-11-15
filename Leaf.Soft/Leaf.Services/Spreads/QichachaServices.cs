using System;
using System.Collections.Generic;
using System.Text;
using Leaf.Core.Domain.Spreads;
using Microsoft.EntityFrameworkCore;
using Leaf.Data;
using Leaf.Core.Data;
using System.Linq.Expressions;

namespace Leaf.Services.Spreads
{
    public partial class QichachaServices : IQichachaServices
    {
        private readonly IRepository<Qichacha> _repository;
        public QichachaServices(IRepository<Qichacha> repository)
        {
            this._repository = repository;
        }

        public bool Delete(Qichacha item)
        {
            return _repository.Delete(item) > 0 ? true : false;
        }

        public IEnumerable<Qichacha> GetAll(Expression<Func<Qichacha, bool>> predicate)
        {
            return _repository.GetAll(predicate);
        }

        public bool Insert(Qichacha item)
        {
            return _repository.Insert(item) > 0 ? true : false;
        }

        public bool Insert(Qichacha item,bool save=false)
        {
            return _repository.Insert(item,save) >= 0 ? true : false;
        }

        public bool Update(Qichacha item)
        {
            return _repository.Update(item) > 0 ? true : false;
        }
        public int ExecSql(RawSqlString sql, params object[] parameters)
        {
            return _repository.ExecSql(sql, parameters);
        }
    }
}

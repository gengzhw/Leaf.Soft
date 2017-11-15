using Leaf.Core.Domain.Spreads;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Leaf.Services.Spreads
{
    public interface IQichachaServices
    {
        IEnumerable<Qichacha> GetAll(Expression<Func<Qichacha, bool>> predicate);
        bool Delete(Qichacha item);
        bool Update(Qichacha item);
        bool Insert(Qichacha item);
        bool Insert(Qichacha item,bool save=false);
        int ExecSql(RawSqlString sql, params object[] parameters);

    }
}

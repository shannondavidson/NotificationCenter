using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Boilerplate.Core.Cqrs
{
    public abstract class BaseQuery<TResult>
    {
        public SqlConnection Connection { get; set; }
        public SqlConnection AdditionalConnection { get; set; }
        public IQueryProcessor QueryProcessor { get; set; }
        public abstract TResult Execute();
    }
}
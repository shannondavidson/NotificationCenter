using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Boilerplate.Core.Cqrs
{
    public abstract class BaseCommand<TResult>
    {
        public int SiteId { get; set; }

        public SqlConnection Connection { get; set; }
        public ICommandProcessor CommandProcessor { get; set; }
        public abstract TResult Execute();

        List<Exception> _Errors;
        public List<Exception> Errors
        {
            get
            {
                if (null == _Errors)
                    _Errors = new List<Exception>();

                return _Errors;
            }
            set { _Errors = value; }
        }
    }
}

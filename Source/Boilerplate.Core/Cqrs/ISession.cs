using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Boilerplate.Core.Cqrs
{
    public interface ISession
    {
        SqlConnection Create();
    }
}


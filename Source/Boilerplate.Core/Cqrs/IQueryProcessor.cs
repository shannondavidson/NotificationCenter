using System.Data.SqlClient;

namespace Boilerplate.Core.Cqrs
{
    public interface IQueryProcessor
    {
        TResult Execute<TResult>(BaseQuery<TResult> query);
        TResult Execute<TResult>(BaseQuery<TResult> query, ISession additionalSession);
        TResult Execute<TResult>(BaseQuery<TResult> query, SqlConnection connection);
        TResult Execute<TResult>(BaseQuery<TResult> query, SqlConnection connection, SqlConnection additionalConnection);
    }
}
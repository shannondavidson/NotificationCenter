using System.Data.SqlClient;

namespace Boilerplate.Core.Cqrs
{
    public interface ICommandProcessor
    {
        TResult Execute<TResult>(BaseCommand<TResult> command);
        TResult Execute<TResult>(BaseCommand<TResult> command, SqlConnection connection);
    }
}

using System.Data.SqlClient;

namespace Boilerplate.Core.Cqrs
{

    public class CommandProcessor : ICommandProcessor
    {
        private readonly ISession _session;

        public CommandProcessor(ISession session)
        {
            _session = session;
        }

        public TResult Execute<TResult>(BaseCommand<TResult> command)
        {
            TResult result;

            using (var connection = _session.Create())
            {
                result = Execute<TResult>(command, connection);
            }

            return result;
        }

        public TResult Execute<TResult>(BaseCommand<TResult> command, SqlConnection connection)
        {
            TResult result;

            command.Connection = connection;
            command.CommandProcessor = this;
            result = command.Execute();

            return result;
        }
    }
}


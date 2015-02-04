using Dapper;
using Boilerplate.Core.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCenter.Core.Commands
{
    public class MessageDeleteCommand : BaseCommand<int>
    {
        public int MessageId { get; set; }

        public override int Execute()
        {
            Connection.ExecuteScalar("Delete Message Where Id = @Id", new { Id = MessageId });
            return 1;
        }
    }
}

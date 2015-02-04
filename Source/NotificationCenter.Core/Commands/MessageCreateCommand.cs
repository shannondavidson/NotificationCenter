using Dapper;
using Boilerplate.Core.Cqrs;
using NotificationCenter.Core.Domain;
using System.Linq;

namespace NotificationCenter.Core.Commands
{
    public class MessageCreateCommand : BaseCommand<Message>
    {
        public Message Message { get; set; }
        public override Message Execute()
        {
            var messageId = Connection.Query<int>(_SaveMessageSql,
                new {
                    Id = Message.Id,
                    To = Message.To,
                    From = Message.From,
                    Subject = Message.Subject,
                    Body = Message.Body
                }).Single();

            var message = Connection.Query<Message>("Select * From Message Where Id=@Id", new { Id = messageId }).SingleOrDefault();
            return message;
        }

        #region _SaveMessageSql
        private string _SaveMessageSql = @"
If Exists (Select 1 FROM dbo.Message Where Id = @Id)
BEGIN
    Update [dbo].Message
    Set
        [From] = @From
        , [To] = @To
        , Subject = @Subject
        , Body = @Body
    Where Message.Id = @Id
    Select @Id
END
ELSE
BEGIN
INSERT INTO [dbo].[Message]
           ([From]
           ,[To]
           ,[Subject]
           ,[Body])
     VALUES
           (@From
           ,@To
           ,@Subject
           ,@Body)

    Select @@Identity
End
";
        #endregion

    }


}

using Boilerplate.Core.Cqrs;
using System.Configuration;
using System.Data.SqlClient;

namespace NotificationCenter.Core.Sessions
{
    public class MessagingSqlSession : ISession
    {
        public string _MessagingConnectionString;
        public string MessagingConnectionString
        {
            get
            {
                if (_MessagingConnectionString == null)
                {
                    _MessagingConnectionString = ConfigurationManager.ConnectionStrings["MessagingConnection"].ConnectionString;
                }
                return _MessagingConnectionString;
            }
            set { _MessagingConnectionString = value; }
        }

        public SqlConnection Create()
        {
            return new SqlConnection(MessagingConnectionString);
        }
    }
}

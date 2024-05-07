using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_cars_application.modules.messages.data.repositories
{
    internal abstract class MessageRepo
    {
        public abstract string GetSupportMessages();
        public abstract string GetCustomerMessages();
        public abstract string AddMessage(bool isReplayMessage, int customerId, string messageBody);

        public abstract string UpdateReplayMessage(int messageId);

    }
}

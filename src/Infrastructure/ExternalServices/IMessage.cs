using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    public interface IMessage : IEmailSender, ISmsSender
    {
     
    }
}
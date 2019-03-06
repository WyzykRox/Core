using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MojCore.Areas.Identity.Services
{
    public interface IMessage : IEmailSender, ISmsSender
    {
     
    }
}
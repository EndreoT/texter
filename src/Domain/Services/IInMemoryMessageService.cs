using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;

namespace Texter.Domain.Services
{
    public interface IInMemoryMessageService
    {
        public void AddMessage(string address, Message message);
    }
}

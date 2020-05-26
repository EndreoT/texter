using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;
using Texter.Domain.Services;

namespace Texter.Services.InMemoryService
{
    //Singleton
    public class InMemoryMessageService: IInMemoryMessageService
    {
        private readonly ConcurrentDictionary<string, ConcurrentQueue<Message>> _messages;

        public InMemoryMessageService()
        {
            _messages = new ConcurrentDictionary<string, ConcurrentQueue<Message>>();
        }

        public void AddMessage(string address, Message message)
        {
            ConcurrentQueue<Message> queue;
            if (_messages.ContainsKey(address))
            {
                queue = _messages[address];
            }
            else
            {
                queue = new ConcurrentQueue<Message>();
                _messages.TryAdd(address, queue);
            }
            queue.Enqueue(message);
        }

        public ConcurrentQueue<Message> GetMessagesForAddress(string address)
        {
            //if (!_messages.ContainsKey(address))
            //{
            //    return null;
            //}
            _ = _messages.TryRemove(address, out ConcurrentQueue<Message> messagesForAddr);

            return messagesForAddr;
        }
    }

    
}

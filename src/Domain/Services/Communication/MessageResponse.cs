using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.DataTransferObject;

namespace Texter.Domain.Services.Communication
{
    public class MessageResponse : BaseResponse
    {
        public FromMessageDTO MessageDTO { get; private set; }

        private MessageResponse(bool success, string message, FromMessageDTO messageDTO) : base(success, message)
        {
            MessageDTO = messageDTO;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="message">Saved message.</param>
        /// <returns>Response.</returns>
        public MessageResponse(FromMessageDTO messageDTO) : this(true, string.Empty, messageDTO)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public MessageResponse(string messageString) : this(false, messageString, null)
        { }
    }
}

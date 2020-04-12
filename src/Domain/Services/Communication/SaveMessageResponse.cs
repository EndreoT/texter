using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.DataTransferObject;

namespace Texter.Domain.Services.Communication
{
    public class SaveMessageResponse : BaseResponse
    {
        public FromMessageDTO MessageDTO { get; private set; }

        private SaveMessageResponse(bool success, string message, FromMessageDTO messageDTO) : base(success, message)
        {
            MessageDTO = messageDTO;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="message">Saved message.</param>
        /// <returns>Response.</returns>
        public SaveMessageResponse(FromMessageDTO messageDTO) : this(true, string.Empty, messageDTO)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveMessageResponse(string messageString) : this(false, messageString, null)
        { }
    }
}

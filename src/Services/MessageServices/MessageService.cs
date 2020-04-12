using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Texter.Domain.Services;
using Texter.Domain.Models;
using Texter.DataTransferObject;
using Texter.Domain.RepositoryInterface.MessageRepository;
using Texter.Domain.RepositoryInterface;
using Texter.Domain.Services.Communication;

namespace Texter.Services.MessageServices
{
    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FromMessageDTO>> ListAsync()
        {
            IEnumerable<Message> messages = await _messageRepository.ListAsync();
            IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return resources;
        }

        public async Task<FromMessageDTO> GetById(long id)
        {
            Message message = await _messageRepository.GetByIdAsync(id);
            FromMessageDTO resource = _mapper.Map<Message, FromMessageDTO>(message);
            return resource;
        }

        public async Task<SaveMessageResponse> CreateMessageAsync(SaveMessageDTO messageDTO)
        {
            Message message = _mapper.Map<SaveMessageDTO, Message>(messageDTO);
            
            try
            {
                await _messageRepository.CreateMessageAsync(message);
                await _unitOfWork.CompleteAsync();

                FromMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(message);

                return new SaveMessageResponse(messageResource);
            } catch (Exception ex)
		    {
                // Do some logging stuff
                return new SaveMessageResponse($"An error occurred when saving the message: {ex.Message}");
            }
}
    }
}

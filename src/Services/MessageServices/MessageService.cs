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

        public async Task<MessageResponse> CreateMessageAsync(SaveMessageDTO messageDTO)
        {
            Message message = _mapper.Map<SaveMessageDTO, Message>(messageDTO);
            
            try
            {
                await _messageRepository.CreateMessageAsync(message);
                await _unitOfWork.CompleteAsync();

                FromMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(message);

                return new MessageResponse(messageResource);
            } catch (Exception ex)
		    {
                // Do some logging stuff
                return new MessageResponse($"An error occurred when saving the message: {ex.Message}");
            }
        }
        public async Task<MessageResponse> UpdateMessageAsync(long id, SaveMessageDTO messageDTO)
        {
            Message foundMessage = await _messageRepository.GetByIdAsync(id);
            if (foundMessage == null)
            {
                return new MessageResponse($"Message with id: {id} does not exist");
            }
            try
            {
                //Update all the fields
                foundMessage.Content = messageDTO.Content;
                foundMessage.SourceAddr = messageDTO.SourceAddr;
                foundMessage.DestinationAddr = messageDTO.DestinationAddr;

                _messageRepository.UpdateMessageAsync(foundMessage);
                await _unitOfWork.CompleteAsync();

                FromMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(foundMessage);

                return new MessageResponse(messageResource);
            }
            catch (Exception ex)
            {
                return new MessageResponse($"An error occurred when saving the message: {ex.Message}");
            }
        }

        public async Task<MessageResponse> DeleteMessageAsync(long id)
        {
            Message foundMessage = await _messageRepository.GetByIdAsync(id);
            if (foundMessage == null)
            {
                return new MessageResponse($"Message with id: {id} does not exist");
            }
            try
            {
                _messageRepository.DeleteMessageAsync(foundMessage);
                await _unitOfWork.CompleteAsync();

                FromMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(foundMessage);

                return new MessageResponse(messageResource);
            }
            catch (Exception ex)
            {
                return new MessageResponse($"An error occurred when deleting the message: {ex.Message}");
            }
        }
    }
}

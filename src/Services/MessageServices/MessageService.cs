using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Texter.Domain.Services;
using Texter.Domain.Models;
using Texter.DataTransferObject;
using Texter.Domain.RepositoryInterface.MessageRepository;
using Texter.Domain.RepositoryInterface;
using Texter.Domain.Services.Communication;
using Texter.Domain.RepositoryInterface.DeviceRepository;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Texter.Services.MessageServices
{
    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IInMemoryMessageService _inMemoryMessageService;

        public MessageService(
            IMessageRepository messageRepository, 
            IDeviceRepository deviceRepository,
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IInMemoryMessageService inMemoryMessageService)
        {
            _messageRepository = messageRepository;
            _deviceRepository = deviceRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _inMemoryMessageService = inMemoryMessageService;
        }

        public async Task<IEnumerable<FromMessageDTO>> ListPopultateDeviceAsync()
        {
            IEnumerable<Message> messages = await _messageRepository.ListPopulateDeviceAsync();
            IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return resources;
        }

        public async Task<FromMessageDTO> GetById(long id)
        {
            Message message = await _messageRepository.GetByIdAsync(id);
            FromMessageDTO resource = _mapper.Map<Message, FromMessageDTO>(message);
            return resource;
        }

        private string DeviceNotFoundMessage(string deviceAddr)
        {
            return $"Device with address {deviceAddr} does not exist";
        }

        public async Task<MessageResponse> CreateMessageAsync(SaveMessageDTO messageDTO)
        {   
            try
            {
                string sourceAddr = messageDTO.SourceAddr;
                string destAddr = messageDTO.DestinationAddr;
                Device sourceDevice = await _deviceRepository.GetByAddrAsync(sourceAddr);
                Device destDevice = await _deviceRepository.GetByAddrAsync(destAddr);
                if (sourceDevice == null || destDevice == null)
                {
                    string messageStr;
                    if (sourceDevice == null)
                    {
                        messageStr = DeviceNotFoundMessage(sourceAddr);
                    }
                    else
                    {
                        messageStr = DeviceNotFoundMessage(destAddr);
                    }
                    return new MessageResponse(messageStr);
                }
                Message message = new Message()
                {
                    Content = messageDTO.Content,
                    SourceAddr = sourceDevice,
                    SourceAddrDeviceId = sourceDevice.DeviceId,
                    DestinationAddr = destDevice,
                    DestinationAddrDeviceId = destDevice.DeviceId
                };

                await _messageRepository.CreateMessageAsync(message);
                await _unitOfWork.CompleteAsync();

                _inMemoryMessageService.AddMessage(destAddr, message);

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
            string sourceAddr = messageDTO.SourceAddr;
            string destAddr = messageDTO.DestinationAddr;
            Device sourceDevice = await _deviceRepository.GetByAddrAsync(sourceAddr);
            Device destDevice = await _deviceRepository.GetByAddrAsync(destAddr);
            if (sourceDevice == null || destDevice == null)
            {
                string messageStr;
                if (sourceDevice == null)
                {
                    messageStr = DeviceNotFoundMessage(sourceAddr);
                }
                else
                {
                    messageStr = DeviceNotFoundMessage(destAddr);
                }
                return new MessageResponse(messageStr);
            }
            try
            {
                //Update all the fields
                foundMessage.Content = messageDTO.Content;
                foundMessage.SourceAddr = sourceDevice;
                foundMessage.SourceAddrDeviceId = sourceDevice.DeviceId;
                foundMessage.DestinationAddr = destDevice;
                foundMessage.DestinationAddrDeviceId = destDevice.DeviceId;

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

        public async Task<IEnumerable<FromMessageDTO>> GetMessagesForDestDeviceAync(string deviceAddr)
        {
            Device device = await _deviceRepository.GetByAddrAsync(deviceAddr);
            if (device == null)
            {
                return null;
            }
            IEnumerable<Message> messages = await _messageRepository.GetMessagesForDestDeviceAync(device);
            IEnumerable<FromMessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<FromMessageDTO>>(messages);
            return resources;
        }

        public IEnumerable<FromMessageDTO> GetMessagesForDestDeviceFromMessageMem(string deviceAddr)
        {
            ConcurrentQueue<Message> messages = _inMemoryMessageService.GetMessagesForAddress(deviceAddr);
            if (messages == null)
            {
                return null;
            }
            List<FromMessageDTO> messageDTOEnumerator = new List<FromMessageDTO>();
            foreach (Message message in messages)
            {
                FromMessageDTO messageResource = _mapper.Map<Message, FromMessageDTO>(message);
                messageDTOEnumerator.Add(messageResource);
            }

        return messageDTOEnumerator;
        }
    }
}

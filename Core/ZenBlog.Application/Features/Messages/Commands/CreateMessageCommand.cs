using MediatR;
using System.Text.Json.Serialization;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands
{
    public class CreateMessageCommand : IRequest<BaseResult<object>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        [JsonIgnore]
        public bool IsRead { get; set; }
    }
}

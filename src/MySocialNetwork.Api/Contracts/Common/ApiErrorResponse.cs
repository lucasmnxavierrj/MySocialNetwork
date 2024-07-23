using MediatR.NotificationPublishers;

namespace MySocialNetwork.Api.Contracts.Common
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse()
        {
            Timestamp = DateTime.UtcNow;
        }
        public int StatusCode { get; set; }
        public string StatusPhrase { get; set; }
        public List<string> Errors { get; } = new();
        public DateTime Timestamp { get; set; }
    }
}

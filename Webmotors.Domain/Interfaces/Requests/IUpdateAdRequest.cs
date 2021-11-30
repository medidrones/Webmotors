namespace Webmotors.Domain.Interfaces.Requests

{
    public interface IUpdateAdRequest : IAdRequest
    {
        public int ID { get; set; }
    }
}

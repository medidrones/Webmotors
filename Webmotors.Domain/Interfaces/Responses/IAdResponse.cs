namespace Webmotors.Domain.Interfaces.Responses
{
    public interface IAdResponse
    {
        int ID { get; }
        string Make { get; }
        string Model { get; }
        string Version { get; }
        int Year { get; }
        int Mileage { get; }
        string Note { get; }
    }
}

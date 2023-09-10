using Core;

namespace Infrastructure.Repository
{
    public interface ITrafficLightRepository
    {
        TrafficLight GetTrafficLightById(Direction direction);
        List<TrafficLight> GetTrafficLights();
        List<TrafficLight> UpdateTrafficLights();
        List<TrafficLight> UpdateTrafficLightsDuration();
        void SetPeakHours(bool isPeakHours);
    }
}
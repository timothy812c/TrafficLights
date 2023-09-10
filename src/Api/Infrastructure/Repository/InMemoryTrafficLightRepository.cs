using Core;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class InMemoryTrafficLightRepository : ITrafficLightRepository
    {
        private readonly List<TrafficLight> _trafficLights;
        private readonly List<TrafficLightStateChanger> _trafficStateChangers;
        

        public InMemoryTrafficLightRepository()
        {

            var North = new TrafficLight(Direction.North);
            var South = new TrafficLight(Direction.South);
            var West = new TrafficLight(Direction.West);
            var East = new TrafficLight(Direction.East);

            var normalDuration = new LightDuration { Green = 20, Yellow = 5, RedDelay = 4 };
            var NorthSouthPeakHoursDuration = new LightDuration { Green = 40, Yellow = 5, RedDelay = 4 };
            var EastWestPeakHoursDuration = new LightDuration { Green = 10, Yellow = 5, RedDelay = 4 };

            var NorthSouthDurationSelector = new DurationSelector(normalDuration, NorthSouthPeakHoursDuration);
            var EastWestDurationSelector = new DurationSelector(normalDuration, EastWestPeakHoursDuration);

            var NorthStateChanger = new TrafficLightStateChanger(North, NorthSouthDurationSelector, East);
            var SouthStateChanger = new TrafficLightStateChanger(South, NorthSouthDurationSelector, West);
            var EastStateChanger = new TrafficLightStateChanger(East, EastWestDurationSelector, North);
            var WestStateChanger = new TrafficLightStateChanger(West, EastWestDurationSelector, South);

            _trafficLights = new List<TrafficLight> { North, South, West, East, };
            _trafficStateChangers = new List<TrafficLightStateChanger> { NorthStateChanger, SouthStateChanger, EastStateChanger, WestStateChanger };

            NorthStateChanger.ActivateTrafficLight();
            SouthStateChanger.ActivateTrafficLight();
        }

        public List<TrafficLight> GetTrafficLights()
        {
            return _trafficLights.ToList();
        }

        public TrafficLight GetTrafficLightById(Direction direction)
        {
            return _trafficLights.FirstOrDefault(t => t.Direction == direction);
        }

        public List<TrafficLight> UpdateTrafficLights()
        {
            foreach (var trafficLightStateChanger in _trafficStateChangers)
            {
                trafficLightStateChanger.UpdateState();
            }
            return _trafficLights.ToList();
        }

        public List<TrafficLight> UpdateTrafficLightsDuration()
        {
            foreach (var trafficLightStateChanger in _trafficStateChangers)
            {
                trafficLightStateChanger.UpdateState();
            }
            return _trafficLights.ToList();
        }

        public void SetPeakHours(bool isPeakHours)
        {
            foreach (var trafficLightStateChanger in _trafficStateChangers)
            {
                trafficLightStateChanger.SetToPeakHours(isPeakHours);
            }
        }
    }

}

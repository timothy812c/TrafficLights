using System.Text.Json.Serialization;

namespace Core
{
    public class TrafficLight
    {
        public Direction Direction { get; private set; }
        public bool IsActive { get; set; }
        public LightState State { get; set; }
        public DateTime LastStateChangeTime { get; set; }

        public int ElapsedTime {
            get {
                return (int)(DateTime.Now - LastStateChangeTime).TotalSeconds;
            }
        }

        public TrafficLight(Direction direction)
        {
            Direction = direction;
            LastStateChangeTime = DateTime.Now;
        }
    }
}
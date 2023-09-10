using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TrafficLightStateChanger
    {
        private readonly TrafficLight trafficLight;
        private readonly TrafficLight? nextTrafficLight;
        private readonly DurationSelector durationSelector;
        
        public LightDuration Duration
        {
            get
            {
                return durationSelector.Duration;
            }
            private set { }
        }

        public TrafficLightStateChanger(TrafficLight trafficLight, DurationSelector durationSelector, TrafficLight? nextTrafficLight)
        {
            this.trafficLight = trafficLight;
            this.nextTrafficLight = nextTrafficLight;
            this.durationSelector = durationSelector;
        }

        public void ActivateTrafficLight()
        {
            trafficLight.IsActive = true;
            SetTrafficLightState(LightState.Green);
        }

        public void UpdateState()
        {
            if (!trafficLight.IsActive)
                return;

            switch (trafficLight.State)
            {

                case LightState.Green:
                    if (trafficLight.ElapsedTime >= Duration.Green)
                    {
                        SetTrafficLightState(LightState.Yellow);
                        //todo: change to emit event
                    }
                    break;
                case LightState.Yellow:
                    if (trafficLight.ElapsedTime >= Duration.Yellow)
                    {
                        SetTrafficLightState(LightState.Red);
                        //todo: change to emit event
                    }
                    break;
                case LightState.Red:
                    if (trafficLight.ElapsedTime >= Duration.RedDelay)
                    {
                        SetTrafficLightState(LightState.Red);
                        trafficLight.IsActive = false;
                        SetActiveNextTrafficLight();
                        //todo: change to emit event instead of defining next active light here
                    }
                    break;
            }
        }

        private void SetActiveNextTrafficLight()
        {
            if (nextTrafficLight != null)
            {
                nextTrafficLight.IsActive = true;
                nextTrafficLight.State = LightState.Green;
                nextTrafficLight.LastStateChangeTime = DateTime.Now;
            }
        }

        private void SetTrafficLightState(LightState state) {
            trafficLight.State = state;
            trafficLight.LastStateChangeTime = DateTime.Now;
        }

        public void SetToPeakHours(bool isPeakHours) { 
            this.durationSelector.IsPeakHours = isPeakHours;
        }
    }
}

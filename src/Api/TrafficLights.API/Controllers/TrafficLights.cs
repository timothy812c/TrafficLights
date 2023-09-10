using Core;
using Infrastructure.Repository;
using Infrastructure.Timer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace TrafficLights.API.Controllers
{
    [ApiController]
    [Route("api/trafficlights")]
    public class TrafficLightsController : ControllerBase
    {
        private readonly ITimer _timer;
        private readonly ITrafficLightRepository _trafficLightRepository;

        public TrafficLightsController(ITimer timer, ITrafficLightRepository trafficLightRepository)
        {
            
            _trafficLightRepository = trafficLightRepository;

            _timer = timer;

            if (!_timer.IsRunning)
            {
                _timer.Elapsed += TimerElapsed;
                _timer.Start(TimeSpan.FromSeconds(1));
            }
        }

        [HttpGet]
        public IActionResult GetTrafficLights()
        {
            var trafficLights = _trafficLightRepository.GetTrafficLights();
            return Ok(trafficLights);
        }

        [HttpGet("{direction}")]
        public IActionResult GetTrafficLightById(Direction direction)
        {
            var trafficLight = _trafficLightRepository.GetTrafficLightById(direction);
            if (trafficLight == null)
            {
                return NotFound();
            }
            return Ok(trafficLight);
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            _trafficLightRepository.UpdateTrafficLights();
            _trafficLightRepository.SetPeakHours(false);
            //TODO: the logic for PeakHours(switching from 20 seconds to 40 seconds is alreay existing,
            //but was not able to connect it to UI for testing, and to implement proper Infra setup.
            //but can still be tested by setting this value to true or false
        }

    }
}

using System;
using System.Threading.Tasks;
using System.Timers;
using Iot.Device.DHTxx;
using TemperatureMonitor.Persistence.Domain.Collections;
using TemperatureMonitor.Persistence.UnitsOfWorks;

namespace TemperatureMonitor
{

    public class TemperatureMonitor
    {
        private readonly IUnitOfWork _unitOfWork;
        private Timer _timer;

        /// <summary>
        /// Creates a new <see cref="TemperatureMonitor"/>.
        /// </summary>
        /// <param name="unitOfWork">The <see cref="IUnitOfWork"/> that will be used to query to the database.</param>
        public TemperatureMonitor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Start the <see cref="Timer"/>.
        /// </summary>
        public void Start()
        {
            _timer = new Timer
                     {
                         Interval = TimeSpan.FromMinutes(5).TotalMilliseconds,
                         AutoReset = true,
                         Enabled = true
                     };
            _timer.Elapsed += TimerElapsed;
        }


        /// <summary>
        /// Activated when <see cref="_timer"/> is elapsed.
        /// </summary>
        private async void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            await Measure().ConfigureAwait(false);
        }



        /// <summary>
        /// Starts monitoring the temperature with the <see cref="Dht11"/> sensor.
        /// </summary>
        private async Task Measure()
        {
            using var dht = new Dht11(26);
            while (true)
            {
                var temp = dht.Temperature;
                if (!dht.IsLastReadSuccessful) continue;
                var humidity = dht.Humidity;
                if (!dht.IsLastReadSuccessful) continue;

                await _unitOfWork.Measurements.AddAsync(new Measurement
                                                        {
                                                            Celsius = temp.Celsius,
                                                            Fahrenheit = temp.Fahrenheit,
                                                            Kelvin = temp.Kelvin,
                                                            Humidity = humidity
                                                        }).ConfigureAwait(false);
                return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace APImethods.Models
{
    public class SmarthomeRepo : ISmartHomeRepo
    {
        private static ConcurrentDictionary<string, Smarthome> _devices =
            new ConcurrentDictionary<string, Smarthome>();

        public SmarthomeRepo()
        {
            Add(new Smarthome { deviceName = "voordeurAlarm", deviceStatus = true });
            Add(new Smarthome { deviceName = "woonkamerVerlichting", deviceStatus = true });
            Add(new Smarthome { deviceName = "achterdeurAlarm", deviceStatus = true });
            Add(new Smarthome { deviceName = "voordeurCamera", deviceStatus = true });
            Add(new Smarthome { deviceName = "voordeurSlot", deviceStatus = true });

        }
        public IEnumerable<Smarthome> GetAll()
        {
            return _devices.Values;
        }

        public void Add(Smarthome device)
        {
            device.Key = Guid.NewGuid().ToString();
            _devices[device.Key] = device;
        }

        public Smarthome Find(string key)
        {
            Smarthome device;
            _devices.TryGetValue(key, out device);
            return device;

        }

        public Smarthome Remove(string key)
        {
            Smarthome device;
            _devices.TryGetValue(key, out device);
            _devices.TryRemove(key, out device);
            return device;
        }

        public void Update(Smarthome device)
        {
            _devices[device.Key] = device;
        }
    }
}

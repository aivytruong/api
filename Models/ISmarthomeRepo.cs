using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APImethods.Models
{
    public interface ISmartHomeRepo
    {
        void Add(Smarthome device);
        IEnumerable<Smarthome> GetAll();
        Smarthome Find(string Key);
        Smarthome Remove(string Key);
        void Update(Smarthome device);

    }
}

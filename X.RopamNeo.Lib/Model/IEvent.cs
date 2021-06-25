// Type: X.RopamNeo.Lib.Model.IEvent

using X.RopamNeo.Lib.Model.Beans;
using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model
{
    public interface IEvent
    {
        void OnEvents(Site site, List<Event> events);
    }
}
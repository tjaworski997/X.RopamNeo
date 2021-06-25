// Type: X.RopamNeo.Lib.Model.IStates

using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model
{
    public interface IStates
    {
        void OnStates(Site site, List<NeoModel> states);
    }
}
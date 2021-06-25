// Type: X.RopamNeo.Lib.Model.IState

using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model
{
    public interface IState
    {
        void OnStates(Site site, List<NeoModel> states);
    }
}
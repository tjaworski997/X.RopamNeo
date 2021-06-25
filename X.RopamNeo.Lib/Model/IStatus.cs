// Type: X.RopamNeo.Lib.Model.IStatus

namespace X.RopamNeo.Lib.Model
{
    public interface IStatus
    {
        void OnStatus(Site site, NeoModel model);

        void StatusLost();
    }
}
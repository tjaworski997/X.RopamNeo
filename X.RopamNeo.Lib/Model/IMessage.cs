// Type: X.RopamNeo.Lib.Model.IMessage

using X.RopamNeo.Lib.Model.Beans;

namespace X.RopamNeo.Lib.Model
{
    public interface IMessage
    {
        void OnMessage(Site site, Message message);
    }
}
// Type: X.RopamNeo.Lib.Model.IPhones

using X.RopamNeo.Lib.Model.Beans;
using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model
{
    public interface IPhones
    {
        void OnPhones(Site site, List<Contact> phones);
    }
}
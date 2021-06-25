// Type: X.RopamNeo.Lib.Model.IPhone

using X.RopamNeo.Lib.Model.Beans;
using System.Collections.Generic;

namespace X.RopamNeo.Lib.Model
{
    public interface IPhone
    {
        void OnPhones(Site site, List<Contact> phones);
    }
}
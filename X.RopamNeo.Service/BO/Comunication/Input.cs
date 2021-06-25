using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.RopamNeo.Service.BO.Comunication
{
    public class Input
    {
        public int Id { get; set; }
        public string OnActivate { get; set; }
        public string OnDeactivate { get; set; }

        public bool State { get; set; }
    }
}
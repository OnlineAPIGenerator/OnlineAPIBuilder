using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAPIBuilder.ViewModels
{
    public class GenericViewModel
    {
        public List<Pair> Params { get; set; }

        public class Pair
        {
            public string Name { get; set; }
        }
    }
}

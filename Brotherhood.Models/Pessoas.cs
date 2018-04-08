using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brotherhood.Models
{
    public class Pessoas
    {
        //[DbColumn(IsIdentity = true, IsPrimary = true)]
        public string CPF { get; set; }
        //[DbColumn]
        public string Name { get; set; }
    }
}

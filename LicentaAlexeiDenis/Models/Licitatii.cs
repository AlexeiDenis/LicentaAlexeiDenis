using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicentaAlexeiDenis.Models
{
    public class Licitatii
    {
        public Licitatie _detaliiLicitatie { get; set; }
            public List<Oferte> _detaliiOferte { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Abonnement
    {
        public string id { get; set; }
        public DateTime dateFinAbonnement { get; set; }
        public string idRevue { get; set; }
        public Abonnement(string id, DateTime dateFinAbonnement, string idRevue)
        {
            this.id = id;
            this.dateFinAbonnement = dateFinAbonnement;
            this.idRevue = idRevue;
        }
    }
}

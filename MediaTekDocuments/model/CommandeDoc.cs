using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class CommandeDoc
    {
        public string id { get; set; }
        public int nbExemplaire { get; set; }
        public string idLivreDvd { get; set; }
        public string idetape { get; set; }

        public CommandeDoc(string id, int nbExemplaire, string idLivreDvd, string idetape)
        {
            this.id = id;
            this.nbExemplaire = nbExemplaire;
            this.idLivreDvd = idLivreDvd;
            this.idetape = idetape;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Cmdrevue : hérite de Commande 
    /// </summary>
    public class Cmdrevue : Commande
    {
        public DateTime Fin_abonnement { get; set; }
        public String Revue { get; set; }
        public int Numero { get; set; }

        public Cmdrevue(DateTime dateFinAbonnement, DateTime dateCommande, string montant, string id, string idRevue, int numero) : base(id, dateCommande, montant)
        {
            Fin_abonnement = dateFinAbonnement;
            Revue = idRevue;
            Numero = numero;
        }
    }
}

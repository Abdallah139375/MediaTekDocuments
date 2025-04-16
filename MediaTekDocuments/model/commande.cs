using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Commande : contient les propriétés d'une commande 
    /// </summary>
    public class Commande
    {
        public string Id { get; set; }
        public DateTime DateCommande { get; set; }
        public string Montant { get; set; }
        public Commande(string id, DateTime dateCommande, string montant)
        {
            this.Id = id;
            this.DateCommande = dateCommande;
            this.Montant = montant;
        }
    }
}

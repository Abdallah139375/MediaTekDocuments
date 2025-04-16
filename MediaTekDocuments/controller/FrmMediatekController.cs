using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using System;
using Newtonsoft.Json;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {

        
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres() 
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }


        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

     

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }


        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }



        /// <summary>
        /// Ajoute une commande de livre en appelant la couche d'accès aux données.
        /// </summary>
        /// <param name="cmd">Commande de livre à ajouter.</param>
        /// <returns>True si l'ajout a réussi, False sinon.</returns>
        public bool AddcommandeLivre(Commande cmd)
        {

            Console.Write(cmd);
            return access.addcommandeLivre(cmd);
        }


        /// <summary>
        /// Ajoute une commande de document (livre) dans la table correspondante via la couche d'accès aux données.
        /// </summary>
        /// <param name="cmd">Commande de document à ajouter.</param>
        /// <returns>True si l'ajout a réussi, False sinon.</returns>
        public bool AddCommandelivretable(CommandeDoc cmd)
        {

            return access.addcommandeLivretable(cmd);
        }



        /// <summary>
        /// Supprime une commande de document en fonction de son identifiant.
        ///</summary>
        /// <param name="id">Identifiant de la commande à supprimer.</param>
        public void Deletecommandedocument(string id)
        {
            access.deletecommandedocument(id);
        }


        /// <summary>
        /// Supprime une commande via la couche d'accès aux données.
        /// </summary>
        /// <param name="cmd">Commande à supprimer.</param>
        /// <returns>True si la suppression a réussi, False sinon.</returns>
        public bool Deletecommande(Commande cmd)
        {
            return access.deletecommande(cmd);
        }



        /// <summary>
        /// Récupère la liste de toutes les commandes de livres et DVD depuis la couche d'accès aux données.
        /// </summary>
        /// <returns>Liste des commandes de type <see cref="CmdLivreDvd"/>.</returns>
        public List<CmdLivreDvd> GetAllcommandeLivre()
        {
            return access.GetAllcommandeLivre();
        }



        /// <summary>
        /// Modifie l'étape d'une commande de livre ou DVD identifiée par son ID, puis retourne la liste mise à jour des commandes.
        /// </summary>
        /// <param name="id">Identifiant de la commande à modifier.</param>
        /// <param name="etape">Nouvelle étape à appliquer à la commande.</param>
        /// <returns>Liste mise à jour des commandes de type <see cref="CmdLivreDvd"/>.</returns>
        public List<CmdLivreDvd> modifcmd(string id, Etape etape)
        {
            return access.modifcmd(id, etape);
        }



        /// <summary>
        /// Récupère la liste de toutes les commandes de DVD depuis la couche d'accès aux données.
        /// </summary>
        /// <returns>Liste des commandes de type <see cref="CmdLivreDvd"/>.</returns>
        public List<CmdLivreDvd> Getalldvdcmd()
        {
            return access.Getalldvdcmd();
        }



        ///<summary>
        /// Ajoute un abonnement en appelant la couche d'accès aux données.
        /// </summary>
        /// <param name="abn">Abonnement à ajouter.</param>
        /// <returns>True si l'ajout a réussi, False sinon.</returns>
        public bool Addabonnement(Abonnement abn)
        {

            Console.Write(abn);
            return access.Addabonnement(abn);
        }




        ///<summary>
        /// Récupère la liste de toutes les commandes de revues depuis la couche d'accès aux données.
        /// </summary>
        /// <returns>Liste des commandes de type <see cref="Cmdrevue"/>.</returns>
        public List<Cmdrevue> Getallrevuecmd()
        {
            return access.Getallrevuecmd();
        }




        /// <summary>
        /// Récupère la liste des dates d'achat pour un numéro donné depuis la couche d'accès aux données.
        /// </summary>
        /// <param name="num">Numéro pour lequel récupérer les dates d'achat.</param>
        /// <returns>Liste des dates d'achat sous forme de <see cref="DateTime"/>.</returns>
        public List<DateTime> Getdateachat(int num)
        {
            return access.Getdateachat(num);
        }

        


    }
}

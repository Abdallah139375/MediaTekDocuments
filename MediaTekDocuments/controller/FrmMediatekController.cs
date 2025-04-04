﻿using System.Collections.Generic;
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

        private const string POST = "POST";
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
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
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

       


        public bool AddcommandeLivre(Commande cmd)
        {

            Console.Write(cmd);
            return access.addcommandeLivre(cmd);
        }

        public bool AddCommandelivretable(CommandeDoc cmd)
        {

            return access.addcommandeLivretable(cmd);
        }

        

        public void Deletecommandedocument(string id)
        {
            access.deletecommandedocument(id);
        }

        public bool Deletecommande(Commande cmd)
        {
            return access.deletecommande(cmd);
        }

        public List<CmdLivreDvd> GetAllcommandeLivre()
        {
            return access.GetAllcommandeLivre();
        }

        public List<CmdLivreDvd> modifcmd(string id, Etape etape)
        {
            return access.modifcmd(id, etape);
        }

        public List<CmdLivreDvd> Getalldvdcmd()
        {
            return access.Getalldvdcmd();
        }

        public bool Addabonnement(Abonnement abn)
        {

            Console.Write(abn);
            return access.Addabonnement(abn);
        }

        
        public List<Cmdrevue> Getallrevuecmd()
        {
            return access.Getallrevuecmd();
        }
        public List<DateTime> Getdateachat(int num)
        {
            return access.Getdateachat(num);
        }

        


    }
}

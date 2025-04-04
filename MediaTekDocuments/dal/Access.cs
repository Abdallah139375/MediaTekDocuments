﻿using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Linq;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {
        /// <summary>
        /// adresse de l'API
        /// </summary>
        private static readonly string uriApi = "http://localhost/rest_mediatekdocuments/";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        public const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update
        /// 

        private const string PUT = "PUT";
        /// <summary>
        /// méthode HTTP pour delete
        private const string DELETE = "DELETE";

        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            String authenticationString;
            try
            {
                authenticationString = "admin:adminpwd";
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if(instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre", null);
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon", null);
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public", null);
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre", null);
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd", null);
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue", null);
            return lesRevues;
        }


        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocument">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument, null);
            return lesExemplaires;
        }

        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire">exemplaire à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try
            {
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire", "champs=" + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
        /// <param name="message">information envoyée dans l'url</param>
        /// <param name="parametres">paramètres à envoyer dans le body, au format "chp1=val1&chp2=val2&..."</param>
        /// <returns>liste d'objets récupérés (ou liste vide)</returns>
        public List<T> TraitementRecup<T> (String methode, String message, String parametres)
        {
            // trans
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message, parametres);
                // extraction du code retourné
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Console.WriteLine("code erreur = " + code + " message = " + (String)retour["message"]);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Erreur lors de l'accès à l'API : "+e.Message);
                Environment.Exit(0);
            }
            return liste;
        }

        /// <summary>
        /// Convertit en json un couple nom/valeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="valeur"></param>
        /// <returns>couple au format json</returns>
        private String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);
            return JsonConvert.SerializeObject(dictionary);
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }
        /// <summary>
        /// Récupérer la liste de commande de livres 
        /// </summary>
        /// <returns></returns>
       
        /// <summary>
        /// Ajouter une commande 
        /// </summary>
        /// <param name="commande"></param>
        public bool addcommandeLivre(Commande commande)
        {
            // var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(commande , new CustomDateTimeConverter());
            // var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            Console.Write(commande);
            String jsonCommande = JsonConvert.SerializeObject(commande, new CustomDateTimeConverter());
            List<Commande> liste = TraitementRecup<Commande>(POST, "commande", jsonCommande);

            return (liste != null);
        }


        public bool addcommandeLivretable(CommandeDoc commandeL)
        {
            //Console.Write(commande);
            String jsonCommandelivre = JsonConvert.SerializeObject(commandeL, new CustomDateTimeConverter());
            List<CommandeDoc> listeL = TraitementRecup<CommandeDoc>(POST, "commandedocument", jsonCommandelivre);

            return (listeL != null);
        }

        public List<CmdLivreDvd> GetAllcommandeLivre()
        {
            List<CmdLivreDvd> Laliste = TraitementRecup<CmdLivreDvd>(GET, "commandeLivre", "");
            return Laliste;
        }

        

        /// <summary>
        /// Récupérer la liste de commande de DVD
        /// </summary>
        /// <returns></returns>
        public List<CmdLivreDvd> Getalldvdcmd()
        {
            List<CmdLivreDvd> lesdates = TraitementRecup<CmdLivreDvd>(GET, "commandedvd", "");
            return lesdates;
        }

        /// <summary>
        /// Supprimer une commande
        /// </summary>
        /// <param name="id"></param>
        public bool deletecommande(Commande c)
        {
            String jsondeletecmd = JsonConvert.SerializeObject(c, new CustomDateTimeConverter());
            List<Commande> unecommande = TraitementRecup<Commande>(DELETE, "commande", jsondeletecmd); 
            return (unecommande != null);
        }

        public List<CmdLivreDvd> modifcmd(string id, Etape etape)
        {
            String jsonmodif = JsonConvert.SerializeObject(etape);
            List<CmdLivreDvd> listeapresmodif = TraitementRecup<CmdLivreDvd>(PUT, "commandedocument/" + id, jsonmodif);  
            return listeapresmodif;
        }

        public void deletecommandedocument(string id)
        {
            TraitementRecup<CmdLivreDvd>(DELETE, "commande/" + id, null); 
        }

        /// <summary>
        /// Ajouter un abonnement revue 
        /// </summary>
        /// <param name="abn"></param>
        /// <returns></returns>
        public bool Addabonnement(Abonnement abn)
        {
            String jsonabonnement = JsonConvert.SerializeObject(abn, new CustomDateTimeConverter());
            List<Abonnement> listeL = TraitementRecup<Abonnement>(POST, "abonnement", jsonabonnement);
            return (listeL != null);
        }

        /// <summary>
        /// Récupérer la liste de commande de revues
        /// </summary>
        /// <returns></returns>
        public List<Cmdrevue> Getallrevuecmd()
        {
            try
            {
                // Appel à TraitementRecup pour récupérer les commandes de revues
                List<Cmdrevue> liste = TraitementRecup<Cmdrevue>(GET, "commanderevue", "");

                if (liste == null || liste.Count == 0)
                {
                    // Si aucune commande n'est retournée, vous pouvez afficher un message ou prendre une autre action
                    Console.WriteLine("Aucune commande de revue trouvée.");
                }

                return liste;
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                Console.WriteLine("Erreur lors de la récupération des commandes de revues : " + ex.Message);
                return new List<Cmdrevue>(); // Retourner une liste vide en cas d'erreur
            }
        }


        public List<DateTime> Getdateachat(int num)
        {
            List<DateTime> lesdates = TraitementRecup<DateTime>(GET, "exemplairedate/" + num,"");
            return lesdates;
        }
    }
}

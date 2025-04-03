using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class Utilisateur
    {
        public string login { get; set; }
        public string pwd { get; set; }

        public Utilisateur(string login, string pwd)
        {
            this.login = login;
            this.pwd = pwd;
        }
    }
}

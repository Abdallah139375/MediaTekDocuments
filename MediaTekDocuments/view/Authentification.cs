using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTekDocuments.model;

namespace MediaTekDocuments.view
{
    public partial class Authentification : Form
    {
        public Authentification()
        {
            InitializeComponent();
        }

        private void btnvalider_Click(object sender, EventArgs e)
        {
            
            
            
            if (txtlogin.Text == "" || txtpwd.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs ");

            }
            else
            {
                if (txtlogin.Text == "admin" && txtpwd.Text == "pwd")
                {
                    MessageBox.Show("Bienvenue ! Vous êtes admin ");
                    FrmMediatek frm = new FrmMediatek();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    if (txtlogin.Text == "mimi" && txtpwd.Text == "Moncompte")
                    {
                        MessageBox.Show("Bienvenue ! Vous êtes de service Culture ");
                        FrmMediatek frm = new FrmMediatek();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Bienvenue ! Vous êtes de service Prêt ");
                        FrmMediatek frm = new FrmMediatek();
                        frm.Show();
                        this.Hide();
                    }
                    MessageBox.Show("Erreur d'authentification ");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Model;
using DAL;


namespace BLL
{
    public class Manager
    {
        public static bool RechercheLogin(string id, string mdp)
        {
            return Program.RequeteLogIn(id, mdp);
        }

        public static bool CreateUser(string id, string mdp)
        {
            bool res = false;
            if (Program.RequeteRechercheUser(id, mdp))
            {
                Program.RequeteSingUp(id, mdp);
                res = true;
            }
            return res;
        }

        public static bool AjouterUser(string nom, string prenom, string adresse, string tel1, string tel2, string note)
        {
            bool rep = true;
            bool estNum = long.TryParse(tel1, out _);
            if (nom == "" || prenom == "" || tel1 == "" || estNum == false)
            {
                rep = false;
            }
            else
            {
                bool estNum1 = long.TryParse(tel2, out _);
                if (tel2 != "" && estNum1)
                {
                    tel2 = Convert.ToInt64(tel1).ToString("(###)###-####");
                }
                tel1 = Convert.ToInt64(tel1).ToString("(###)###-####");
                Program.RequeteAjout(nom, prenom, adresse, tel1, tel2, note);
            }

            return rep;
        }

        public static bool ModifierUser(string numAModifier, string nom, string prenom, string adresse, string tel1, string tel2, string note)
        {
            bool res = false;
            bool estNum = long.TryParse(tel1, out _);
            bool estNum2 = long.TryParse(numAModifier, out _);
            if (nom != "" && prenom != "" && tel1 != "" && numAModifier != "" && estNum && estNum2)
            {
                numAModifier = Convert.ToInt64(numAModifier).ToString("(###)###-####");

                if (Program.RequeteVerifNum(numAModifier))
                {
                    bool estNum1 = long.TryParse(tel2, out _);
                    if (tel2 != "" && estNum1)
                    {
                        tel2 = Convert.ToInt64(tel1).ToString("(###)###-####");
                    }
                    tel1 = Convert.ToInt64(tel1).ToString("(###)###-####");

                    Program.RequeteModif(numAModifier, nom, prenom, adresse, tel1, tel2, note);
                    res = true;
                }
            }


            return res;
        }

        public static bool SupprUser(string numASupprimer)
        {
            bool res = false;
           
            bool estNum = long.TryParse(numASupprimer, out _);
            if (estNum)
            {
                numASupprimer = Convert.ToInt64(numASupprimer).ToString("(###)###-####");

                if (Program.RequeteVerifNum(numASupprimer))
                {
                    Program.RequeteSupprimer(numASupprimer);
                    res = true;
                }
            }
            return res;
        }

        public static List<Contact> AfficherOrdre(string ordre)
        {
            return Program.RequeteAfficherOrdre(ordre);
        }


        public static List<Contact> AfficherRecherche(string recherche)
        {
            List<Contact> liste = new List<Contact>();
            if (Program.RequeteRechercheUserName(recherche))
            {
                liste = Program.RequeteRecherche(recherche);

            }
            return liste;

        }
        public static List<Contact> Afficher()
        {
            return Program.RequeteAfficher();
        }
    }
}

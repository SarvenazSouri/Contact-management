using System;

namespace Model
{
    public class Contact
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string NoPhone1 { get; set; }
        public string NoPhone2 { get; set; }
        public string Note { get; set; }

        public override string ToString()
        {
            string tel2;
            string adresse;
            string note;

            if(NoPhone2 == "" || NoPhone2 == null)
            {
                tel2 = "";
            }
            else
            {
                tel2 = ", " + NoPhone2;
            }
            if (Adresse == "" || Adresse == null)
            {
                adresse = "";
            }
            else
            {
                adresse = ", " + Adresse;
            }
            if (Note == "" || Note == null)
            {
                note = "";
            }
            else
            {
                note = ", " + Note;
            }
            string retour = Nom + ", " + Prenom + ", " + NoPhone1 + adresse + tel2 + note;
            return retour;
        }
    }

    public class LogIn
    {
        public static string ID { get; set; }
        public string MDP { get; set; }
    }
}

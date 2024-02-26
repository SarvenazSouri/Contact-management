using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class Program
    {
        private static String connectionString =
                @"Data Source=*\SQLEXPRESS;
                Initial Catalog=dbContact;
                Integrated Security=True;
                Connect Timeout=5";

        public static void Connection()
        {
            Program.connectionString = Program.connectionString.Replace("*", Environment.MachineName);
        }

        public static bool RequeteLogIn(string id, string mdp)
        {
            Connection();
            int nbLigne = 0;
            LogIn.ID = id;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT COUNT(*) " +
                     "FROM Log_In " +
                     "WHERE ID = @id AND MDP = @mdp";

                cmd.Parameters.AddWithValue("id", LogIn.ID);
                cmd.Parameters.AddWithValue("mdp", mdp);

                nbLigne = (int)cmd.ExecuteScalar();


            }
            return nbLigne == 1;
        }

        public static bool RequeteRechercheUser(string id, string mdp)
        {
            Connection();
            int nbLigne = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT COUNT(*) " +
                     "FROM Log_In " +
                     "WHERE ID = @id OR MDP = @mdp";
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("mdp", mdp);
                
                nbLigne = (int)cmd.ExecuteScalar();


            }
            return nbLigne == 0;
        }

        public static void RequeteSingUp(string id, string mdp)
        {
            Connection();
            LogIn.ID = id;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT Log_In(ID, MDP) VALUES('" + id + "', '" + mdp + "')";

                cmd.ExecuteNonQuery();
            }
        }

        public static void RequeteAjout(string nom, string prenom, string adresse, string tel1, string tel2, string note)
        {
            Connection();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"INSERT Contact(Nom, Prenom, Adresse, Tel1, Tel2, Note, Code_Id) 
                    VALUES('" + nom + "', '" + prenom + "', '" + adresse + "', '" + tel1 + "', '" + tel2 + "', '" + note + "', '" + LogIn.ID + "')";

                cmd.ExecuteNonQuery();
            }
        }

        public static bool RequeteVerifNum(string numVerif)
        {
            Connection();
            int nbLigne;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT COUNT(*) " +
                      "FROM Contact " +
                      "WHERE Tel1 = @tel1";
                cmd.Parameters.AddWithValue("tel1", numVerif);

                nbLigne = (int)cmd.ExecuteScalar();

            }

            return nbLigne == 1;
        }

        public static void RequeteModif(string numAModifier, string nom, string prenom, string adresse, string tel1, string tel2, string note)
        {
            Connection();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"UPDATE Contact" +
                    " SET Nom = '" + nom + "', Prenom = '" + prenom + "', Adresse = '" + adresse + "',  Tel1 = '" + tel1 + "',  Tel2 = '" + tel2 + "', Note = '" + note + "'" +
                    " WHERE Tel1 = '" + numAModifier + "' AND Code_Id = '" + LogIn.ID + "'";

                cmd.ExecuteNonQuery();
            }
        }

        public static void RequeteSupprimer(string numASupprimer)
        {
            Connection();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"DELETE FROM Contact" +
                    " WHERE Tel1 = " + "'" + numASupprimer + "' AND Code_Id = '" + LogIn.ID + "'";

                cmd.ExecuteNonQuery();
            }
        }

        public static List<Contact> RequeteAfficherOrdre(string ordre)
        {
            Connection();
            List<Contact> liste = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT *
                      FROM Contact
                      WHERE Code_Id = '" + LogIn.ID + "'" +
                      " ORDER BY '" + ordre + "'";

                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    Contact contact = new Contact();

                    contact.Nom = res.GetString(0);
                    contact.Prenom = res.GetString(1);
                    contact.Adresse = res.IsDBNull(2) ? null : (string)res.GetString(2);
                    contact.NoPhone1 = res.GetString(3);
                    contact.NoPhone2 = res.IsDBNull(4) ? null : (string)res.GetString(4);
                    contact.Note = res.IsDBNull(5) ? null : (string)res.GetString(5);

                    liste.Add(contact);
                }
                return liste;
            }
        }

        public static List<Contact> RequeteRecherche(string nomOuPrenom)
        {
            Connection();
            List<Contact> liste = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT *
                      FROM Contact
                      WHERE Nom = '" + nomOuPrenom + "' OR Prenom = '" + nomOuPrenom + "' AND Code_Id = '" + LogIn.ID + "'";

                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    Contact contact = new Contact();

                    contact.Nom = res.GetString(0);
                    contact.Prenom = res.GetString(1);
                    contact.Adresse = res.IsDBNull(2) ? null : (string)res.GetString(2);
                    contact.NoPhone1 = res.GetString(3);
                    contact.NoPhone2 = res.IsDBNull(4) ? null : (string)res.GetString(4);
                    contact.Note = res.IsDBNull(5) ? null : (string)res.GetString(5);

                    liste.Add(contact);
                }
                return liste;
            }
        }

        public static List<Contact> RequeteAfficher()
        {
            Connection();
            List<Contact> liste = new List<Contact>();




            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                
                cmd.CommandText = @"SELECT * From Contact WHERE Code_Id ='"+LogIn.ID+"'";
                SqlDataReader res = cmd.ExecuteReader();
                while (res.Read())
                {
                    Contact contact = new Contact();

                    contact.Nom = res.GetString(0);
                    contact.Prenom = res.GetString(1);
                    contact.Adresse = res.IsDBNull(2) ? null : (string)res.GetString(2);
                    contact.NoPhone1 = res.GetString(3);
                    contact.NoPhone2 = res.IsDBNull(4) ? null : (string)res.GetString(4);
                    contact.Note = res.IsDBNull(5) ? null : (string)res.GetString(5);

                    liste.Add(contact);
                }
            }
            return liste;
        }

        public static bool RequeteRechercheUserName(string nomOuPrenom)
        {
            Connection();
            int nbLigne = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText =
                    @"SELECT COUNT(*) " +
                      "FROM Contact " +
                      "WHERE Nom = @nomOuPrenom OR Prenom = @nomOuPrenom AND Code_Id = '" + LogIn.ID + "'";

                cmd.Parameters.AddWithValue("nomOuPrenom", nomOuPrenom);
                
                nbLigne = (int)cmd.ExecuteScalar();


            }
            return nbLigne == 1;
        }
        
    }
}

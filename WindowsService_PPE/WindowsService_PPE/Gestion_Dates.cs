using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Sql;


namespace WindowsService_PPE
{
    class Gestion_Dates
    {
        //   DateTime aDateTime = new DateTime(2005, 11, 20, 12, 1, 10);

        // Imprimez des informations:
        //Retourne le mois precedent le mois actuel
        static public string GetMoisPrecedent()
        {

            return GetMoisPrecedent(DateTime.Today); // appelle de la methode GetMoisPrecedent qui prend des parametres
            //   DateTime thisDate1 = DateTime.Today; // permet d'avoir la date d'aujourd'hui

            // Console.WriteLine(thisDate1.AddMonths(-1).ToString("MM"));
            //    return thisDate1.AddMonths(-1).ToString("MM");
            //  return mois;
        }

        //retourne le mois precedent la date entré en parametre 
        static public string GetMoisPrecedent(DateTime date)
        {

            //   Console.WriteLine(date.AddMonths(-1).ToString("MM"));
            //Console.WriteLine("Today is " + date.ToString("MMMM dd, yyyy") + ".");
            return date.AddMonths(-1).ToString("MM");
        }

        //retourne le mois suivant du mois actuel
        static public string GetMoisSuivant()
        {
            //  DateTime thisDate1 = DateTime.Today; // permet d'avoir la date d'aujourd'hui
            //   Console.WriteLine(thisDate1.AddMonths(+1).ToString("MM"));

            //  return thisDate1.AddMonths(+1).ToString("MM");
            return GetMoisSuivant(DateTime.Today); // appelle de la methode GetMoisSuivant qui prend des parametres
        }
        /// <summary>
        /// retourne le mois suivant la date entré en parametre 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>

        static public string GetMoisSuivant(DateTime date)
        {

            // Console.WriteLine(date.AddMonths(+1).ToString("MM"));
            return date.AddMonths(+1).ToString("MM");
            //Console.WriteLine("Today is " + date.ToString("MMMM dd, yyyy") + ".");
        }

        /// <summary>
        /// return true si la date du jour se trouve entre les deux jours entrés en paramètre
        /// </summary>
        /// <param name="jour1"></param>
        /// <param name="jour2"></param>
        /// <returns></returns>
        static public Boolean Entre(int jour1, int jour2)
        {

            return Entre(jour1, jour2, DateTime.Today);

        }

        //        DateTime thisDate1 = DateTime.Today; // permet d'avoir la date d'aujourd'hui
        //      int j = thisDate1.Day;
        //  Console.WriteLine(jour1);
        // Console.WriteLine(thisDate1.ToString("dd"));

        // string j = thisDate1.ToString("dd");
        //    string rep = "false";
        //  if (jour1 < j & j< jour2)
        //{
        //  rep = "thrue";
        //}
        //return rep;

        //  }

        /// <summary>
        /// Return true si la date entrer en parametre se trouve entre les deux jours 
        /// </summary>
        /// <param name="jour1"></param>
        /// <param name="jour2"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public Boolean Entre(int jour1, int jour2, DateTime date)
        {

            // string j = thisDate1.ToString("dd");
            int jour = date.Day;
            //string rep = "false";

            if (jour1 <= jour & jour <= jour2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Permet de n'avoir que l'annee de la date entrer en paramètre
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String getAnnee(DateTime date)
        {
            date = date.AddMonths(-1);
            String annee = date.ToString("yyyy");
            return annee;
        }
    }
}


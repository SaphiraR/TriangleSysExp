using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSysExp
{
    internal class FactBase
    {
        //liste de fait vide au départ
        protected List<IFact> faits;
        public List<IFact> Faits
        {
            get
            {
                return faits;
            }
        }
        public FactBase()
        {
            faits = new List<IFact>();
        }

        //methode pour enlever un fait en base
        public void Nettoye()
        {
            faits.Clear();
        }
        //methode pour ajouté un fait en base
        public void AjoutFait(IFact f)
        {
            faits.Add(f);
        }

        //permettre de rechercher un fait dans la base, elle prend donc un nom
        // en parramètre et renvoie le fait si elle trouve (ou null sinon)
        public IFact Recherche(string _nom)
        {
            return faits.FirstOrDefault(x => x.Nom().Equals(_nom));
        }
        /*permettre de retrouver la valeur d'un fait dans la base*/
        public object Valeur(string _nom)
        {
            IFact f = faits.FirstOrDefault(x => x.Nom().Equals(_nom));
            if (f != null)
            {
                return f.Valeur();
            }
            else
            {
                return null;
            }
        }
    }
}

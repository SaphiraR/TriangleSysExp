using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSysExp
{
    internal class IntFact : IFact
    {
        protected String nom;
        public String Nom()
        {
            return nom;
        }
        protected int valeur;
        public Object Valeur()
        {
            return valeur;
        }
        protected int niveaux;
        public int Niveaux()
        {
            return niveaux;
        }
        public void SetNiveaux(int l)
        {
            niveaux = l;
        }

        protected String question = null;
        public String Question()
        {
            return question;
        }

        public IntFact(string _nom, int _valeur, String _question = null, int _niveaux = 0)
        {
            nom = _nom;
            valeur = _valeur;
            question = _question;
            niveaux = _niveaux;
        }

        public override string ToString()
        {
            return nom + " = " + valeur + " (" + niveaux + ")";
        }

    }
}

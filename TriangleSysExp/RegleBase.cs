using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSysExp
{
    internal class RegleBase
    {
        protected List<Regle> regles;
        public List<Regle> Regles
        {
            get
            {
                return regles;
            }
            set
            {
                regles = value;
            }
        }
        public RegleBase()
        {
            regles = new List<Regle>();
        }

        public void NettoyerBase()
        {
            regles.Clear();
        }
        public void AjoutRegle(Regle r)
        {
            regles.Add(r);
        }

        public void retirer(Regle R)
        {
            regles.Remove(R);
        }

    }
}

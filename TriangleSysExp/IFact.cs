using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSysExp
{
    /* cette interface possède plusieurs méthodes
    pour lire les attributs et une méthode pour le nivaux de faits*/
    public interface IFact
    {
        String Nom();
        Object Valeur();
        int Niveaux();
        String Question();

        void SetNiveaux(int p);
    }
}

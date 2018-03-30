using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSysExp
{
    public interface humanInterfaces
    {
        int DemandeIntValeur(String question);
        bool DemandeBoolValeur(String question);
        void PrintFait(List<IFact> faits);
        void PrintRegle(List<Regle> regles);
    }
}

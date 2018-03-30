using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSysExp
{
    internal static class FactFactory
    {
        internal static IFact Fait(IFact f, Moteur m)
        {
            IFact nvxfait;
            if (f.GetType().Equals(typeof(IntFact)))
            {
                int valeur = m.DemandeIntValeur(f.Question());
                nvxfait = new IntFact(f.Nom(), valeur, null, 0);
            }
            else
            {
                bool valeur = m.DemandeBoolValeur(f.Question());
                nvxfait = new BoolFact(f.Nom(), valeur, null, 0);
            }
            return nvxfait;
        }
        internal static IFact Fait(string FaitStg)
        {
            FaitStg = FaitStg.Trim();
            if (FaitStg.Contains("="))
            {
                String[] nomVal = FaitStg.Split(new String[]
                {
                    "=", "(",")"
                }, StringSplitOptions.RemoveEmptyEntries);
                if (nomVal.Length >= 2)
                {
                    String question = null;
                    if (nomVal.Length >= 3)
                    {
                        question = nomVal[2].Trim();
                    }
                    return new IntFact(nomVal[0].Trim(), int.Parse(nomVal[1].Trim()), question);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                bool val = true;
                if (FaitStg.StartsWith("!"))
                {
                    val = false;
                    FaitStg = FaitStg.Substring(1).Trim();
                }
                String[] nomQuestion = FaitStg.Split(new String[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                String question = null;
                if (nomQuestion.Length == 2)
                {
                    question = nomQuestion[1].Trim();
                }
                return new BoolFact(nomQuestion[0].Trim(), val, question);
            }
            //internal static IFact Fact(String FaitStg) 
        }


    }
}

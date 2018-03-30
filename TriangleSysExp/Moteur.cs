using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSysExp
{
    public class Moteur
    {
        private FactBase fDB;
        private RegleBase rDB;
        private humanInterfaces ihm;

        public Moteur(humanInterfaces _ihm)
        {
            ihm = _ihm;
            fDB = new FactBase();
            rDB = new RegleBase();
        }

        internal int DemandeIntValeur(string p)
        {
            return ihm.DemandeIntValeur(p);

        }
        internal bool DemandeBoolValeur(string p)
        {
            return ihm.DemandeBoolValeur(p);

        }

        /*cette méthode doit donc parcourir les faits en prémisses et vérifier s'ils existent dans la base de faits*/
        private int Applicable(Regle r)
        {
            int nivMax = -1;
            foreach (IFact f in r.Premises)
            {
                IFact FaitTrouv = fDB.Recherche(f.Nom());
                if (FaitTrouv == null)
                {
                    if (f.Question() != null)
                    {
                        FaitTrouv = FactFactory.Fait(f, this);
                        fDB.AjoutFait(FaitTrouv);
                        nivMax = Math.Max(nivMax, 0);
                    }
                    else
                    {
                        return -1;
                    }
                }
                if (!FaitTrouv.Valeur().Equals(f.Valeur()))
                {
                    return -1;
                }
                else
                {
                    nivMax = Math.Max(nivMax, FaitTrouv.Niveaux());
                }
            }
            return nivMax;
        }
        //TrouvRegleApplicable va permetre chercher dans la bases de regle
        // la premiere applicable et s'appuis sur la méthode Applicable
        private Tuple<Regle, int> TrouvRegleApplicable(RegleBase rBase)
        {
            foreach (Regle r in rBase.Regles)
            {
                int niv = Applicable(r);
                if (niv != -1)
                {
                    return Tuple.Create(r, niv);
                }
            }
            return null;
        }

        public void resoudre()
        {
            bool plusDeRegle = true;
            RegleBase regleUtilisable = new RegleBase();
            regleUtilisable.Regles = new List<Regle>(rDB.Regles);
            fDB.Nettoye();

            while (plusDeRegle)
            {
                Tuple<Regle, int> regleAapplique = TrouvRegleApplicable(regleUtilisable);
                if (regleAapplique != null)
                {
                    IFact nvxFait = regleAapplique.Item1.Conclusion;
                    nvxFait.SetNiveaux(regleAapplique.Item2 + 1);
                    fDB.AjoutFait(nvxFait);
                    regleUtilisable.retirer(regleAapplique.Item1);
                }
                else
                {
                    plusDeRegle = false;
                }
            }
            ihm.PrintFait(fDB.Faits);
        }

        public void AjoutRegle(string regleStr)
        {
            String[] slpNom = regleStr.Split(new String[] { " : ", }, StringSplitOptions.RemoveEmptyEntries);
            if (slpNom.Length == 2)
            {
                String nom = slpNom[0];
                String[] slpPremConcl = slpNom[1].Split(new String[] { "SI", "ALORS" }, StringSplitOptions.RemoveEmptyEntries);
                if (slpPremConcl.Length == 2)
                {
                    List<IFact> premises = new List<IFact>();
                    String[] premiseStr = slpPremConcl[0].Split(new String[] { " ET ", }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (String prem in premiseStr)
                    {
                        IFact premise = FactFactory.Fait(prem);
                        premises.Add(premise);
                    }
                    String conclusionStr = slpPremConcl[1].Trim();
                    IFact conclusion = FactFactory.Fait(conclusionStr);
                    rDB.AjoutRegle(new Regle(nom, premises, conclusion));
                }

            }
        }
    }
}

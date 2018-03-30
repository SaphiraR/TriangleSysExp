using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSysExp
{
    class Program : humanInterfaces
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public int DemandeIntValeur(String p)
        {
            Console.Out.WriteLine(p);
            try
            {
                return int.Parse(Console.In.ReadLine());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool DemandeBoolValeur(String p)
        {
            Console.WriteLine(p + " (yes, no)");
            String res = Console.In.ReadLine();
            return (res.Equals("yes"));
        }

        public void PrintFait(List<IFact> fait)
        {
            String res = "Solution(s) trouvée(s) : \n";
            res += string.Join("\n", fait.Where(x => x.Niveaux() > 0).OrderByDescending(x => x.Niveaux()));
            Console.WriteLine(res);
        }
        public void PrintRegle(List<Regle> regle)
        {
            string res = "";
            res = String.Join("\n", regle);
            Console.WriteLine(res);
        }

        public void Run()
        {
            //Moteur
            Console.WriteLine("Création du moteur");
            Moteur m = new Moteur(this);

            //Regles
            Console.WriteLine("*AJOUT DES REGLES*");
            //regle triangle
            m.AjoutRegle("R1 : SI (Cotés=3(Combiens de coté possède la figure ?)) ALORS Triangle");
            //regle triangle rectangle
            m.AjoutRegle("R2 : SI (Triangle ET Angle Droit (La figure a t-elle un angle Droit?)) ALORS Triangle Rectangle");
            //regle triangle isocel
            m.AjoutRegle("R3 : SI (Triangle ET Cotes Egaux= 2 (Combiens de coté éguaux possède la figure ?)) ALORS Triangle Isocèle");
            //regle triangle retangle isocel
            m.AjoutRegle("R4 : SI (Triangle Rectangle ET Triangle Isocèle) ALORS Triangle rectangle Isocèle");
            //regle triangle équilatéral
            m.AjoutRegle("R5 : SI (Triangle ET Cotes Egaux= 3 (Combiens de coté possède la figure ?)) ALORS Triangle Equilateral");

            //résolution
            while (true)
            {
                Console.WriteLine("\n** Résolution **");
                m.resoudre();
            }
        }
    }
}

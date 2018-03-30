using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSysExp
{
    public class Regle
    {
        public List<IFact> Premises { get; set; }
        public IFact Conclusion { get; set; }
        public String Nom { get; set; }

        public Regle(String _nom, List<IFact> _premises, IFact _conclusion)
        {
            Nom = _nom;
            Premises = _premises;
            Conclusion = _conclusion;
        }
        public override string ToString()
        {
            return Nom + " : SI (" + String.Join(" ET ", Premises) + ") ALORS" + Conclusion.ToString();
        }
    }
}

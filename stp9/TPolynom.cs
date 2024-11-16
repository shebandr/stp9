using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace stp9
{
    public class TPolynom
    {
        public SortedSet<TMember> Members;
        public TPolynom()
        {
            Members = new SortedSet<TMember>();
            Members.Add(new TMember(0, 0));
        }
        public TPolynom Add(TPolynom tp)
        {
            TPolynom newtpoly = new TPolynom();
            foreach (TMember mem in tp.Members)
            {
                newtpoly.Members.Add(new TMember(mem.FCoeff, mem.FDegree));
            }
            foreach (TMember mem in this.Members)
            {
                newtpoly.Members.Add(new TMember(mem.FCoeff, mem.FDegree));
            }
            return newtpoly;
        }
        public TPolynom Mul(TPolynom tp)
        {
            TPolynom newtpoly = new TPolynom();
            foreach (TMember mem in tp.Members)
            {
                foreach (TMember newmem in this.Members)
                {
                    newtpoly.Members.Add(new TMember(newmem.FCoeff * mem.FCoeff, newmem.FDegree + mem.FDegree));
                }
            }
            return newtpoly;
        }
        public TPolynom Res(TPolynom tp)
        {
            TPolynom newtpoly = new TPolynom();
            foreach (TMember mem in tp.Members)
            {
                newtpoly.Members.Add(new TMember(-mem.FCoeff, mem.FDegree));
            }
            foreach (TMember mem in this.Members)
            {
                newtpoly.Members.Add(new TMember(mem.FCoeff, mem.FDegree));
            }
            return newtpoly;
        }
        public TPolynom Rev()
        {
            TPolynom newtpoly = new TPolynom();
            foreach (TMember mem in this.Members)
            {
                newtpoly.Members.Add(new TMember(-mem.FCoeff, mem.FDegree));
            }
            return newtpoly;
        }
        public int RetDegree()
        {
            return Members.Last().FDegree;
        }
        public int RetCoeff(int n)
        {
            try { return Members.Single(x => x.FDegree == n).FCoeff; }
            catch (InvalidOperationException) { return 0; }
        }
        public override bool Equals(object tp)
        {
            if (((TPolynom)tp).Members.SequenceEqual(this.Members)) return true;
            else return false;
        }
        public TPolynom Diff()
        {
            TPolynom newtpoly = new TPolynom();
            foreach (TMember mem in this.Members)
            {
                newtpoly.Members.Add(new TMember(mem.FCoeff, mem.FDegree).Diff());
            }
            return newtpoly;
        }
        public double Calculate(double a)
        {
            double an = 0.0;
            foreach (TMember mem in this.Members)
            {
                an += mem.Calculate(a);
            }
            return an;
        }
        public void Clear()
        {
            Members = new SortedSet<TMember>
            {
                new TMember(0, 0)
            };
        }
        public Tuple<int, int> ElementAt(int i)
        {
            try { return Tuple.Create(this.Members.Reverse().ElementAt(i).FCoeff, this.Members.Reverse().ElementAt(i).FDegree); }
            catch (ArgumentOutOfRangeException) { return Tuple.Create(0, 0); }

        }
        public string Show()
        {
            string str = "";
            foreach (TMember x in Members.Reverse())
            {
                str += (x.FCoeff > 0) ? "+" : "";
                str += x.TMember2Str();
            }
            return str.TrimStart('+');
        }
    }
}

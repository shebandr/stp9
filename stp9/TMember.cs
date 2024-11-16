using System;
using System.Collections.Generic;
using System.Text;

namespace stp9
{
    public class TMember : IComparable<TMember>
    {
        private int fcoeff;
        private int fdegree;
        public int FCoeff
        {
            get { return fcoeff; }
            set
            {
                if (value == 0)
                    fdegree = 0;
                fcoeff = value;
            }
        }
        public int FDegree
        {
            get { return fdegree; }
            set
            {
                if (fcoeff == 0)
                    fdegree = 0;
                else fdegree = value;
            }
        }
        public TMember(int coeff = 0, int degree = 0)
        {
            FCoeff = coeff;
            FDegree = degree;
        }
        public override bool Equals(object tmem)
        {
            if ((((TMember)tmem).FCoeff == this.FCoeff) && (((TMember)tmem).FDegree == this.FDegree))
                return true;
            else
                return false;
        }
        public TMember Diff()
        {
            return new TMember() { FCoeff = (this.FCoeff * this.FDegree), FDegree = this.FDegree - 1 };
        }
        public double Calculate(double a)
        {
            return this.FCoeff * Math.Pow(a, this.FDegree);
        }
        public string TMember2Str()
        {
            return this.FCoeff == 0 ? "" : $"{this.FCoeff}x^{this.FDegree}";
        }

        public int CompareTo(TMember other)
        {
            if (this.FDegree.CompareTo(other.FDegree) != 0)
                return this.FDegree.CompareTo(other.FDegree);
            else
            {
                other.FCoeff += this.FCoeff;
                return 0;
            }
        }
    }
}

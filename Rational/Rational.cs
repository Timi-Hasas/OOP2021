using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    class Rational
    {
        private int numarator;
        private int numitor;
        private void Simplify()
        {
            if (numarator != 0)
            {
                int cmmdc = Cmmdc(Math.Abs(numarator), Math.Abs(numitor));
                numarator /= cmmdc;
                numitor /= cmmdc;
            }

        }

        private int Cmmdc(int first, int second)
        {
            while(first != second)
            {
                if (first > second) 
                    first = first - second;
                else 
                    second = second - first;
            }
            return first;
        }

        public Rational(int numarator, int numitor)
        {
            if (numitor == 0)
                numitor = 1;

            if (numitor < 0)
            {
                numarator *= -1;
                numitor *= -1;
            }

            this.numarator = numarator;
            this.numitor = numitor;

            Simplify();
        }

        public override string ToString()
        {
            if (numitor == 1)
                return $"( {numarator} )";

            if(numitor == -1)
                return $"( - {numarator} )";

            if (numarator == numitor)
                return $"( {numarator} )";

            if(numarator == 0)
                return $"( {numarator} )";

            if (numitor < 0 || numarator < 0)
                return $"(- {Math.Abs(numarator)} / {Math.Abs(numitor)} )";
            
                return $"( {numarator} / {numitor} )";
        }

        public Rational Add(Rational toAdd)
        {
            Rational result;
            if (numitor != toAdd.numitor)
            {
                result = new Rational(numarator * toAdd.numitor + toAdd.numarator * numitor, numitor * toAdd.numitor);
                return result;
            }
            result = new Rational(numarator + toAdd.numarator, numitor);
            return result;
        }

        public static Rational operator + (Rational first, Rational second)
        {
            Rational result;
            if (first.numitor != second.numitor)
            {
                result = new Rational(first.numarator * second.numitor + second.numarator * first.numitor, first.numitor * second.numitor);
                return result;
            }
            result = new Rational(first.numarator + second.numarator, first.numitor);
            return result;
        }

        public Rational Add(int toAdd)
        {
            Rational newAdd = new Rational(toAdd * numitor, numitor);
            Rational result = Add(newAdd);
            return result;
        }

        public static Rational operator +(Rational first, int second)
        {
            Rational newAdd = new Rational(second * first.numitor, first.numitor);
            Rational result = newAdd.Add(first);
            return result;
        }

        public static Rational operator +(int second, Rational first)
        {
            Rational newAdd = new Rational(second * first.numitor, first.numitor);
            Rational result = newAdd.Add(first);
            return result;
        }
        public Rational Substract(Rational toSub)
        {
            Rational result;
            if(numitor != toSub.numitor)
            {
                result = new Rational(numarator * toSub.numitor - toSub.numarator * numitor, numitor * toSub.numitor);
                return result;
            }
            result = new Rational(numarator - toSub.numarator, numitor);
            return result;
        }
        public Rational Substract(int toSub)
        {
            Rational newSub = new Rational(toSub * numitor, numitor);
            Rational result = Substract(newSub);
            return result;
        }
        public static Rational operator - (Rational first, int second)
        {
            Rational newSub = new Rational(second * first.numitor, first.numitor);
            Rational result = newSub.Substract(first);
            result.numarator *= -1;
            return result;
        }

        public static Rational operator -(int second, Rational first)
        {
            Rational newSub = new Rational(second * first.numitor, first.numitor);
            Rational result = newSub.Substract(first);
            return result;
        }

        public static Rational operator - (Rational first, Rational second)
        {
            Rational result;
            if (first.numitor != second.numitor)
            {
                result = new Rational(first.numarator * second.numitor - second.numarator * first.numitor, first.numitor * second.numitor);
                return result;
            }
            result = new Rational(first.numarator - second.numarator, first.numitor);
            return result;
        }

        public Rational Multiply(Rational toMult)
        {
            Rational result = new Rational(numarator * toMult.numarator, numitor * toMult.numitor);
            return result;
        }

        public static Rational operator * (Rational first, Rational second)
        {
            Rational result = new Rational(first.numarator * second.numarator, first.numitor * second.numitor);
            return result;
        }

        public Rational Multiply(int toMult)
        {
            Rational result = new Rational(numarator * toMult, numitor);
            return result;
        }
        public static Rational operator *(Rational first, int second)
        {
            Rational result = new Rational(first.numarator * second, first.numitor);
            return result;
        }

        public static Rational operator *(int second, Rational first)
        {
            Rational result = new Rational(first.numarator * second, first.numitor);
            return result;
        }

        public Rational Divide(Rational toDiv)
        {
            Rational result = new Rational(numarator * toDiv.numitor, numitor * toDiv.numarator);
            return result;
        }
        public static Rational operator / (Rational first, Rational second)
        {
            Rational result = new Rational(first.numarator * second.numitor, first.numitor * second.numarator);
            return result;
        }

        public Rational Divide(int toDiv)
        {
            Rational result = new Rational(numarator, numitor * toDiv);
            return result;
        }

        public static Rational operator / (Rational first, int second)
        {
            Rational result = new Rational(first.numarator, first.numitor * second);
            return result;
        }

        public static Rational operator /(int second, Rational first)
        {
            Rational result = new Rational(first.numitor * second, first.numarator);
            return result;
        }

        public Rational Power(int power)
        {
            if(power > 0)
            {
                Rational result;
                result = new Rational((int)Math.Pow(numarator, power), (int)Math.Pow(numitor, power));
                return result;
            }
            else
            {
                Rational result;
                result = new Rational((int)Math.Pow(numitor,power),(int)Math.Pow(numarator, power));
                return result;
            }
        }

        public static bool operator ==(Rational first, Rational second)
        {
            if (first.numarator == second.numarator && first.numitor == second.numitor)
                return true;
            return false;
        }

        public static bool operator !=(Rational first, Rational second)
        {
            if (first.numarator == second.numarator && first.numitor == second.numitor)
                return false;
            return true;
        }

        public int Numarator
        {
            get
            {
                return numarator;
            }
        }

        public int Numitor
        {
            get
            {
                return numitor;
            }
        }
        public float Zecimal
        {
            get
            {
                return numarator / numitor;
            }
        }
    }
}

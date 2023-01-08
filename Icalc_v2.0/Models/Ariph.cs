using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icalc_v2._0.Models
{
    static class Ariph
    {
        public static string Plus(string a, string b)=> Convert.ToString(Convert.ToDouble(a)+Convert.ToDouble(b));
        //public static string Minus(string a, string b)=> a-b;
        //public static string Multiplication(string a, string b)=> a*b;
        //public static string Division(string a, string b)=> a/b;
        //public static string MinusOne(string a)=> a*(-1);
        //public static string Percent(string a)=> a/(100);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icalc_v2._0.Models
{
    internal class AddNumbers
    {
        public static string AddNum(string label, string num) => Convert.ToString(label) + Convert.ToString(num);
    }
}

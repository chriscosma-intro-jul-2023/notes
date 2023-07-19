using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSyntax
{
    public class Utils
    {
        public static string FormatName(string firstName, string lastName)
        {
            return $"{lastName.Trim()}, {firstName.Trim()}";
        }
    }
}

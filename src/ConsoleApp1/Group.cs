using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Group
    {
        public string Name { get; set; }
        public Dictionary<string, List<string>> TvList { get;set; } = new Dictionary<string, List<string>>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Name);
            foreach (var item in TvList) {
                sb.AppendLine($"{item.Key},{item.Value}");
            }
            return sb.ToString();
        }
    }
}

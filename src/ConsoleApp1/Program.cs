using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    internal class Program {
        static List<Group> Groups;
        static void Main(string[] args) {
            Groups = new List<Group>();
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\..\..\江苏移动V6.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var results = line.Split(new char[] { ',' });
                        if (line.Contains("#genre#"))
                        {
                            var group = new Group() { Name = results[0].Trim() };
                            Groups.Add(group);
                        }
                        else if (line.Contains("http"))
                        {
                            var tvList = Groups.Last().TvList;
                            var key = results[0];
                            var value = results[1];
                            if (tvList.ContainsKey(key))
                            {
                                var list = tvList[key];
                                if (list == null) list = new List<string>();
                                list.Add(value);
                            }
                            else
                            {
                                tvList[key] = new List<string>() { value };
                            }
                        }
                    }
                }

               
            }
            catch (Exception ex) { 
                Console.WriteLine(ex);
            }
           
        }
    }
}

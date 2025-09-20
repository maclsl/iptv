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
            var groups = ReadTvTxt("..\\..\\..\\..\\江苏移动V6.txt");
            var tvList = ReadM3u8("");
        }

        static List<Group> ReadTvTxt(string path) {
            var groups = new List<Group>();
            try
            {
                using (StreamReader sr = new StreamReader(@path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var results = line.Split(new char[] { ',' });
                        if (line.Contains("#genre#"))
                        {
                            var group = new Group() { Name = results[0].Trim() };
                            groups.Add(group);
                        }
                        else if (line.Contains("http"))
                        {
                            var tvList = groups.Last().TvList;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return groups;
        }

        static Dictionary<string, List<string>> ReadM3u8(string fileName)
        {
            using (StreamReader sr = new StreamReader(@fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                }
            }
        }
    }
}

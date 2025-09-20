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
            ParseScanResult();
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
                            var value = results[1].TrimEnd();
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

        static void ParseScanResult()
        {
            var tvList = new List<(string, string)>();
            string fileName = "..\\..\\..\\..\\scan.txt";
            using (StreamReader sr = new StreamReader(@fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("http"))
                    {
                        var results = line.Split(new char[] { ',' });
                        var name = results[0].Trim();
                        var address = results[1].TrimEnd();
                        var names = name.Split(new char[] { '[', '*', ']' });
                        var width = int.Parse(names[1]);
                        if(width > 1920)
                        {
                            tvList.Add((name, address));
                        }
                    }
                }
            }

            string fileName2 = "..\\..\\..\\..\\scansort.txt";
            string[] lines = tvList.Select(f => $"{f.Item1},{f.Item2}").ToArray();
            File.WriteAllLines(@fileName2, lines);
        }
    }
}

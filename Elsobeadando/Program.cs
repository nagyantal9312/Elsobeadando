using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Elsobeadando
{
    class Program
    {   


        public static void Kiirat(string sorszam)
        {
            
            string filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\")) + @"results\task" + sorszam + ".csv";

            switch (sorszam)
            {
                case "3":
                    var harom = from karakter in karakterLista
                                join bolygo in bolygoLista on karakter.Homeworld equals bolygo.Name into csoport
                                from item in csoport.DefaultIfEmpty()
                                select new { nev = karakter.Name, otthon = karakter.Homeworld, nepesseg = item?.Population };

                    using (var w = new StreamWriter(filePath))
                    {
                        foreach (var item in harom)
                        {
                            var first = item.nev;
                            var second = item.otthon;
                            var third = item.nepesseg;
                            var line = string.Format("{0},{1},{2}", first, second, third);
                            w.WriteLine(line);
                            w.Flush();
                        }
                    }
                    break;
                case "4":

                    var negy_sub = from karakter in karakterLista
                                   join bolygo in bolygoLista on karakter.Homeworld equals bolygo.Name into csoport
                                   from item in csoport.DefaultIfEmpty()
                                   select new { nev = karakter.Name, atmero = item?.Diameter };

                    var negy = from item in negy_sub
                               where item.atmero > 10000
                               orderby item.atmero descending
                               select item;

                    using (var w = new StreamWriter(filePath))
                    {
                        foreach (var item in negy)
                        {
                            var first = item.nev;
                            var second = item.atmero;
                            var line = string.Format("{0},{1}", first, second);
                            w.WriteLine(line);
                            w.Flush();
                        }
                    }
                    break;
                case "5":

                    var ot = from karakter in karakterLista
                             where karakter.Eye_color == ("blue")
                             orderby karakter.Mass ascending
                             select karakter;

                    using (var w = new StreamWriter(filePath))
                    {
                        foreach (var item in ot)
                        {
                            var first = item.Name;
                            var second = item.Mass;
                            var line = string.Format("{0},{1}", first, second);
                            w.WriteLine(line);
                            w.Flush();
                        }
                    }
                    break;
                case "6":

                    var hat_sub = from bolygo in bolygoLista
                                  join karakter in karakterLista on bolygo.Name equals karakter.Homeworld into csoport
                                  from item in csoport.DefaultIfEmpty()
                                  select new { nev = bolygo?.Name, karakter = item?.Name };

                    var hat = from egyed in hat_sub
                              group egyed by egyed.nev into csoport
                              select new
                              {
                                  kulcs = csoport?.Key,
                                  szam = csoport?.Count(o => o.karakter != null),
                              };

                    using (var w = new StreamWriter(filePath))
                    {
                        foreach (var item in hat)
                        {
                            var first = item.kulcs;
                            var second = item.szam;
                            var line = string.Format("{0},{1}", first, second);
                            w.WriteLine(line);
                            w.Flush();
                        }
                    }
                    break;
                case "7":

                    var het_sub = from bolygo in bolygoLista
                                  join karakter in karakterLista on bolygo.Name equals karakter.Homeworld into csoport
                                  from item in csoport.DefaultIfEmpty()
                                  select new { nev = bolygo?.Name, karakter = item?.Name };

                    var het_sub2 = from egyed in het_sub
                              group egyed by egyed.nev into csoport
                              select new
                              {
                                  kulcs = csoport?.Key,
                                  szam = csoport?.Count(o => o.karakter != null),
                              };

                    var het = from egyed in het_sub2
                              where egyed.szam == 0
                              select egyed.kulcs;

                    using (var w = new StreamWriter(filePath))
                    {
                        foreach (var item in het)
                        {
                            var first = item;
                            var line = string.Format("{0}", first);
                            w.WriteLine(line);
                            w.Flush();
                        }
                    }
                    break;
                case "8":

                    var legnagyobbNepessegu = (from bolygo in bolygoLista
                                               orderby bolygo.Population descending
                                               select bolygo.Name).Take(1);

                    var nyolc = from karakter in karakterLista
                                join valami in ((from bolygo in bolygoLista
                                                 orderby bolygo.Population descending
                                                 select bolygo.Name).Take(1)
                                                )
                                                on karakter.Homeworld equals valami
                                select karakter;

                    using (var w = new StreamWriter(filePath))
                    {
                        foreach (var item in nyolc)
                        {
                            var first = item.Name;
                            var line = string.Format("{0}", first);
                            w.WriteLine(line);
                            w.Flush();
                        }
                    }
                    break;
                case "9":
                    var kilenc = (from bolygo in bolygoLista
                                  where bolygo.Population != null
                                  orderby bolygo.Population ascending
                                  select bolygo).Take(1);

                    using (var w = new StreamWriter(filePath))
                    {
                        foreach (var item in kilenc)
                        {
                            var first = item.Name;
                            var second = item.Population;
                            var line = string.Format("{0},{1}", first, second);
                            w.WriteLine(line);
                            w.Flush();
                        }
                    }
                    break;
                default:

                    Console.Error.WriteLine("Hibás input, a megfelelő input egy 3-9 közötti szám stringként megadva");
                    break;

            }
        }

        static readonly List<Planet> bolygoLista = Planet.beolvas();
        static readonly List<Character> karakterLista = Character.beolvas();




        static void Main(string[] args)
        {

            Kiirat("3");
            Kiirat("4");
            Kiirat("5");
            Kiirat("6");
            Kiirat("7");
            Kiirat("8");
            Kiirat("9");
  
        }
    }
}

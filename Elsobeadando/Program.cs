using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace Elsobeadando
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            List<Planet> eredmeny = Planet.beolvas();

            foreach(Planet egyed in eredmeny)
            {
                Console.WriteLine(egyed.ToString());
            }
            */

            /*
            List<Character> lista = Character.beolvas();

            foreach (Character egyed in lista)
            {
                Console.WriteLine(egyed.ToString());
            }
            */




            List<Planet> bolygoLista = Planet.beolvas();
            List<Character> karakterLista = Character.beolvas();


            
            var harom = from karakter in karakterLista
                        join bolygo in bolygoLista on karakter.Homeworld equals bolygo.Name into csoport
                        from item in csoport.DefaultIfEmpty()
                        select new { nev = karakter.Name, otthon = karakter.Homeworld, nepesseg = item?.Population };

            /*
            foreach(var item in harom)
            {
                Console.WriteLine(item);
            }
            */

            /*
            var negy_sub = from karakter in karakterLista
                       join bolygo in bolygoLista on karakter.Homeworld equals bolygo.Name into csoport
                       from item in csoport.DefaultIfEmpty()
                       select new { nev = karakter.Name, atmero = item?.Diameter };

            var negy = from item in negy_sub
                       where item.atmero > 10000
                       orderby item.atmero descending
                       select item;
            


            foreach (var item in negy)
            {
                Console.WriteLine(item);
            }
            */

            /*
            var ot = from karakter in karakterLista
                     where karakter.Eye_color == ("blue")
                     orderby karakter.Mass ascending
                     select karakter;

            foreach (Character character in ot)
                Console.WriteLine(character.Name + " " + character.Mass + " " + character.Eye_color);
            */

            /*
            var hat_sub = from bolygo in bolygoLista
                      join karakter in karakterLista on bolygo.Name equals karakter.Homeworld into csoport
                      from item in csoport.DefaultIfEmpty()
                      select new { nev = bolygo?.Name, karakter = item?.Name };


            var hat = from egyed in hat_sub
                         group egyed by egyed.nev into csoport
                         select new
                         {
                             kulcs = csoport?.Key,
                             szam = csoport?.Count(),
                         };

            
            foreach (var item in hat)
                Console.WriteLine(item.kulcs + " " + item.szam);


            int i = 0;
            foreach(var item in hat)
            {
                i++;
                Console.WriteLine(item);
                    Console.WriteLine("AZIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII: " +i);


            }

            */

            var roflmao = from bolygo in bolygoLista
                          join karakter in karakterLista on bolygo.Name equals karakter.Homeworld into csoport
                          from item in csoport.DefaultIfEmpty()
                          select new { nev = bolygo?.Name, karakter = item?.Name };

            /*
            foreach (var item in roflmao)
            {
                Console.WriteLine(item);
            }
            */

            /*
            var hat = from egyed in roflmao
                      group egyed by egyed.nev into csoport
                      select new
                      {
                          
                          kulcs = csoport?.Key,
                          szam = csoport?.Count(o => o.karakter != null),
                      };


            foreach (var item in hat)
            {
                Console.WriteLine(item);
            }

            var het = from egyed in hat
                      where egyed.szam == 0
                      select egyed.kulcs;


            foreach (var item in het)
            {
                Console.WriteLine(item);
            }
            */

            /*
            var legnagyobbNepessegu = (from bolygo in bolygoLista
                                       orderby bolygo.Population descending
                                       select bolygo.Name).Take(1);
            
            foreach (var item in legnagyobbNepessegu)
                Console.WriteLine(item);

            
            var nyolc = from karakter in karakterLista
                        join valami in ((from bolygo in bolygoLista
                                         orderby bolygo.Population descending
                                         select bolygo.Name).Take(1)
                                        )
                                        on karakter.Homeworld equals valami
                        select karakter;

            foreach (var item in nyolc)
                Console.WriteLine(item);
            */

            /*
            var kilenc = (from bolygo in bolygoLista
                         where bolygo.Population != null
                         orderby bolygo.Population ascending
                         select bolygo).Take(1);

            foreach (Planet planet in kilenc)
                Console.WriteLine(planet.Name + " " + planet.Population);

            */


































        }
    }
}

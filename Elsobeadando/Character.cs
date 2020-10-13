using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Elsobeadando
{
    class Character
    {

        public string Name { get; set; }
        public int? Height { get; set; }
        public double? Mass { get; set; }
        public string Hair_color { get; set; }
        public string Skin_color { get; set; }
        public string Eye_color { get; set; }
        public string Birth_year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        public string Species { get; set; }

        public Character(string name, int? height, double? mass, string hair_color, string skin_color, string eye_color, string birth_year, string gender, string homeworld, string species)
        {
            this.Name = name;
            this.Height = height;
            this.Mass = mass;
            this.Hair_color = hair_color;
            this.Skin_color = skin_color;
            this.Eye_color = eye_color;
            this.Birth_year = birth_year;
            this.Gender = gender;
            this.Homeworld = homeworld;
            this.Species = species;
        }

        public Character()
        {
        }

        public override string ToString()
        {
            return "Name: " + Name + " | height: " +Height + " | mass: " + Mass + " | hair_color: " + Hair_color +
                " | skin_color: " + Skin_color + " | eye_color: " + Eye_color + " | birth_year: " + Birth_year + " | gender: " + Gender + " | homeworld: " +
                Homeworld + " | species: " + Species + "\n";
        }

        public static List<Character> beolvas()
        {
            var karakterLista = new List<Character>();
            string filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\")) + @"data\characters.csv";
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            using (var reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] darabok = CSVParser.Split(line);

                    for (int i = 0; i < darabok.Length; i++)
                    {
                        if (darabok[i].Equals("NA") || darabok[i].Equals("N/A"))
                        {
                            darabok[i] = null;
                        }
                    }

                    int kicsi;
                    Character karakter = new Character();

                    karakter.Name = darabok[0];

                    if (darabok[1] is null)
                    {
                        karakter.Height = null;
                    }
                    else
                    {
                        Int32.TryParse(darabok[1], out kicsi);
                        karakter.Height = kicsi;
                    }
                    if (darabok[2] is null)
                    {
                        karakter.Mass = null;
                    }
                    else
                    {
                        if (darabok[2].Contains("."))
                        {
                            darabok[2] = darabok[2].Replace(".", ",");
                        }
                        Double.TryParse(darabok[2], out double szam);
                        karakter.Mass = szam;
                    }

                    karakter.Hair_color = darabok[3];
                    karakter.Skin_color = darabok[4];
                    karakter.Eye_color = darabok[5];
                    karakter.Birth_year = darabok[6];
                    karakter.Gender = darabok[7];
                    karakter.Homeworld = darabok[8];
                    karakter.Species = darabok[9];

                    karakterLista.Add(karakter);
                }
            }
            return karakterLista;
        }






    }
}

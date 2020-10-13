using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Elsobeadando
{
    class Planet
    {

        public string Name { get; set; }
        public int? Rotation_period { get; set; }
        public int? Orbital_period { get; set; }
        public int? Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public int? Surface_water { get; set; }
        public long? Population { get; set; }

        public Planet(string name, int rotation_period, int orbital_period, int diameter, string climate, string gravity, string terrain, int surface_water, long population)
        {
            this.Name = name;
            this.Rotation_period = rotation_period;
            this.Orbital_period = orbital_period;
            this.Diameter = diameter;
            this.Climate = climate;
            this.Gravity = gravity;
            this.Terrain = terrain;
            this.Surface_water = surface_water;
            this.Population = population;
        }

        public Planet()
        {
        }

        public override string ToString()
        {
            return "Name: " + Name + " | rotation_period: " + Rotation_period + " | orbital_period: " + Orbital_period + " | diameter: " + Diameter +
                " | climate: " + Climate + " | gravity: " + Gravity + " | terrain: " + Terrain + " | surface_water: " + Surface_water + " | population: " +
                Population + "\n";
        }



        public static List<Planet> beolvas ()
        {

            var bolygoLista = new List<Planet>();
            string filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\")) + @"data\planets.csv";
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            using (var reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {                    
                    string[] darabok = CSVParser.Split(line);
   
                    for(int i=0; i<darabok.Length; i++)
                    {
                        if(darabok[i].Equals("NA") || darabok[i].Equals("N/A"))
                        {   
                            darabok[i] = null;
                        }               
                    }
                    
                    int kicsi;
                    Planet bolygo = new Planet();

                    bolygo.Name = darabok[0];

                    if (darabok[1] is null)
                    {
                        
                        bolygo.Rotation_period = null;
                    }
                    else
                    {
                        Int32.TryParse(darabok[1], out kicsi);
                        bolygo.Rotation_period = kicsi;
                    }

                    if (darabok[2] is null)
                    {
                        bolygo.Orbital_period = null;
                    }
                    else
                    {
                        Int32.TryParse(darabok[2], out kicsi);
                        bolygo.Orbital_period = kicsi;
                    }

                    if (darabok[3] is null)
                    {
                        bolygo.Diameter = null;
                    }
                    else
                    {
                        Int32.TryParse(darabok[3], out kicsi);
                        bolygo.Diameter = kicsi;
                    }

                    bolygo.Climate = darabok[4];
                    bolygo.Gravity = darabok[5];
                    bolygo.Terrain = darabok[6];
                    
                    if (darabok[7] is null)
                    {
                        bolygo.Surface_water = null;
                    }
                    else
                    {
                        Int32.TryParse(darabok[7], out kicsi);
                        bolygo.Surface_water = kicsi;
                    }

                    if (darabok[8] is null)
                    {
                        bolygo.Population = null;
                    }
                    else
                    {
                        Int64.TryParse(darabok[8], out long nagy);
                        bolygo.Population = nagy;
                    }

                    bolygoLista.Add(bolygo);
                }
            }
            return bolygoLista;
        }






    }
}

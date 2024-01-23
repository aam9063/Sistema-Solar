using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using static Program.CelestialBodies;

public static class Program
{
    const int MAX_MOONS = 10;
    const int MAX_PLANETS = 14;
    private static object celestialBody;

    public static void Main()
    {
        CelestialBodies[] celestialBodies = new CelestialBodies[14];
        celestialBodies[0] = new Sun("Sol", 0F);
        celestialBodies[1] = new Planets("Mercurio", 0.39F);
        celestialBodies[2] = new Planets("Venus", 0.72F);
        celestialBodies[3] = new Planets("Tierra", 1.00F);
        celestialBodies[4] = new Planets("Marte", 1.52F);
        celestialBodies[5] = new Planets("Jupiter", 5.20F);
        celestialBodies[6] = new Planets("Saturno", 9.58F);
        celestialBodies[7] = new Planets("Urano", 19.18F);
        celestialBodies[8] = new Planets("Neptuno", 30.07F);
        celestialBodies[9] = new Moon("Luna");
        celestialBodies[10] = new Moon("Io");
        celestialBodies[11] = new Moon("Europa");
        celestialBodies[12] = new Moon("Gaminedes");
        celestialBodies[13] = new Moon("Calisto");

        ((Planets)celestialBodies[3]).SetMoons((Moon)celestialBodies[9]);
        ((Planets)celestialBodies[5]).SetMoons((Moon)celestialBodies[10]);
        ((Planets)celestialBodies[5]).SetMoons((Moon)celestialBodies[11]);
        ((Planets)celestialBodies[5]).SetMoons((Moon)celestialBodies[12]);
        ((Planets)celestialBodies[5]).SetMoons((Moon)celestialBodies[13]);
        ((Sun)celestialBodies[0]).AddPlanet((Planets)celestialBodies[1]);
        ((Sun)celestialBodies[0]).AddPlanet((Planets)celestialBodies[2]);
        ((Sun)celestialBodies[0]).AddPlanet((Planets)celestialBodies[3]);
        ((Sun)celestialBodies[0]).AddPlanet((Planets)celestialBodies[4]);
        ((Sun)celestialBodies[0]).AddPlanet((Planets)celestialBodies[5]);
        ((Sun)celestialBodies[0]).AddPlanet((Planets)celestialBodies[6]);
        ((Sun)celestialBodies[0]).AddPlanet((Planets)celestialBodies[7]);
        ((Sun)celestialBodies[0]).AddPlanet((Planets)celestialBodies[8]);

        int opcion = default;
        bool flag = true;
        do
        {
            Console.WriteLine(".......................");
            Console.WriteLine("       Menú");
            Console.WriteLine(".......................");
            Console.WriteLine("1. Show All Celestial Bodies");
            Console.WriteLine("2. Info Celestial Bodies");
            Console.WriteLine("3. Sort Celestial Bodies");
            Console.WriteLine("4. Send Sondas to Moons");
            Console.WriteLine("5. Send Explorer to Planets");
            Console.WriteLine("6. Extend info Celestial Bodies");
            Console.WriteLine("7. Sort Distace Celestial Bodies from planet");
            Console.WriteLine("8. Exit");

            opcion = int.Parse(Console.ReadLine());
            string respuesta = "";
            switch (opcion)
            {
                case 1:
                    foreach (var cuerposCeleste in celestialBodies)
                    {
                        cuerposCeleste.ComprobarTipoCuerpoEnseñarDatos(cuerposCeleste);
                    }
                    break;

                case 2:
                    Console.WriteLine("Name of Celestial Bodies");
                    respuesta = Console.ReadLine();
                    foreach (var cuerpoCeleste in celestialBodies)
                    {
                        if (respuesta.ToUpper() == cuerpoCeleste.GetName().ToUpper())
                        {
                            cuerpoCeleste.ComprobarTipoCuerpoEnseñarDatos(cuerpoCeleste);
                        }

                    }
                    break;

                case 3:
                    CelestialBodies[] celestialBodies1 = new CelestialBodies[celestialBodies.Length];
                    CelestialBodies[] copiedBodies1 = new CelestialBodies[celestialBodies.Length];

                    for (int i = 0; i < celestialBodies.Length; i++)
                    {
                        if (celestialBodies[i] is Sun)
                        {
                            copiedBodies1[i] = new Sun((Sun)celestialBodies[i]);
                        }
                        else if (celestialBodies[i] is Planets)
                        {
                            copiedBodies1[i] = new Planets((Planets)celestialBodies[i]);
                        }
                        else if (celestialBodies[i] is Moon)
                        {
                            copiedBodies1[i] = new Moon((Moon)celestialBodies[i]);
                        }
                    }
                    Array.Sort(copiedBodies1, new ComparadorPorNombre());
                    foreach (var celestialBody in copiedBodies1)
                    {
                        celestialBody.ComprobarTipoCuerpoEnseñarDatos(celestialBody);
                    }
                    break;

                case 4:
                    Console.WriteLine("Elige la luna a la que quieres mandar sondas");
                    respuesta = Console.ReadLine();
                    foreach (var celestialBody in celestialBodies)
                    {
                        if (respuesta.ToUpper() == celestialBody.GetName().ToUpper() && celestialBody is Moon)
                        {
                            Console.WriteLine("¿Cuántas deseas mandar?");
                            ((Moon)celestialBody).SendSondas(int.Parse(Console.ReadLine()));
                        }
                    }
                    break;

                case 5:
                    Console.WriteLine("Elige el planeta al que quieres mandar esxploradores");
                    respuesta = Console.ReadLine();
                    foreach (var celestialBody in celestialBodies)
                    {
                        if (respuesta.ToUpper() == celestialBody.GetName().ToUpper() && celestialBody is Planets)
                        {
                            Console.WriteLine("¿Cuántos deseas mandar?");
                            ((Planets)celestialBody).SendExploradores(int.Parse(Console.ReadLine()));
                        }
                    }
                    break;

                case 6:
                    Console.WriteLine("Name of Celestial Body");
                    respuesta = Console.ReadLine();
                    foreach (var cuerpoCeleste in celestialBodies)
                    {
                        if (respuesta.ToUpper() == cuerpoCeleste.GetName().ToUpper())
                        {
                            cuerpoCeleste.Show();
                        }
                    }
                    break;

                case 7:
                    Console.WriteLine("Name of Celestial Body");
                    respuesta = Console.ReadLine();

                    CelestialBodies[] copiedBodies = new CelestialBodies[celestialBodies.Length];

                    for (int i = 0; i < celestialBodies.Length; i++)
                    {
                        CelestialBodies originalBody = celestialBodies[i];

                        if (originalBody is Sun)
                        {
                            copiedBodies[i] = new Sun((Sun)originalBody);
                        }
                        else if (originalBody is Planets)
                        {
                            copiedBodies[i] = new Planets((Planets)originalBody);
                        }
                        else if (originalBody is Moon)
                        {
                            copiedBodies[i] = new Moon((Moon)originalBody);
                        }
                    }

                    foreach (var cuerpoCeleste in celestialBodies)
                    {
                        if (respuesta.ToUpper() == cuerpoCeleste.GetName().ToUpper())
                        {
                            foreach (var cuerpoAComparar in copiedBodies)
                            {
                                if (cuerpoAComparar is Planets || cuerpoAComparar is Sun)
                                {
                                    cuerpoAComparar.SetOrbital(cuerpoCeleste.DistanceOrbital(cuerpoAComparar));
                                }
                            }
                            Array.Sort(copiedBodies, new ComparadorPorDistancia());
                            foreach (var a in copiedBodies)
                            {
                                if (a is Planets || a is Sun)
                                {
                                    Console.WriteLine(a.GetName() + " " + a.GetOrbital());
                                }
                            }
                        }
                    }
                    break;

                case 8:
                    Console.WriteLine("Exit the program");
                    flag = false;
                    break;

                default:
                    break;

            }

        } while (flag == true);
    }

    public interface IInfo
    {
        public void Show();
    }

    public class ComparadorPorNombre : IComparer<CelestialBodies>
    {
        public int Compare(CelestialBodies? x, CelestialBodies? y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            return string.Compare(x.GetName(), y.GetName());
        }
    }

    public class ComparadorPorDistancia : IComparer<CelestialBodies>
    {
        public int Compare(CelestialBodies? x, CelestialBodies? y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            return x.GetOrbital().CompareTo(y.GetOrbital());
        }
    }


    public abstract class CelestialBodies : IInfo
    {
        private string name;
        private float orbitalDistance;

        public abstract void Show();

        public CelestialBodies(string name, float orbitalDistance)
        {
            this.name = name;
            this.orbitalDistance = orbitalDistance;
        }

        public CelestialBodies(string name) : this(name, 0)
        {

        }

        public float DistanceCelestialBodies(CelestialBodies celestialBodies)
        {
            return Math.Abs(this.orbitalDistance - orbitalDistance);
        }

        public abstract void AddCelestialBodies(CelestialBodies celestialBodies);

        public override string ToString()
        {
            return this.name;
        }

        public string GetName()
        {
            return this.name;
        }

        public float GetOrbital()
        {
            return this.orbitalDistance;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetOrbital(float orbitalDistance)
        {
            this.orbitalDistance = orbitalDistance;
        }

        public void ComprobarTipoCuerpoEnseñarDatos(CelestialBodies celestialBodies)
        {
            if (celestialBodies is Sun)
            {
                ((Sun)celestialBodies).Show();
            }
            else if (celestialBodies is Planets)
            {
                ((Planets)celestialBodies).Show();
            }
            else if (celestialBodies is Moon)
            {
                ((Moon)celestialBodies).Show();
            }
        }

        public float DistanceOrbital(CelestialBodies cuerpoAComparar)
        {
            if (cuerpoAComparar == null)
            {
                return 0;
            }
            return Math.Abs(this.GetOrbital() - cuerpoAComparar.GetOrbital());
        }


        public class Moon : CelestialBodies
        {
            private int numSondas;

            public Moon(string name) : base(name)
            {
                this.numSondas = 0;
            }

            public Moon(Moon moon) : base(moon.GetName())
            {
                this.numSondas = moon.numSondas;

            }

            public void SendSondas(int Sondas)
            {
                this.numSondas += numSondas;
            }

            public int GetNumSondas()
            {
                return numSondas;
            }

            public void SetNumSondas(int numSondas)
            {
                this.numSondas = numSondas;
            }

            public override void AddCelestialBodies(CelestialBodies celestialBodies)
            {

            }

            public override void Show()
            {
                Console.WriteLine("Moon never have another object");
            }

            public override string ToString()
            {
                return $"Moon: (GetName()) Sondas: (numSondas)";
            }

        }

        public class Planets : CelestialBodies
        {
            private int numMoons;
            private Moon[] moons = new Moon[MAX_MOONS];
            private int numExplorers;

            public Planets(string name, float orbitalDistance) : base(name, orbitalDistance)
            {

            }

            public Planets(Planets planets) : base(planets.GetName(), planets.GetOrbital())
            {
                this.numMoons = planets.GetMoons();
                this.numExplorers = planets.GetNumExplorers();
                for (int i = 0; i < numMoons; i++)
                {
                    this.moons[i] = new Moon(planets.moons[i]);
                }
            }


            public int GetMoons()
            {
                return numMoons;
            }

            public Moon[] GetArrayMoons()
            {
                return moons;
            }

            public int GetNumExplorers()
            {
                return numExplorers;
            }

            public void SetMoons(Moon moons)
            {
                this.moons[numMoons] = moons;
                numMoons++;
            }

            public void SetNumExplorers(int numExplorers)
            {
                this.numExplorers = numExplorers;
            }

            public void SendExploradores(int numExplorers)
            {
                this.numExplorers += numExplorers;
            }

            public override void AddCelestialBodies(CelestialBodies celestialBodies)
            {

            }

            public override string ToString()
            {
                return $"Planet: (GetName()) Distance: (GetOrbital()) Moons: (numMoons) Explorers: (numExplorers)";
            }

            public override void Show()
            {
                if (numMoons == 0)
                {
                    Console.WriteLine("Any moons");
                }
                else
                {
                    Console.WriteLine("Have" + numMoons + "moons");
                    foreach (var moon in moons)
                    {
                        if (!(moon is null))
                            Console.WriteLine(" " + moon.GetName());
                    }
                }
            }
        }

        public class Sun : CelestialBodies
        {
            private int numPlanets;
            private Planets[] planets = new Planets[MAX_PLANETS];

            public Sun(string name, float orbitalDistance) : base(name, orbitalDistance)
            {
                this.numPlanets = 0;
            }

            public Sun(Sun sun) : base(sun.GetName(), sun.GetOrbital())
            {
                this.numPlanets = sun.GetNumPlanets();

                for (int i = 0; i < numPlanets; i++)
                {
                    this.planets[i] = new Planets(sun.planets[i]);
                }
            }

            public void AddPlanet(Planets planet)
            {
                this.planets[numPlanets] = planet;
                numPlanets++;
            }

            public int GetNumPlanets()
            {
                return this.numPlanets;
            }

            public override void AddCelestialBodies(CelestialBodies body)
            {
                if (body is Planets)
                {
                    AddPlanet((Planets)body);
                }
            }

            public override void Show()
            {
                if (numPlanets == 0)
                {
                    Console.WriteLine("Any planets");
                }
                else
                {
                    Console.WriteLine("Have" + numPlanets + "planets");
                    foreach (var planet in planets)
                    {
                        if (!(planet is null))
                            Console.WriteLine(" " + planet.GetName());
                    }
                }
            }

            public override string ToString()
            {
                return $"Sun: (GetName()) Distance: (GetOrbital()) Planets: (numPlanets)";
            }
        }
    }

}

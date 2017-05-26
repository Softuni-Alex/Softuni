namespace MassDefect.ImportJson
{
    using Data;
    using DTO;
    using Models.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ImportJsonApp
    {
        private const string SolarSystemsPath = "../../../datasets/solar-systems.json";
        private const string StarsPath = "../../../datasets/stars.json";
        private const string PlanetsPath = "../../../datasets/planets.json";
        private const string PersonsPath = "../../../datasets/persons.json";
        private const string AnomaliesPath = "../../../datasets/anomalies.json";
        private const string AnomalyVictimsPath = "../../../datasets/anomaly-victims.json";

        public static void Main()
        {
            ImportSolarSystems();

            ImportStars();

            ImportPlanets();

            ImportPersons();

            ImportAnomalies();

            ImportAnomalyVictims();
        }

        private static void ImportAnomalyVictims()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(AnomalyVictimsPath);
            var anomalyVictims = JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimsDTO>>(json);

            foreach (var anomalyVictim in anomalyVictims)
            {
                if (anomalyVictim.Id == null || anomalyVictim.Person == null)
                {
                    RaiseError();
                    continue;
                }

                var anomalyEntity = GetAnomalyById(anomalyVictim.Id, context);

                var personEntity = GetPersonByName(anomalyVictim.Person, context);

                if (anomalyEntity == null || personEntity == null)
                {
                    RaiseError();
                    continue;
                }

                anomalyEntity.Person.Add(personEntity);
            }
            context.SaveChanges();
        }

        private static void ImportAnomalies()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(AnomaliesPath);
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomaliesDTO>>(json);

            foreach (var anomaly in anomalies)
            {
                if (anomaly.OriginPlanet == null || anomaly.TeleportPlanet == null)
                {
                    RaiseError();
                    continue;
                }

                var anomalyEntity = new Anomalies
                {
                    OriginPlanet = GetOriginPlanet(anomaly.OriginPlanet, context),
                    TeleportPlanet = GetTeleportPlanet(anomaly.TeleportPlanet, context)
                };

                if (anomalyEntity.TeleportPlanet == null || anomalyEntity.OriginPlanet == null)
                {
                    RaiseError();
                    continue;
                }

                context.Anomalies.Add(anomalyEntity);

                Console.WriteLine($"Successfully imported anomaly.");
            }
            context.SaveChanges();
        }

        private static void ImportPersons()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PersonsPath);
            var persons = JsonConvert.DeserializeObject<IEnumerable<PersonsDTO>>(json);

            foreach (var person in persons)
            {
                if (person.Name == null || person.HomePlanet == null)
                {
                    RaiseError();
                    continue;
                }

                var personEntity = new Person
                {
                    Name = person.Name,
                    HomePlanet = GetPlanetByName(person.HomePlanet, context),
                };

                if (personEntity.Name == null || personEntity.HomePlanet == null)
                {
                    RaiseError();
                    continue;
                }

                context.Persons.Add(personEntity);
                Console.WriteLine($"Successfully imported Person {personEntity.Name}.");
            }
            context.SaveChanges();
        }

        private static void ImportPlanets()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PlanetsPath);
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetsDTO>>(json);

            foreach (var planet in planets)
            {
                if (planet.Name == null || planet.SolarSystem == null || planet.Sun == null)
                {
                    RaiseError();
                    continue;
                }

                var planetEntity = new Planets
                {
                    Name = planet.Name,
                    SolarSystem = GetSolarSystemByName(planet.SolarSystem, context),
                    Sun = GetSunByName(planet.Sun, context)
                };

                if (planetEntity.Name == null || planetEntity.Sun == null || planetEntity.SolarSystem == null)
                {
                    RaiseError();
                    continue;
                }

                context.Planets.Add(planetEntity);

                Console.WriteLine($"Successfully imported Planet {planetEntity.Name}.");
            }
            context.SaveChanges();
        }

        private static void ImportStars()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(StarsPath);
            var stars = JsonConvert.DeserializeObject<IEnumerable<StarDTO>>(json);

            foreach (var star in stars)
            {
                if (star.Name == null || star.SolarSystem == null)
                {
                    RaiseError();
                    continue;
                }

                var starEntity = new Stars
                {
                    Name = star.Name,
                    SolarSystem = GetSolarSystemByName(star.SolarSystem, context)
                };

                if (starEntity.SolarSystem == null)
                {
                    RaiseError();
                    continue;
                }

                context.Stars.Add(starEntity);
                Console.WriteLine($"Successfully imported Star {starEntity.Name}.");
            }
            context.SaveChanges();
        }

        private static void ImportSolarSystems()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(SolarSystemsPath);
            var solarSystems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDTO>>(json);

            foreach (var solarSystem in solarSystems)
            {
                if (solarSystem.Name == null)
                {
                    RaiseError();
                    continue;
                }

                var solarSystemEntity = new SolarSystems
                {
                    Name = solarSystem.Name
                };

                context.SolarSystems.Add(solarSystemEntity);
                Console.WriteLine($"Successfully imported Solar System {solarSystemEntity.Name}.");
            }
            context.SaveChanges();
        }

        //Getting data from db
        private static SolarSystems GetSolarSystemByName(string solarSystem, MassDefectContext context)
        {
            return context.SolarSystems.FirstOrDefault(s => s.Name == solarSystem);
        }

        private static Stars GetSunByName(string sun, MassDefectContext context)
        {
            return context.Stars.FirstOrDefault(s => s.Name == sun);
        }

        private static Planets GetTeleportPlanet(string teleportPlanet, MassDefectContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == teleportPlanet);
        }

        private static Planets GetOriginPlanet(string originPlanet, MassDefectContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == originPlanet);
        }

        private static Planets GetPlanetByName(string homePlanet, MassDefectContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == homePlanet);
        }

        private static Anomalies GetAnomalyById(int? id, MassDefectContext context)
        {
            return context.Anomalies.FirstOrDefault(a => a.Id == id);
        }

        private static Person GetPersonByName(string person, MassDefectContext context)
        {
            return context.Persons.FirstOrDefault(p => p.Name == person);
        }

        private static void RaiseError()
        {
            Console.WriteLine("Error: Invalid data.");
        }
    }
}
namespace MassDefect.ExportJson
{
    using Data;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    public class ExportJsonApp
    {
        public static void Main()
        {
            var context = new MassDefectContext();

            ExportPlanetsWhichAreNotAnomalyOrigins(context);

            ExportPlanetsWhichHaveNotBeenVictims(context);

            ExportTopAnomaly(context);
        }

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            var exportTopAnomaly = context.Anomalies
                .OrderByDescending(p => p.Person.Count)
                .Select(a => new
                {
                    id = a.Id,
                    originPlanet = new
                    {
                        name = a.OriginPlanet
                    },
                    teleportPlanet = new
                    {
                        name = a.TeleportPlanet
                    },
                    victimsCount = a.Person.Count()
                }
                )
                .Take(1);

            var topAnamoly = JsonConvert.SerializeObject(exportTopAnomaly, Formatting.Indented);
            File.WriteAllText("../../topAnomaly.json", topAnamoly);
        }

        private static void ExportPlanetsWhichHaveNotBeenVictims(MassDefectContext context)
        {
            var exportPlanets = context.Persons.Where(persons => !persons.Anomaly.Any())
                .Select(person => new
                {
                    name = person.Name,
                    homePlanet = new
                    {
                        name = person.Name
                    }
                });

            var personAsJson = JsonConvert.SerializeObject(exportPlanets, Formatting.Indented);
            File.WriteAllText("../../personsNotBeenVictims.json", personAsJson);
        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins(MassDefectContext context)
        {
            var exportedPlanets = context.Planets
                .Where(planet => !planet.OriginAnomalies.Any())
                .Select(planet => new
                {
                    name = planet.Name
                });

            var planetAsJson = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
            File.WriteAllText("../../planetsNotAnomalyOrigins.json", planetAsJson);
        }
    }
}
namespace MassDefect.ImportXML
{
    using Data;
    using Models.Models;
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class ImportXMLApp
    {
        private const string NewAnomaliesPath = "../../../datasets/new-anomalies.xml";

        public static void Main()
        {
            var xml = XDocument.Load(NewAnomaliesPath);
            var anomalies = xml.XPathSelectElements("anomalies/anomaly");

            var context = new MassDefectContext();

            foreach (var anomaly in anomalies)
            {
                ImportAnomalyAndVictims(anomaly, context);
                Console.WriteLine("Successfully imported anomaly.");
            }
        }

        private static void ImportAnomalyAndVictims(XElement anomalyNode, MassDefectContext context)
        {
            var originPlanetName = anomalyNode.Attribute("origin-planet");
            var teleportPlanetName = anomalyNode.Attribute("teleport-planet");

            if (originPlanetName == null || teleportPlanetName == null)
            {
                RaiseError();
                return;
            }

            //might check the .values tho
            var anomalyEntity = new Anomalies
            {
                OriginPlanet = GetPlanetByName(originPlanetName.Value, context),
                TeleportPlanet = GetPlanetByName(teleportPlanetName.Value, context)
            };

            if (anomalyEntity.OriginPlanet == null || anomalyEntity.TeleportPlanet == null)
            {
                RaiseError();
            }

            var victims = anomalyNode.XPathSelectElements("victims/victim");

            foreach (var victim in victims)
            {
                ImportVictim(victim, context, anomalyEntity);
            }

            context.SaveChanges();
        }

        private static void ImportVictim(XElement victimNode, MassDefectContext context, Anomalies anomaly)
        {
            var name = victimNode.Attribute("name");

            if (name == null)
            {
                RaiseError();
            }

            var perssonEntity = GetPersonName(name.Value, context);

            if (perssonEntity.Name == null)
            {
                RaiseError();
            }

            anomaly.Person.Add(perssonEntity);
        }

        private static Person GetPersonName(string value, MassDefectContext context)
        {
            return context.Persons.FirstOrDefault(p => p.Name == value);
        }

        private static Planets GetPlanetByName(string value, MassDefectContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == value);
        }

        private static void RaiseError()
        {
            Console.WriteLine("Error: Invalid data.");
        }
    }
}
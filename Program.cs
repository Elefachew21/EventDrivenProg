using System;
using System.Collections.Generic;

namespace reIndiv_ass_CSharp
{
    using System;
    using System.Collections.Generic;


        abstract class EmergencyUnit
        {
            public string Name { get; }
            public int Speed { get; }

            protected EmergencyUnit(string name, int speed)
            {
                Name = name;
                Speed = speed;
            }

            public abstract bool CanHandle(string incidentType);
            public abstract void RespondToIncident(Incident incident, int responseTime);
        }

        class Police : EmergencyUnit
        {
            public Police(string name, int speed) : base(name, speed) { }
            public override bool CanHandle(string incidentType) => incidentType == "Crime";
            public override void RespondToIncident(Incident incident, int responseTime)
            {
                Console.WriteLine($"{Name} is responding to crime at {incident.Location} in {responseTime} mins.");
            }
        }

        class Firefighter : EmergencyUnit
        {
            public Firefighter(string name, int speed) : base(name, speed) { }
            public override bool CanHandle(string incidentType) => incidentType == "Fire";
            public override void RespondToIncident(Incident incident, int responseTime)
            {
                Console.WriteLine($"{Name} is extinguishing fire at {incident.Location} in {responseTime} mins.");
            }
        }

        class Ambulance : EmergencyUnit
        {
            public Ambulance(string name, int speed) : base(name, speed) { }
            public override bool CanHandle(string incidentType) => incidentType == "Medical";
            public override void RespondToIncident(Incident incident, int responseTime)
            {
                Console.WriteLine($"{Name} is treating patients at {incident.Location} in {responseTime} mins.");
            }
        }

        class RescueHelicopter : EmergencyUnit
        {
            public RescueHelicopter(string name, int speed) : base(name, speed) { }
            public override bool CanHandle(string incidentType) => incidentType == "Rescue";
            public override void RespondToIncident(Incident incident, int responseTime)
            {
                Console.WriteLine($"{Name} is conducting rescue at {incident.Location} in {responseTime} mins.");
            }
        }

        class BombSquad : EmergencyUnit
        {
            public BombSquad(string name, int speed) : base(name, speed) { }
            public override bool CanHandle(string incidentType) => incidentType == "Bomb Threat";
            public override void RespondToIncident(Incident incident, int responseTime)
            {
                Console.WriteLine($"{Name} is defusing bomb at {incident.Location} in {responseTime} mins.");
            }
        }

        class Incident
        {
            public string Type { get; }
            public string Location { get; }
            public int DifficultyLevel { get; }

            public Incident(string type, string location, int difficultyLevel)
            {
                Type = type;
                Location = location;
                DifficultyLevel = difficultyLevel;
            }
        }

        class Program
        {
            static void Main()
            {
                List<EmergencyUnit> units = new List<EmergencyUnit>
            {
                new Police("Police Unit 1", 60),
                new Firefighter("Firefighter Unit 1", 50),
                new Ambulance("Ambulance Unit 1", 70),
                new RescueHelicopter("Rescue Heli 1", 100),
                new BombSquad("Bomb Squad 1", 40)
            };

                string[] incidentTypes = { "Fire", "Crime", "Medical", "Rescue", "Bomb Threat" };
                string[] locations = { "City Hall", "Suburb", "Highway", "Mall", "Airport", "Bridge", "School" };

                Random random = new Random();
                int score = 0;

                Console.WriteLine("Emergency Response Simulation");
                Console.WriteLine("Choose mode: [1] Auto Unit Dispatch  [2] Manual Unit Selection");
                string modeInput = Console.ReadLine();
                bool isManual = modeInput == "2";

                for (int round = 1; round <= 5; round++)
                {
                    Console.WriteLine($"\n--- Turn {round} ---");

                    string incidentType = incidentTypes[random.Next(incidentTypes.Length)];
                    string location = locations[random.Next(locations.Length)];
                    int difficulty = random.Next(1, 4);

                    Incident incident = new Incident(incidentType, location, difficulty);

                    Console.WriteLine($"Incident: {incident.Type} at {incident.Location} (Difficulty {incident.DifficultyLevel})");

                    EmergencyUnit selectedUnit = null;

                    if (isManual)
                    {
                        Console.WriteLine("Available Units:");
                        for (int i = 0; i < units.Count; i++)
                        {
                            Console.WriteLine($"[{i}] {units[i].Name} (Handles: {units[i].GetType().Name.Replace("Unit", "")})");
                        }

                        Console.Write("Select a unit index: ");
                        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice < units.Count)
                        {
                            selectedUnit = units[choice];
                            if (!selectedUnit.CanHandle(incident.Type))
                            {
                                Console.WriteLine("Wrong unit selected. -5 points.");
                                score -= 5;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        foreach (var unit in units)
                        {
                            if (unit.CanHandle(incident.Type))
                            {
                                selectedUnit = unit;
                                break;
                            }
                        }
                    }

                    if (selectedUnit != null)
                    {
                        int responseTime = incident.DifficultyLevel * 10 / selectedUnit.Speed;
                        selectedUnit.RespondToIncident(incident, responseTime);

                        int earned = 10 + (3 - incident.DifficultyLevel) * 2;
                        Console.WriteLine($"+{earned} points");
                        score += earned;
                    }
                    else
                    {
                        Console.WriteLine("No available unit to handle this incident.");
                        Console.WriteLine("-5 points");
                        score -= 5;
                    }

                    Console.WriteLine($"Current Score: {score}");
                }

                Console.WriteLine("\nSimulation Over.");
                Console.WriteLine($"Final Score: {score}");
            }
        }

}

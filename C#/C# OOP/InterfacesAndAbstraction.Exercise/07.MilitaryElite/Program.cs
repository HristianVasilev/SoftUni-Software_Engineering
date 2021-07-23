using _07.MilitaryElite.Models.Classes;
using _07.MilitaryElite.Models.Enums;
using _07.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MilitaryElite
{
    class Program
    {
        private static ICollection<Soldier> soldiers;

        static void Main(string[] args)
        {
            //ISoldier priv = new Private(10, "Min4o", "Min4ev", 2100m);
            //Console.WriteLine(priv.ToString());

            //ISoldier spy = new Spy(10, "Min4o", "Min4ev", 5555);
            //Console.WriteLine(spy.ToString());

            //IPrivate[] collectionOfPrivates = new IPrivate[]
            //{
            //    new Private(40,"Diman","Dimanov", 1000m),
            //    new Private(50,"Mitko","Minkov", 1000m),
            //};
            //ISoldier lieutenant = new LieutenantGeneral(400, "Pen4o", "Kazakov", 1800m, collectionOfPrivates);
            //Console.WriteLine(lieutenant.ToString());


            //IRepair[] collectionOfRepairs = new IRepair[]
            //{
            //    new Repair("Lampa", 3),
            //    new Repair("Dush", 2)
            //};
            //ISoldier engineer = new Engineer(854, "Injener", "Mizeren", 500m, Corps.Airforces, collectionOfRepairs);
            //Console.WriteLine(engineer.ToString());

            //IMission[] collectionOfMissions = new IMission[]
            //{
            //    new Mission("putkataMarinkina", State.inProgress),
            //    new Mission("Deebaseloto", State.Finished),
            //    new Mission("Putiomarinkin", State.inProgress)
            //};
            //ISoldier commando = new Commando(741, "Commandir", "Comandirov", 3200, Corps.Marines, collectionOfMissions);
            //Console.WriteLine(commando.ToString());

            soldiers = new List<Soldier>();

            ReadSoldiers();
            string result = GetResult();
            Console.WriteLine(result);
        }

        private static string GetResult()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var soldier in soldiers)
            {
                sb.AppendLine(soldier.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private static void ReadSoldiers()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];
                tokens = tokens.Skip(1).ToArray();

                Soldier soldier;

                switch (type)
                {
                    case "Private":
                        soldier = CreatePrivate(tokens);
                        break;
                    case "LieutenantGeneral":
                        soldier = CreateLieutenantGeneral(tokens);
                        break;
                    case "Engineer":
                        soldier = CreateEngineer(tokens);
                        break;
                    case "Commando":
                        soldier = CreateCommando(tokens);
                        break;
                    case "Spy":
                        soldier = CreateSpy(tokens);
                        break;
                    default:
                        throw new InvalidOperationException($"Non-existent {type} soldier!");
                }

                soldiers.Add(soldier);
            }
        }



        // Create methods

        private static Soldier CreatePrivate(string[] tokens)
        {
            int id = int.Parse(tokens[0]);
            string firstName = tokens[1];
            string lastName = tokens[2];
            decimal salary = decimal.Parse(tokens[3]);

            return new Private(id, firstName, lastName, salary);
        }

        private static Soldier CreateLieutenantGeneral(string[] tokens)
        {
            int id = int.Parse(tokens[0]);
            string firstName = tokens[1];
            string lastName = tokens[2];
            decimal salary = decimal.Parse(tokens[3]);

            int[] privateIds = tokens.Skip(4).Select(int.Parse).ToArray();

            ICollection<IPrivate> privates = GetPrivates(privateIds);

            return new LieutenantGeneral(id, firstName, lastName, salary, privates);
        }

        private static Soldier CreateEngineer(string[] tokens)
        {
            int id = int.Parse(tokens[0]);
            string firstName = tokens[1];
            string lastName = tokens[2];
            decimal salary = decimal.Parse(tokens[3]);
            Corps corps = SetEnum<Corps>(tokens[4]);

            string[] repairInfo = tokens.Skip(5).ToArray();
            ICollection<IRepair> repairs = GetRepairs(repairInfo);

            return new Engineer(id, firstName, lastName, salary, corps, repairs);
        }

        private static Soldier CreateCommando(string[] tokens)
        {
            int id = int.Parse(tokens[0]);
            string firstName = tokens[1];
            string lastName = tokens[2];
            decimal salary = decimal.Parse(tokens[3]);
            Corps corps = SetEnum<Corps>(tokens[4]);

            string[] missionInfo = tokens.Skip(5).ToArray();
            ICollection<IMission> missions = GetMissions(missionInfo);

            return new Commando(id, firstName, lastName, salary, corps, missions);
        }

        private static Soldier CreateSpy(string[] tokens)
        {
            int id = int.Parse(tokens[0]);
            string firstName = tokens[1];
            string lastName = tokens[2];
            int codeNumber = int.Parse(tokens[3]);

            return new Spy(id, firstName, lastName, codeNumber);
        }



        // Help methods
        private static ICollection<IPrivate> GetPrivates(int[] privateIds)
        {
            ICollection<IPrivate> privates = new List<IPrivate>();

            foreach (var privateId in privateIds)
            {
                Private @private = soldiers.FirstOrDefault(x => x.Id.Equals(privateId)) as Private;

                if (@private is null)
                {
                    continue;
                }

                privates.Add(@private);
            }

            return privates;
        }

        private static ICollection<IRepair> GetRepairs(string[] repairInfo)
        {
            if (repairInfo.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid repairment arguments!");
            }

            ICollection<IRepair> repairs = new List<IRepair>();

            for (int i = 0; i < repairInfo.Length - 1; i += 2)
            {
                string partName = repairInfo[i];
                int hoursWorked = int.Parse(repairInfo[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);
            }

            return repairs;
        }

        private static ICollection<IMission> GetMissions(string[] missionInfo)
        {
            if (missionInfo.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid missions arguments!");
            }

            ICollection<IMission> missions = new List<IMission>();

            for (int i = 0; i < missionInfo.Length - 1; i += 2)
            {
                string codeName = missionInfo[i];
                State state;

                try
                {
                    state = SetEnum<State>(missionInfo[i + 1]);
                }
                catch (ArgumentException)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                missions.Add(mission);
            }

            return missions;
        }


        private static TEnum SetEnum<TEnum>(string element) where TEnum : struct
        {
            TEnum result;
            bool successfullyParsed = Enum.TryParse<TEnum>(element, out result);

            if (!successfullyParsed)
            {
                throw new ArgumentException("Invalid parse operation!");
            }

            return result;
        }

    }
}

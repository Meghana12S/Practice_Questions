using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class Artifact
    {
        public int ArtifactId { get; set; }
        public string ArtifactName { get; set; }
        public string MuseumSection { get; set; }
        public int ArtifactAge { get; set; }
        public string PreservationCondition { get; set; }

        public class SmartMuseum
        {
            public static List<Artifact> ArtifactList = new List<Artifact>();
            public void AddArtifact(int id, string name, string section, int age, string condition)
            {
                Artifact artifact = new Artifact();
                artifact.ArtifactId = id;
                artifact.ArtifactName = name;
                artifact.MuseumSection = section;
                artifact.ArtifactAge = age;
                artifact.PreservationCondition = condition;
                ArtifactList.Add(artifact);

            }
            public List<Artifact> GetArtifactsBySection(string section)
            {
                List<Artifact> result = new List<Artifact>();
                foreach (Artifact a in ArtifactList)//Artifact datatype
                {
                    if (a.MuseumSection == section)// a Variable Name
                    {
                        result.Add(a);
                    }

                }
                return result;

            }
            public string CalculatePreservationClass(int id)
            {
                Artifact found = null;
                foreach (Artifact a in ArtifactList)
                {
                    if (a.ArtifactId == id)
                    {
                        found = a;
                        break;
                    }
                }
                if (found == null)
                {
                    return "Artifact not found";
                }
                string message;
                if (found.ArtifactAge > 100 && string.Equals(found.PreservationCondition, "Poor", StringComparison.OrdinalIgnoreCase))
                {
                    message = "Critical Priority";
                }
                else if (found.ArtifactAge > 500)
                {
                    message = "High Priority";
                }
                else if (found.ArtifactAge > 100)
                {
                    message = "Moderate Priority";
                }
                else
                {
                    message = "Low Priority";
                }
                return "Classification:" + message + "," + "Age:" + found.ArtifactAge + "years" +","+ "Condition:" + found.PreservationCondition;


            }
            public static void Main(string[] args)
            {
                SmartMuseum s = new SmartMuseum();
                while (true)
                {
                    Console.WriteLine("1. Add Artifact");
                    Console.WriteLine("2. List by Museum Section");
                    Console.WriteLine("3. Calculate Preservation Class");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("Enter your choice");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Artifact Id:");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Artifact Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Museum Section:");
                            string section = Console.ReadLine();
                            Console.WriteLine("Enter Artifact Age:");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Preservation Condition");
                            string condition = Console.ReadLine();
                            s.AddArtifact(id, name, section, age, condition);
                            Console.WriteLine("Artifact recond added successfully");
                            break;

                        case 2:
                            Console.WriteLine("Enter Museum Section");
                            string section1 = Console.ReadLine();
                            List<Artifact> list = s.GetArtifactsBySection(section1);
                            if (list.Count == 0)
                            {
                                Console.WriteLine("No artifacts found in section " + section1);
                            }
                            else
                            {
                                Console.WriteLine("ID Name Section Age Condition");
                                foreach (Artifact a in list)
                                {
                                    Console.WriteLine(a.ArtifactId + " " + a.ArtifactName + " " + a.MuseumSection + " " + a.ArtifactAge + " " + a.PreservationCondition);

                                }
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Artifact Id:");
                            int id1 = int.Parse(Console.ReadLine());
                            Console.WriteLine(s.CalculatePreservationClass(id1));
                            break;
                        case 4:
                            Console.WriteLine("Existing system.Goodbye!");
                            break;

                    }
                }


            }
        }
    }
}

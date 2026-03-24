using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
namespace Gym
{
    class GymMember
    {
        public GymMember()
        {
        }
        public int id { get; set; }
        public string name { get; set; }
        public int visitcounter { get; set; }

        public static int membercounter = 0; // рахувати мемберів

        // конструктори 
        public GymMember(int id, string name, int visitcounter) // конструктор для visitcounter =! 0
        {
            this.id = id;
            this.name = name;
            this.visitcounter = visitcounter;
            membercounter++;
        }
        public GymMember(int id, string name)   // конструктор для visitcounter = 0
        {
            this.id = id;
            this.name = name;
            this.visitcounter = 0;
            membercounter++;
        }
        // метод додавання відвідування та метод перевірки, чи досягнуто певної кількості відвідувань.
        public void AddVisit() // для підрахунку к-сті відвідувачів
        {
            visitcounter++;
        }
        public bool Reachedvisit(int cnst) // cnst - потрібна кількість відвідувачів
        // логіка: досягнення певної кількості відвідувань
        {
            if (visitcounter >= cnst)
            {
                return true;
            }
            else 
                return false;
        }
        public int VisitCount // створила таку функцію, де я можу читати і брати значення, але не можу змінювати

        {
            get {  return visitcounter; }
        }
        public static int GetMemberCount()
        {
            return membercounter;
        }
        // overrid для того щоб перевизначити стандартний метод 
        // ToString() і зробити власний формат виводу даних про користувача.
        public override string ToString()
        {
            return $"ID: {id}, NAME: {name}, VISITS:{visitcounter}";
        }
        
        public void SaveJson(string path)
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(path, json);
        }
        public static GymMember LoadFromJson(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<GymMember>(json);
        }
    }
    class Program
    {
        static void Main()
        {
            GymMember member1 = new GymMember(4983, "Karina", 8);
            GymMember member2 = new GymMember(4912, "Oleh");
            GymMember member3 = new GymMember(1840, "Anna", 4);
            GymMember member4 = new GymMember(1250, "Alla", 1);
            GymMember member5 = new GymMember(9244, "Yaroslav");

            member2.AddVisit();
            member2.AddVisit();
            member5.AddVisit();

            Console.WriteLine(member1.ToString());
            Console.WriteLine(member2.ToString());
            Console.WriteLine(member3.ToString());
            Console.WriteLine(member4.ToString());
            Console.WriteLine(member5.ToString());

            Console.WriteLine($"Чи досягнув 4 клієнт 2х відвідувань? - {member4.Reachedvisit(2)}");
            Console.WriteLine($"Чи досягнув 2 клієнт 2х відвідувань? - {member2.Reachedvisit(2)}");

            List<GymMember> members = new List<GymMember>()
            {
                member1,
                member2,
                member3,
                member4,
                member5
            };
            string path = @"C:\Users\KarinaL\Desktop\members.json";

            string json = JsonSerializer.Serialize(members, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
            string jsonFromFile = File.ReadAllText(path);
            List<GymMember> loadedMembers = JsonSerializer.Deserialize<List<GymMember>>(jsonFromFile);

            Console.WriteLine("З файлу:");

            foreach (var m in loadedMembers)
            {
                Console.WriteLine(m);
            }
        }
        
    }
}

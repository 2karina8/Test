using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gym
{
    class GymMember
    {
        private readonly int id; // айдішка
        private string name; // ім'я
        private int visitcounter; // к-сть відвідувань

        private static int membercounter = 0; // рахувати мемберів

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
        public bool Reachedvisit(int cnst) // cnst - consta - потрібна кількість відвідувачів
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
        public override string ToString()
        {
            return $"ID: {id}, NAME: {name}, VISITS:{visitcounter}";
        }
    }
    class Program
    {
        static void Main()
        {
            GymMember member1 = new GymMember(0983, "Karina", 8);
            GymMember member2 = new GymMember(4912, "Oleh");
            GymMember member3 = new GymMember(1840, "Anna", 4);
            GymMember member4 = new GymMember(0050, "Alla", 1);
            GymMember member5 = new GymMember(1234, "Yaroslav");

            member2.AddVisit();
            member2.AddVisit();
            member5.AddVisit();

            System.Console.WriteLine(member1.ToString());
            System.Console.WriteLine(member2.ToString());
            System.Console.WriteLine(member3.ToString());
            System.Console.WriteLine(member4.ToString());
            System.Console.WriteLine(member5.ToString());

            System.Console.WriteLine(member2.Reachedvisit(2));

            System.Console.WriteLine(GymMember.GetMemberCount());
        }
        
    }
}

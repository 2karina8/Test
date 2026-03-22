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
        public void Visit() // для підрахунку к-сті відвідувачів
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




    }
}

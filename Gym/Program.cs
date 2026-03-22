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
        private readonly int id;
        private string name;
        private int visitcounter;

        private static int membercounter = 0;
        public GymMember(int id, string name, int visitcounter)
        {
            this.id = id;
            this.name = name;
            this.visitcounter = visitcounter;
            membercounter++;
        }
        public GymMember(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.visitcounter = 0;
            membercounter++;
        }
    }
}

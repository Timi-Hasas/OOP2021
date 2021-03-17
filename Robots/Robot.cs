using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    abstract class Robot : Being
    {   
        private bool isActive;
        private int target;
        public Robot(int health, int attack, int speed, int defense, bool isActive)
            : base(health, attack, speed, defense)
        {
            this.isActive = isActive;
        }
        public bool IsActive { get => isActive; set => isActive = value; }
        public int Target { get => target; set => target = value; }
        public Being AcquireTarget(Planet planet)
        {
            Random rnd = new Random();
            Being target;
            bool stop = false;
            do
            {
                Target = rnd.Next(planet.Targets.Count);
                target = planet.Targets.ElementAt(Target).Key;

                if(!stop)
                {
                    foreach(int value in planet.Targets.Values)
                    {
                        if (value != 0)
                        {
                            stop = false;                           
                            break;
                           
                        }
                        stop = true;
                    }
                }

            } while (planet.Targets[target] <= 0 && !stop);
            return target;
        }
        public void AttackTarget(Planet planet, int damage, Being target)
        {
            target.Health = target.Health - damage;
            if (target.Health <= 0)
            {
                planet.Targets[target]--;
                planet.Population--;
                target.Health = target.InitialHealth;
            }
        }
        
    }
    class Destroyer : Robot
    {
        private Laser laser;
        private Chainsaw chainsaw ;
        public Destroyer(int health, int attack, int speed, int defense, bool isActive)
            : base(health, attack, speed, defense, isActive)
        {
            laser = new Laser(120, 3, 4);
            chainsaw = new Chainsaw(200, 5, 1);
        }
        public Laser Laser { get => laser; set => laser = value; }
        public Chainsaw Chainsaw { get => chainsaw; set => chainsaw = value; }
    }
    class Tinker : Robot
    {
        private RocketLauncher rocket;
        private Laser laser;
        public Tinker(int health, int attack, int speed, int defense, bool isActive)
            : base(health, attack, speed, defense, isActive)
        {
            rocket = new RocketLauncher(200, 7, 10);
            laser = new Laser(120, 4, 8);
        }
        public RocketLauncher Rocket { get => rocket; set => rocket = value; }
        public Laser Laser { get => laser; set => laser = value; }
    }
    class Berserker : Robot
    {
        private Sword sword;
        public Berserker(int health, int attack, int speed, int defense, bool isActive)
            : base(health, attack, speed, defense, isActive)
        {
            sword = new Sword(100, 3, 2);
        }
        public Sword Sword { get => sword; set => sword = value; }
    }
}

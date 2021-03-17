﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    class Program
    {
        static void Initialize()
        {
            Console.WriteLine("Choose your robot:");
            Console.WriteLine("1. Destroyer");
            Console.WriteLine("2. Berserker (not implemented yet)");
            Console.WriteLine("3. Tinker (not implemented yet)");

            int type = int.Parse(Console.ReadLine());

            switch (type)
            {
                case 1:
                    Destroyer destroyer = new Destroyer(400, 500, 300, 50, true);
                    DestroyerAttack(destroyer, PlanetType());
                    break;
                case 2:
                    Berserker berserker = new Berserker(1500, 700, 500, 200, true);
                    BerserkerAttack(berserker, PlanetType());
                    break;
                case 3:
                    Tinker tinker = new Tinker(900, 600, 300, 800, true);
                    TinkerAttack(tinker, PlanetType());
                    break;
                default:
                    Console.WriteLine("Invalid robot");
                    break;
            }
            Console.WriteLine();
        }
        static Planet PlanetType()
        {
            Console.WriteLine("Choose the planet:");
            Console.WriteLine("1. Earth");
            Console.WriteLine("2. Mars");

            int type = int.Parse(Console.ReadLine());
            switch (type)
            {
                case 1: return new Earth(10, 10, 10);
                case 2: return new Mars(0, 100);
                default: return new Earth(200, 300, 100);
            }
        }
        static void DestroyerAttack(Destroyer robot, Planet planet)
        {
            int cooldownLaser = robot.Laser.Cooldown;
            int cooldownChainsaw = robot.Chainsaw.Cooldown;
            while (robot.IsActive && planet.ContainsLife)
            {
                Console.Clear();
                Being target = robot.AcquireTarget(planet);

                if (planet.Population == 0)
                {
                    planet.ContainsLife = false;
                    Ending(false);
                }
                else
                {
                    if (robot.Laser.Cooldown == 0)
                    {
                        Status(planet, robot, target);
                        robot.Laser.Shoot(target, planet);
                        robot.Laser.Sound();
                        robot.Laser.Cooldown = cooldownLaser;                    
                    }
                    else
                    {
                        if (robot.Chainsaw.Cooldown == 0)
                        {
                            Status(planet, robot, target);
                            robot.Chainsaw.Shoot(target, planet);
                            robot.Chainsaw.Sound();
                            robot.Chainsaw.Cooldown = cooldownChainsaw;                          
                        }
                        else
                        {
                            Status(planet, robot, target);
                            int damage = robot.Attack - target.Defense;
                            robot.AttackTarget(planet, damage, target);

                            damage = target.Attack - target.Attack * (robot.Defense / 100);
                            robot.Health -= damage;

                            if (robot.Health <= 0)
                            {
                                robot.IsActive = false;
                                Ending(true);
                            }
                        }
                    }                  
                }
                if (robot.Laser.Cooldown > 0)
                robot.Laser.Cooldown--;
                if (robot.Chainsaw.Cooldown > 0)
                robot.Chainsaw.Cooldown--;
                Console.ReadKey();            
            }
        }

        static void Status(Planet planet, Robot robot, Being target)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"Robot health: {robot.Health}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Target: {target.GetType()}");
            Console.WriteLine($"Target health: {target.Health}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (KeyValuePair<Being, int> person in planet.Targets)
            {
                Console.WriteLine($"{person.Key}: {person.Value}");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Planet population:");
            Console.WriteLine($"The planet has {planet.Population} people left");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
        static void Ending(bool isGood)
        {
            Console.Clear();
            Console.WriteLine();
            if(isGood)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*************************************");
                Console.WriteLine("The robot has been destroyed!");
                Console.WriteLine("The planet is safe!");
                Console.WriteLine("*************************************");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*************************************");
                Console.WriteLine("Everyone on the planet has perished..");
                Console.WriteLine("*************************************");
                Console.ResetColor();
            }
        }
        static void BerserkerAttack(Berserker robot, Planet planet)
        {
            while (robot.IsActive && planet.ContainsLife)
            {
                //not implemented yet
            }
        }
        static void TinkerAttack(Tinker robot, Planet planet)
        {
            while (robot.IsActive && planet.ContainsLife)
            {
                //not implemented yet
            }
        }
        static void Main(string[] args)
        {
            Initialize();
        }
    }
}

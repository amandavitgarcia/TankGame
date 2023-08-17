using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTankGame
{
    //Classe Tank com seus métodos e atributos
    public class Tank
    {
        public string Name { get; set; }
        public bool Alive { get; set; }
        public int Ammo { get; set; }
        public int Armor { get; set; }

        //Construtor - onde inicializamos as propiedades
        public Tank(string name)
        {
            Name = name;
            Alive = true;
            Ammo = 5;
            Armor = 60;
        }

        //Métodos da classe Tank
        public void FireAt(Tank enemy)
        {
            if (enemy.Ammo >= 1)
            {
                enemy.Ammo -= 1;
                Console.WriteLine($"{Name} fires on {enemy.Name}\n");
                Console.WriteLine("-----------------------------------");

                enemy.Hit();

                ShowInfo();
                enemy.ShowInfo();
            }
            else
            {
                Console.WriteLine($"{this.Name}, has no shells!");
            }
        }

        public void Hit()
        {
            this.Armor -= 20;
            Console.WriteLine($"{this.Name} is hit");

            if (this.Armor <= 0)
            {
                this.Explode();
            }
        }

        public void Explode()
        {
            this.Alive = false;
            Console.WriteLine($"{this.Name}, EXPLODESSS!");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\n{this.Name.ToUpper()} \nAmmo: {this.Ammo} \nArmor:{this.Armor}");
        }

        static void Exit()
        {
            Console.WriteLine("Finished game");

            Thread.Sleep(4000);
            System.Environment.Exit(0);
        }
    }
}


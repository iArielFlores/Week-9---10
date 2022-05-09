using System;
using System.Collections.Generic;

namespace Week10ForCNumber
{

    class Program
    {

        static void Main(string[] args)
        {



            Enemy d = new Enemy("== Enemy turn ==");


            Player c = new Player("=== Player turn ===");



            Fighter[] fighters = new Fighter[2];
            //animals[0] = a1;
            fighters[0] = c;
            fighters[1] = d;


            d.opponent = c; // added this
            c.opponent = d; // added this

            bool gameOver = false;

            while (!gameOver)
            {
                foreach (Fighter a in fighters)
                {

                    if (a.dead)
                    {
                        gameOver = true;
                        break;
                    }

                    a.TakeAction();
                }
            }
        }
    }



    abstract class Fighter
    {
        public string name;

        public int Hp = 10;

        public bool dead;

        public Fighter opponent;



        public Fighter(string n)
        {
            name = n;

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void TakeDamage(int amount)
        {
            Hp -= amount;
            Console.WriteLine("took " + amount + " points of damage");
            if (Hp <= 0)
            {
                Kill();

            }

        }

        public void Kill()
        {
            dead = true;

        }

        public virtual void TakeAction()
        {

        }
    }
    class Enemy : Fighter
    {
        int EHp = 10;

        public Enemy(string n) : base(n)
        {

            Name = n;
        }



        public override void TakeAction()
        {
            Console.WriteLine("== Enemy's turn ==");
            Console.WriteLine("\nEnemy's Health: " + Hp);

            opponent.TakeDamage(1);


        }

    }

    class Player : Fighter
    {
        int usertype = 1;

        public Player(string n) : base(n)
        {
            Name = n;
        }

        public override void TakeAction()
        {
            Console.WriteLine("== Player's turn ==");
            Console.WriteLine("Player's Health: " + Hp);

            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1 - Attack Enemey\n");
            Console.WriteLine("2 - Drink Potion\n");

            string ut = Console.ReadLine();
            usertype = int.Parse(ut);

            if (usertype == 1)
            {
                // attack
                Console.WriteLine("Attacking enemy for 2 points of damage!");
                opponent.TakeDamage(2);

            }
            else
            {
                // heal
                Hp += 5;
                Console.WriteLine("Restored 5 points of heatlh\n");
            }
        }

        /*public override void Speak()


        {
            if (usertype == 1)
            {
                Console.WriteLine("1- Attack Enemey");
                string ut = Console.ReadLine();
                usertype = int.Parse(ut);
            }
            else
                

        }*/
    }



}

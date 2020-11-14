using System;

namespace gamedev2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player();
            Slime sl = new Slime();
            Goblin go = new Goblin();
            p1.init();
            sl.init();
            go.init();

            Boolean jalan = true;

            while(jalan){
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("------------------------------------");
                Console.WriteLine("HP: "+p1.hp);
                Console.WriteLine("Slime HP: "+ sl.hp);
                Console.WriteLine("Goblin HP: "+ go.hp);
                Console.WriteLine("1. Serang Slime");
                Console.WriteLine("2. Serang Goblin");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilihan: ");
                int pilihan = Convert.ToInt32(Console.ReadLine());
                switch(pilihan){
                    case 1:
                    if(sl.isAlive){
                        p1.Attack(sl);
                    }
                    else{
                        Console.WriteLine("Slime is already dead!");
                    }
                    break;
                    case 2:
                    if(go.isAlive){
                        p1.Attack(go);
                    }
                    else{
                        Console.WriteLine("Goblin is already dead!");
                    }
                    break;
                    case 3:
                    jalan = false;
                    break;
                }
                if (sl.hp == 0 && go.hp == 0){
                    jalan = false;
                    Console.WriteLine("Congrats on your victory!!!");
                }
            }
        }
    }

    interface entity{
        void init();
    }

    abstract class Enemy{
        public int hp;
        protected int defend;
        public Boolean isAlive = true;
        Player p1 = new Player();

        public void Diserang(){
            if(isAlive){
                hp -= (p1.getAP() - defend);
                if(hp<=0){
                    hp = 0;
                    isAlive = false;
                }
            }
            if (!isAlive){
                Console.WriteLine("Target is dead");
            }
        }

        public abstract void intro();
    }

    class Slime : Enemy, entity {
        public void init(){
            hp = 100;
            defend = 50;
            intro();
        }
       override public void intro(){
            Console.WriteLine("*Blub Blub*");
        }
    }

    class Goblin : Enemy, entity{
        public void init(){
            hp = 250;
            defend = 100;
            intro();
        }
       override public void intro(){
            Console.WriteLine("*Gyahh*");
        }
    }

    class Player : entity {
        public int hp;
        private int AP = 200;
        public void init(){
            hp = 100;
        }

        //Properties
        public int getAP(){
            return this.AP;
        }
        public void Attack(Enemy en){
            en.Diserang();
        }
    }
}

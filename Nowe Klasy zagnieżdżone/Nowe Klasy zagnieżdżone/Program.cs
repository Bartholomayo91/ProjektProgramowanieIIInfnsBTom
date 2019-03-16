using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nowe_Klasy_zagnieżdżone
{
    class Program
    {
        class Printer
        {
            
            string name="brother";
            public string Name { get { return name; } set { name = value; } }
            int year=2000;
            public int Year{ get { return year; } set { year = value; } }
            int printing_carts=0;
            public int Printing_carts { get { return printing_carts; } set { printing_carts = value; } }
            ConteinerPrinter conteiner ;
            Cartridge cartridge ;
            
           
           /// /////////////////////////////////////////////////////////klasa zagnieżdżona Conteiner//////////////////////////////////////////////////////
           
            public class ConteinerPrinter
            {
                public int capasityConteiner = 500;
                public int numberOfcards = 0;
                public int statusPaper = 500;

                public ConteinerPrinter(int cap,int sP)
                {
                        this.capasityConteiner = cap;
                        this.statusPaper = sP;

                }
                public ConteinerPrinter(ConteinerPrinter a)
                {
                    capasityConteiner = a.capasityConteiner;
                    numberOfcards = a.numberOfcards;
                    statusPaper = a.statusPaper;

                }
                public ConteinerPrinter() { }
                public void PrintConteiner()
                {
                        Console.WriteLine("Pojemność pojemnika papieru: "+capasityConteiner);
                        Console.WriteLine("Aktualna liczba kartek: " + statusPaper);

                }

                //dokładanie papieru
                public void Replenishing_paper(ConteinerPrinter a)
                {
                    bool b = true;
                    while (b)
                    {
                        Console.Clear();
                        Console.WriteLine("Ile kartek chcesz dołożyć?: ");
                        a.numberOfcards = int.Parse(Console.ReadLine());
                        if (a.capasityConteiner < a.statusPaper+a.numberOfcards)
                        {
                        Console.WriteLine("Za mało miejsca w pojemniku! Spróbuj jeszcze raz.");
                        PrintConteiner();
                        Console.ReadLine();
                        Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Dołożono papier pomyślnie");
                        a.statusPaper = a.numberOfcards + a.statusPaper;
                        PrintConteiner();
                            Console.ReadLine();
                        Console.Clear();
                            b = false;
                        }
                    }
                }
            }

            /// ///////////////////////////////////////////////////////////////klasa zagnieżdżona Cartridge///////////////////////////////////////////////////////

            public class Cartridge
            {
                public int capasityCartridge = 100;
                public int ink_refill = 100;
                public int statusCartridge = 100;

                public Cartridge(int capC, int sC)
                {
                    capasityCartridge = capC;
                    statusCartridge = sC;

                }
                public Cartridge(Cartridge a)
                {
                    capasityCartridge = a.capasityCartridge;
                    ink_refill = a.ink_refill;
                    statusCartridge = a.statusCartridge;
                }
                public Cartridge() { }

                public void PrintCartridge()
                {
                    Console.WriteLine("Pojemność kartridżu: " + capasityCartridge);
                    Console.WriteLine("Aktualny poziom tuszu w kartridżu: " + statusCartridge);

                }

                //uzupełnianie tuszu
                public void Replenishing_cartridge(Cartridge a)
                {
                    bool b = true;
                    while (b)
                    {
                        Console.Clear();
                        Console.WriteLine("Ile tuszu chcesz dołożyć?: ");
                        a.ink_refill = int.Parse(Console.ReadLine());
                        if (a.capasityCartridge < a.statusCartridge + a.ink_refill)
                        {
                            Console.WriteLine("Za mała pojemność kartridża! Spróbuj jeszcze raz.");
                            PrintCartridge();
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Uzupełniono tusz pomyślnie");
                            a.statusCartridge = a.ink_refill + a.statusCartridge;
                            PrintCartridge();
                            Console.ReadLine();
                            Console.Clear();
                            b = false;
                        }
                    }
                }
            }

            /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            public Printer()
            {
                name = "none";
                year = 0;
                conteiner =new ConteinerPrinter();
                cartridge = new Cartridge();
            }
            public Printer(string naz, int r,ConteinerPrinter con,Cartridge car)
            {
                name = naz;
                year = r;
                ConteinerPrinter conteiner = new ConteinerPrinter(con);
                Cartridge cartridge=new Cartridge(car);

            }
            
            public Printer (string naz, int r)
            {
                name = naz;
                year = r;
                conteiner = new ConteinerPrinter();
                cartridge = new Cartridge();

            }
            public Printer(string naz, int r,int capasityConteiner,int numberOfcards, int ink_refill, int statusCartridge)
            {
                name = naz;
                year = r;
                conteiner = new ConteinerPrinter(capasityConteiner, numberOfcards);
                cartridge = new Cartridge(ink_refill,statusCartridge);

            }
            /*
            public void Print()
            {
                Console.WriteLine("Nazwa: "+name+", rok: "+year+", pojemność pojemnika: "+conteiner.capasityConteiner+", pojemność kartridża: " + cartridge.capasityCartridge+", aktualna liczba kartek w pojemniku: " +
                    conteiner.statusPaper+", poziom tuszu: " +cartridge.statusCartridge);
            }
            */
            public Printer(Printer a)
            {
                name= a.name;
                year = a.year;
                conteiner = new ConteinerPrinter(a.conteiner);
                cartridge = new Cartridge(a.cartridge);
            }

            //drukowanie 
            public void Printering(ConteinerPrinter a,Cartridge b)
            {
                Console.WriteLine("Ile stron chcesz wydrukować: ");
                printing_carts = int.Parse(Console.ReadLine());
                

                if (a.statusPaper > printing_carts&&printing_carts<b.statusCartridge*25)
                {
                    Console.WriteLine("Pomyślnie wydrukowano!");
                    a.statusPaper = a.statusPaper - printing_carts;
                    b.statusCartridge = b.statusCartridge - printing_carts/25;
                }
                else if (printing_carts > a.capasityConteiner)
                {
                    Console.WriteLine("Za mała pojemność podajnika. Zmień pojemność pojemnika z papierem lub zmniejsz ilość kartek do wydruku. ");
                }
                else if (printing_carts>a.statusPaper|| printing_carts < b.statusCartridge * 25)
                {
                    Console.WriteLine("Za mało pieru w drukarce! Uzupełnij papier i ponów próbę. ");
                }
                else if(printing_carts > b.statusCartridge * 25)
                {
                    Console.WriteLine("Za mało tuszu w drukarce! Uzupełnij tusz i ponów próbę. ");
                }
                Console.ReadLine();
            }

            public static int one = 100;
            public static int two = 200;

            public static int StaticMethod()
            {
                return one + two;
            }
        }


        ////////////////////////////////////////////////////////////////////////////////MAIN////////////////////////////////////////////////////////////////////
        
        static void Main(string[] args)
        {
            Printer.ConteinerPrinter two = new Printer.ConteinerPrinter(1250, 1000);
            Printer.Cartridge tree = new Printer.Cartridge(100, 100);
            Printer one = new Printer("Brother", 2000, two,tree);
           // one.Print();
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(Printer.StaticMethod());//wywołanie funkcji statycznej z polami statycznymi

            int choice;
            while (true)
            {
                two.PrintConteiner();
                tree.PrintCartridge();
                Console.WriteLine("[1] Wydrukuj coś.");
                Console.WriteLine("[2] Uzupełnij papier.");
                Console.WriteLine("[3] Uzupełnij tusz.");
                Console.WriteLine("[0] Wyjdź z programu.");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        one.Printering(two,tree);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        two.Replenishing_paper(two);
                        break;
                    case 3:
                        Console.Clear();
                        tree.Replenishing_cartridge(tree);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;

                }
            }

        }

    }
}

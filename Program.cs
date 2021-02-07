using System;
using System.IO;

namespace GeneratorNPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select which type of npc's you want to generate: \n1: Non-spellcaster \n2: Spellcaster\n3: Warrior with spellcasting features\n4: Doesn't matter");
            restart:
            int r = int.Parse(Console.ReadLine());
            switch (r)
            {
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Wrong option, please select option from below:\n1: Non-spellcaster \n2: Spellcaster\n3: Warrior with spellcasting features\n4: Doesn't matter");
                    goto restart;
            }

            Console.WriteLine("Enter how many npc's you want to generate: ");
            int iloscnpc = int.Parse(Console.ReadLine());
            while (iloscnpc < 0 || iloscnpc >20)
            {
                Console.WriteLine("You can generate between 1 to 20 npc's, please enter once again");
                iloscnpc = int.Parse(Console.ReadLine());
            }
            NPC(iloscnpc,r);
            
        }

        static string Tresc(int r) // returns all generated data of npc's
        {
            Random rnd = new Random();
            int a = rnd.Next(9);
            int b;
            if (r == 1) { b = rnd.Next(7); }
            else if (r == 2) { b = rnd.Next(6); }
            else if (r == 3) { b = rnd.Next(4); }
            else { b = rnd.Next(12); }
            Postacie npc = new Postacie();
            string tekst1 = npc.Imie(a).ToString();
            string tekst2 = npc.Rasa(a).ToString();
            string tekst3 = npc.Charakter().ToString();
            string tekst4 = npc.Klasa(b,r).ToString();
            string tekst5 = npc.Atrybuty(a, tekst4).ToString();
            string tekst = tekst1 + "\n" + tekst2 + "\n" + tekst3 + "\n" + tekst4 + "\n" + tekst5;
            return tekst;
        }
        static void NPC(int a, int r) //takes all generated info from method Tresc and saves it in a folder as a txt document
        {
            Console.WriteLine("Enter the folder path to save characters to: ");
            string nazwafolderu = Console.ReadLine();
            
            string folderName = @nazwafolderu;
            
            for (int i = 1; i <= a; i++)
            {
                string pathString = System.IO.Path.Combine(folderName, "NPC's");
                System.IO.Directory.CreateDirectory(pathString);
                string fileName = "NPC" + i + ".txt";

                pathString = System.IO.Path.Combine(pathString, fileName);
                string s = Tresc(r);
                File.WriteAllText(pathString, s);
            }
        }
                
        
    }
}

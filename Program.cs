using System;
using System.IO;

namespace GeneratorNPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select which type of NPCs you want to generate: \n1: Non-spellcaster \n2: Spellcaster\n3: Warrior with spellcasting features\n4: Doesn't matter");
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

            Console.WriteLine("Enter how many NPCs you want to generate: ");
            int howmanyNPCs = int.Parse(Console.ReadLine());
            while (howmanyNPCs < 0 || howmanyNPCs > 20)
            {
                Console.WriteLine("You can generate between 1 to 20 npcs, please enter once again");
                howmanyNPCs = int.Parse(Console.ReadLine());
            }
            SaveNPC(howmanyNPCs, r);
            
        }

        static string Text(int r) // writes all generated data of NPCs
        {
            Random rnd = new Random();
            int a = rnd.Next(9);
            int b;
            if (r == 1) { b = rnd.Next(7); }
            else if (r == 2) { b = rnd.Next(6); }
            else if (r == 3) { b = rnd.Next(4); }
            else { b = rnd.Next(12); }
            NPC npc = new NPC();
            string text = npc.Name(a) + "\n" + npc.Race(a) + "\n" + npc.Character() + "\n" + npc.Profession(b, r) + "\n" + npc.AbilityScores(a, npc.Profession(b, r));
            return text;
        }
        static void SaveNPC(int a, int r) //takes all generated info from method Text and saves it in a folder as a txt document
        {
            Console.WriteLine("Enter the folder path to save characters to: ");
            string foldername = Console.ReadLine();
            
            for (int i = 1; i <= a; i++)
            {
                string pathString = System.IO.Path.Combine(foldername, "NPCs");
                System.IO.Directory.CreateDirectory(pathString);
                string fileName = "NPC" + i + ".txt";

                pathString = System.IO.Path.Combine(pathString, fileName);
                string s = Text(r);
                File.WriteAllText(pathString, s);
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorNPC
{
    class NPC
    {
        public string Profession(int a, int r) // selects random class given which option user will select at the beginning
        {
            int i = a;
            string text;
            if (r == 1)
            {
                string[] profession = { "Barbarian", "Cleric", "Ranger", "Rogue", "Fighter", "Paladin", "Monk" };

                text = profession[i].ToString();
            }
            else if (r == 2)
            {
                string[] profession = { "Bard", "Druid", "Cleric", "Warlock", "Sorcerrer", "Wizard" };

                text = profession[i].ToString();
            }
            else if (r == 3)
            {
                string[] profession = { "Bard", "Cleric", "Ranger", "Paladin" };

                text = profession[i].ToString();
            }
            else
            {
                string[] profession = { "Barbarian", "Bard", "Druid", "Cleric", "Ranger", "Rogue", "Fighter", "Paladin", "Warlock", "Sorcerrer", "Wizard", "Monk" };

                text = profession[i].ToString();
            }
            
            return text;
        }
        public string Race(int a) // selects random race
        {
            string[] race = { "Human", "Elf", "Dwarf", "Gnome", "Halfling", "Dragonborn", "Tiefling", "Half-Orc", "Half-Elf" };
            int i = a;
            string text = race[i];
            return text;
        }
        public string AbilityScores(int a, string profession) // generates attributes for characters taking under consideration that races get ability score bonuses and some classes will have minimum ability scores for their main abilities
        {
            Random rnd = new Random();
            int randomAttribute;
            int b;
            int[] d = { 0, 0, 0, 0, 0, 0 };
            switch (a)
            {
                case 0:
                    int c = rnd.Next(6);
                    d[c]++;
                    do
                    {
                        b = rnd.Next(6);

                    } while (c == b);
                    d[b]++;
                    break;
                case 1:
                    d[1] += 2;
                    break;
                case 2:
                    d[2] += 2;
                    break;
                case 3:
                    d[3] += 2;
                    break;
                case 4:
                    d[1] += 2;
                    break;
                case 5:
                    d[0] += 2;
                    d[5]++;
                    break;
                case 6:
                    d[5] += 2;
                    break;
                case 7:
                    d[0] += 2;
                    d[2]++;
                    break;
                case 8:
                    d[5] += 2;
                    int e;
                    do { e = rnd.Next(6); }
                    while (e == 5);
                    d[e]++;
                    do
                    {
                        b = rnd.Next(6);

                    } while (e == b && b == 5);
                    d[b]++;
                    break;
                default:
                    break;

            }
            randomAttribute = rnd.Next(2);
            if (profession == "Barbarian" || profession == "Paladin" || (profession == "Fighter" && randomAttribute == 0))
            {
                int reset = d[0];
            restart:
                d[0] = reset;
                d[0] += rnd.Next(13, 16);
                while (d[0] < 13)
                {
                    goto restart;
                }


            }
            else { d[0] += rnd.Next(8, 16); }
            if (profession == "Rogue" || profession == "Ranger" || profession == "Monk" || (profession == "Fighter" && randomAttribute == 1))
            {
                int reset = d[1];
            restart2:
                d[1] = reset;
                d[1] += rnd.Next(13, 16);
                while (d[1] < 13)
                {
                    goto restart2;
                }
            }
            else { d[1] += rnd.Next(8, 16); }

            d[2] += rnd.Next(8, 16);
            if (profession == "Wizard")
            {
                int reset = d[3];
            restart3:
                d[3] = reset;
                d[3] += rnd.Next(13, 16);
                while (d[3] < 13)
                {
                    goto restart3;
                }
            }
            else { d[3] += rnd.Next(8, 16); }

            if (profession == "Druid" || profession == "Cleric" || profession == "Ranger" || profession == "Monk")
            {
                int reset = d[4];
            restart4:
                d[4] = reset;
                d[4] += rnd.Next(13, 16);
                while (d[4] < 13)
                {
                    goto restart4;
                }
            }
            else { d[4] += rnd.Next(8, 16); }
            if (profession == "Bard" || profession == "Warlock" || profession == "Sorcerrer" || profession == "Paladin")
            {
                int reset = d[5];
            restart5:
                d[5] = reset;
                d[5] += rnd.Next(13, 16);
                while (d[5] < 13)
                {
                    goto restart5;
                }
            }
            else { d[5] += rnd.Next(8, 16); }
            
            string text = "STR = {0}\nDEX = {1}\nCON = {2}\nINT = {3}\nWIS = {4}\nCHA = {5}";
            for (int i = 0; i < d.Length; i++)
            {
                text = text.Replace("{" + i + "}", d[i].ToString());

            }
            return text;
            
        }
    
        
       public string Character() // selects random alignment
        {
            string[] al = { "Chaotic good", "Neutral good", "Lawfull good", "Chaotic neutral", "Neutral", "Lawfull neutral", "Chaotic evil", "Neutral evil", "Lawful evil" };
            Random a = new Random();
            int b = a.Next(9);
            string text = al[b].ToString();
            return text;
        }
        public string Name(int a) // selects random name and surname according to randomly selected gender
        {
            Random rnd = new Random();
            int b = rnd.Next(2);
            string[] gender = { "Male", "Female" };
            string text;
            
            string[][][] data = new string[9][][];
            data[0] = new string[3][];
            data[1] = new string[3][];
            data[2] = new string[3][];
            data[3] = new string[3][];
            data[4] = new string[3][];
            data[5] = new string[3][];
            data[6] = new string[3][];
            data[7] = new string[3][];
            data[8] = new string[3][];
            //Human names
            data[0][0] = new string[] {"Darvin", "Dorn", "Evendur", "Gorstag", "Grim", "Helm", "Malark", "Morn", "Randal", "Stedd"};
            data[0][1] = new string[] {"Arveene", "Esvele", "Jhessail", "Kerri", "Lureene", "Kerri", "Lureene", "Miri", "Rowan","Shandri","Tessele" };
            data[0][2] = new string[] {"Amblecrown","Buckman","Dundragon","Evenwood","Greycastle","Tallstag"};
            //Elf names
            data[1][0] = new string[] {"Adran", "Aelar", "Aramil", "Arannis", "Aust", "Beiro", "Berrian", "Carric",
"Enialis", "Erdan", "Erevan", "Galinndan", "Hadarai", "Heian", "Himo",
"Immeral", "Ivellios", "Laucian", "Mindartis", "Paelias", "Peren", "uarion", "Riardon", 
"Rolen", "Soveliss", "Thamior", "Tharivol", "Theren", "Varis" };
            data[1][1] = new string[] { "Adrie", "Althaea", "Anastrianna", "Andraste", "Antinua", "Bethrynna", "Birel", "Caelynn", "Drusilia", "Enna", "Felosial", "Ielenia", "Jelenneth", "Keyleth", "Leshanna", "Lia", "Meriele", "Mialee", "Naivara", "Quelenna", "Quillathe", "Sariel", "Shanairra", "Shava", "Silaqui", "Theirastra", "Thia","Vadania", "Valanthe", "Xanaphia "};
            data[1][2] = new string[] { "Amakiir (Gemflower)", "Amastacia (Starflower)", "Galanodel (Moonwhisper)", "Holimion (Diamonddew)", "Ilphelkiir (Gemblossom)", "Liadon (Silverfrond)", "Meliamne (Oakenheel)", "Naïlo (Nightbreeze)", "Siannodel (Moonbrook)", "Xiloscient (Goldpetal)"};
            //Dwarf names
            data[2][0] = new string[] { "Adrik", "Alberich", "Baern", "Barendd", "Brottor", "Bruenor", "Dain", "Darrak", "Delg", "Eberk", "Einkil", "Fargrim", "Flint", "Gardain", "Harbek", "Kildrak", "Morgran", "Orsik", "Oskar", "Rangrim", "Rurik", "Taklinn", "Thoradi" };
            data[2][1] = new string[] { "Amber", "Artin", "Audhild", "Bardryn", "Dagnal", "Diesa", "Eldeth", "Falkrunn", "Finellen", "Gunnloda", "Gurdis", "Helja", "Hlin", "Kathra" };
            data[2][2] = new string[] { "Balderk", "Battlehammer", "Brawnanvil", "Dankil", "Fireforge", "Frostbeard", "Gorunn", "Holderhek", "Ironfist", "Loderr", "Lutgehr" };
            //Gnome names
            data[3][0] = new string[] { "Alston", "Alvyn", "Boddynock", "Brocc", "Burgell", "Dimble", "Eldon", "Erky", "Fonkin", "Frug" };
            data[3][1] = new string[] { "Bimpnottin", "Breena", "Caramip", "Carlin", "Donella", "Duvamil", "Ella", "Ellyjobell", "Ellywick", "Lilli", "Loopmottin", "Lorilla" };
            data[3][2] = new string[] { "Beren", "Daergel", "Folkor", "Garrick", "Nackle", "Murnig", "Ningel", "Raulnor", "Scheppen", "Timbers", "Turen"};
            //Halfling names
            data[4][0] = new string[] { "Alton", "Ander", "Cade", "Corrin", "Eldon", "Errich", "Finnan", "Garret", "Lindal", "Lyle", "Merric", "Milo", "Osborn", "Perrin", "Reed" };
            data[4][1] = new string[] { "Andry", "Bree", "Callie", "Cora", "Euphemia", "Jillian", "Kithri", "Lavinia", "Lidda", "Merla", "Nedda", "Paela", "Portia" };
            data[4][2] = new string[] { "Brushgather", "Goodbarrel", "Greenbottle", "High-hill", "Hilltopple", "Leagallow", "Tealeaf", "Thorngage", "Tosscobble"};
            //Dragonborn names
            data[5][0] = new string[] { "Arjhan", "Balasar", "Bharash", "Donaar", "Ghesh", "Heskan", "Kriv", "Medrash", "Mehen", "Nadarr", "Pandjed", "Patrin", "Rhogar", "Shamash"};
            data[5][1] = new string[] { "Akra", "Biri", "Daar", "Farideh", "Harann", "Havilar", "Jheri", "Kava", "Korinn", "Mishann", "Nala", "Perra", "Raiann", "Sora"};
            data[5][2] = new string[] { "Clethtinthiallor", "Daardendrian", "Delmirev", "Drachedandion", "Fenkenkabradon", "Kepeshkmolik", "Kerrhylon", "Kimbatuul"};
            //Tiefling names
            data[6][0] = new string[] { "Akmenos", "Amnon", "Barakas", "Damakos", "Ekemon", "Iados", "Kairon", "Leucis", "Melech", "Mordai","Morthos", "Pelaios" };
            data[6][1] = new string[] { "Akta", "Anakis", "Bryseis", "Criella", "Damaia", "Ea", "Kallista", "Lerissa", "Makaria", "Nemeia", "Orianna"};
            data[6][2] = new string[] { "Art", "Carrion", "Chant", "Creed", "Despair", "Excellence", "Fear", "Glory", "Hope", "Ideal", "Music", "Nowhere"};
            //Half Orc names
            data[7][0] = new string[] { "Dench", "Feng", "Gell", "Henk", "Holg", "Imsh", "Keth","Darvin", "Dorn", "Evendur", "Gorstag", "Grim", "Helm"};
            data[7][1] = new string[] { "Baggi", "Emen", "Engong", "Kansif", "Myev", "Neega", "Ovak","Kerri", "Lureene", "Kerri", "Lureene", "Miri", "Rowan"};
            data[7][2] = new string[] { "Amblecrown","Buckman","Dundragon","Evenwood","Greycastle","Tallstag" };
            //Half Elf names
            data[8][0] = new string[] { "Gorstag", "Grim", "Helm", "Malark", "Morn", "Randal", "Adran", "Aelar", "Aramil", "Arannis", "Aust", "Beiro"};
            data[8][1] = new string[] { "Jhessail", "Kerri", "Lureene", "Kerri", "Lureene", "Miri", "Antinua", "Bethrynna", "Birel", "Caelynn", "Drusilia", "Enna", "Felosial", "Ielenia", "Jelenneth", "Keyleth"};
            data[8][2] = new string[] { "Amblecrown","Buckman","Dundragon","Evenwood","Greycastle","Tallstag", "Amakiir (Gemflower)", "Amastacia (Starflower)", "Galanodel (Moonwhisper)", "Holimion (Diamonddew)", "Ilphelkiir (Gemblossom)", "Liadon (Silverfrond)"};
            int c = rnd.Next(data[a][b].Length);
            int d = rnd.Next(data[a][2].Length);
            text = gender[b].ToString() + " " + data[a][b][c].ToString() + " " + data[a][2][d].ToString();
            return text;
            
        }   
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Huntr
{
    class LoadAchievements
    {
        //attributes
        private int[] achieves = new int[9];




        public void Load(string filename)
        {
            try
            {
                //opens the file with the filename given as a parameter
                StreamReader reader = new StreamReader(filename);

                //reads the phrases
                string line;
                int lineInt;
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    //stores the phrases
                    int.TryParse(line, out lineInt);
                    achieves[i] = lineInt;
                    Console.WriteLine("Achieves[" + i + "]: " + achieves[i]); //Debug stuff
                    i++;
                }
                Console.WriteLine("i at the end: " + i);
                //close the file if you openned it
                Variables.achieves = achieves;
                reader.Close();
                Variables.achieves = achieves;
            }
            catch (FileNotFoundException fnf)
            {
                //The file might not exist, create it
                try
                {
                    //FileStream newFile = File.Create("AchievementsDebug.txt");
                    WriteAchievements(achieves);
                    StreamReader reader = new StreamReader("Achievements.txt");

                    //reads the phrases
                    string line;
                    int lineInt;
                    int i = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //stores the phrases
                        int.TryParse(line, out lineInt);
                        achieves[i] = lineInt;
                    }
                    //close the file if you openned it
                    reader.Close();
                    Variables.achieves = achieves;
                }
                catch (IOException)
                {
                    //return a null
                    Variables.achieves = achieves;
                }
                Console.WriteLine("FILE WASN'T FOUND: " + fnf.Message); //Debug stuff
            }
            catch(IOException ioe)
            {
                Console.WriteLine("DIFFERENT IOEXCEPTION OR FILE NOT FOUND AGAIN: " + ioe.Message); //Debug
                Variables.achieves = null;
            }
            //return null;
        }

        public void WriteAchievements(int[] achieves)
        {
            try
            {
                StreamWriter update = new StreamWriter("Achievements.txt");

                for (int i = 0; i < achieves.Count(); i++ )
                {
                    update.WriteLine(achieves[i]);

                }
                if(achieves == null)
                {
                    for(int i = 0; i<10; i++)
                    {
                        update.WriteLine(0);
                    }
                }
                update.Close();
            }
            catch(IOException ioe)
            {
                Console.WriteLine("IOE Exception: " + ioe.Message);
            }
        }
        public void WriteGamesPlayed()
        {
            try
            {
                StreamWriter update = new StreamWriter("GamesPlayed.txt");
                update.WriteLine(Variables.gamesPlayed);
                update.Close();
            }
            catch(IOException ioe)
            {
                try
                {
                    StreamWriter update = new StreamWriter("GamesPlayed.txt");
                    update.WriteLine(Variables.gamesPlayed);
                    Console.WriteLine("IO Exception" + ioe.Message);
                    update.Close();
                }
                catch (IOException ioe2)
                {
                    Console.WriteLine("2nd IO EXCEPTION: " + ioe2.Message);
                }
            }
        }
        public void WriteExitGame()
        {
            try
            {
                StreamWriter update = new StreamWriter("GamesExited.txt");
                //Variables.gamesQuit++;
                update.WriteLine(Variables.gamesQuit);
                update.Close();
            }
            catch(IOException)
            {
                try
                {
                    StreamWriter update = new StreamWriter("GamesExited.txt");
                    update.WriteLine(Variables.gamesQuit);
                    update.Close();
                }
                catch(IOException)
                {

                }
            }
        }

        //check number of games
        public int CheckGames(string filename)
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                string line;
                int lineInt;
                while ((line = reader.ReadLine()) != null)
                {
                    //stores the phrases
                    int.TryParse(line, out lineInt);
                    Variables.gamesPlayed = lineInt;
                }
                reader.Close();
            }
            catch (IOException)
            {
                try
                {
                    FileStream newFile = File.Create("GamesPlayed.txt");
                    StreamReader reader = new StreamReader(filename);
                    string line;
                    int lineInt;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //stores the phrases
                        int.TryParse(line, out lineInt);
                        Variables.gamesPlayed = lineInt;
                    }
                    reader.Close();
                }
                catch (IOException)
                {
                    return Variables.gamesPlayed;
                }
            }

            return Variables.gamesPlayed;
        }

        public int CheckQuits(string filename)
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                string line;
                int lineInt;
                while ((line = reader.ReadLine()) != null)
                {
                    //stores the phrases
                    int.TryParse(line, out lineInt);
                    Variables.gamesPlayed = lineInt;
                }
                reader.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("ERROR READING FILE");
                try
                {
                    StreamReader reader = new StreamReader(filename);
                    string line;
                    int lineInt;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //stores the phrases
                        int.TryParse(line, out lineInt);
                        Variables.gamesQuit = lineInt;
                    }
                    reader.Close();
                }
                catch (IOException)
                {
                    return Variables.gamesQuit;
                }
            }

            return Variables.gamesQuit;
        }
    }
}

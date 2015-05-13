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
                }
                //close the file if you openned it
                reader.Close();
                Variables.achieves = achieves;
            }
            catch (FileNotFoundException)
            {
                //The file might not exist, create it
                try
                {
                    //FileStream newFile = File.Create("Achievements.txt");
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

            }
            catch(IOException)
            {
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
            }
            catch(IOException)
            {

            }
        }
        public void WriteGamesPlayed()
        {
            try
            {
                StreamWriter update = new StreamWriter("GamesPlayed.txt");
                update.WriteLine(Variables.gamesPlayed);
            }
            catch(IOException)
            {
                try
                {
                    StreamWriter update = new StreamWriter("GamesPlayed.txt");
                    update.WriteLine(Variables.gamesPlayed);
                }
                catch (IOException)
                {

                }
            }
        }
        public void WriteExitGame()
        {
            try
            {
                StreamWriter update = new StreamWriter("GamesExited.txt");
                Variables.gamesQuit++;
                update.WriteLine(Variables.gamesQuit);
            }
            catch(IOException)
            {
                try
                {
                    StreamWriter update = new StreamWriter("GamesExited.txt");
                    update.WriteLine(Variables.gamesQuit);
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

            }
            catch (IOException)
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
                        Variables.gamesQuit = lineInt;
                    }

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

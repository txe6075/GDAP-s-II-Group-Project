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




        public int[] Load(string filename)
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
                return achieves;
            }
            catch (IOException)
            {
                //The file might not exist, create it
                try
                {
                    FileStream newFile = File.Create("Achievements.txt");

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
                    return achieves;
                }
                catch (IOException)
                {
                    //return a null
                    return achieves;
                }

            }
            //return null;
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
    }
}

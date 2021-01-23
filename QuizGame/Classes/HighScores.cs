using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace QuizGame.Classes
{
    class HighScores
    {
        // Create filepath

        string filePath = @"c:\temp\highscores.json";

        public void Serialize(string getJson, List<Player> list)
        {
            // Serialize the user inputs and write to file
            getJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, getJson);
        }
        public void DeSerialize(out string getJson, out List<Player> list)
        {
            // Get data.json and Deserialize
            getJson = File.ReadAllText(filePath);
            var postlist = JsonConvert.DeserializeObject<List<Player>>(getJson) ?? new List<Player>();
            list = postlist;
        }

    }
}

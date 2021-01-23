using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame.Classes
{
    class AddScore
    {
        // Instantiate classes
        HighScores serialize = new HighScores();
        public void Create(string name, int score)
        {
            Console.Clear();
            // Run method deserialize
            serialize.DeSerialize(out string getJson, out List<Player> list);

            // Add new post
            list.Add(new Player()
            {
                Name = name,
                Score = score,
            });
            // Run method serialize
            serialize.Serialize(getJson, list);
        }
    }
}

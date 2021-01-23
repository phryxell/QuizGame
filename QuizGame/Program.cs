using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;
using QuizGame.Classes;
using System.Media;

namespace QuizGame
{
    class Program
    {
        static void Main(string[] args)
        {

            string usersChoice;
            string answer = "Y";

            string filePath = @"c:\temp\highscores.json";

            //string rootFolder = Directory.GetCurrentDirectory();
            //string filePath = "highscores.json";

            var quizMusic = new SoundPlayer
            {
                SoundLocation = @"https://studenter.miun.se/~phno1900/music/quizmusic.wav"
            };
            quizMusic.PlayLooping();

            do
            {
                string userInput;
                string username = "";
                string cheatCode = "ggmu";
                int YourScore = 0;

                // Instantiate classes
                HighScores serialize = new HighScores();
                AddScore add = new AddScore();
                Font font = new Font();
                Cheat cheat = new Cheat();

                Console.SetWindowSize(75, 50);

                Console.ForegroundColor = ConsoleColor.Yellow;//yellow's pretty good aesthetically and functionally
                Console.WriteLine("           ___________________________________________________            ");
                Console.WriteLine("          |                                                   |           ");
                Console.WriteLine("          |   Welcome to the greatest Manchester United Quiz  |           ");// "/" cannot be used for some reason in writelines
                Console.WriteLine("          | When the Quiz starts you have 5 minutes to finish |           ");
                Console.WriteLine("          |                                                   |           ");
                Console.WriteLine("          |       Enter your name and begin the Quiz!         |           ");
                Console.WriteLine("          |___________________________________________________|           ");
                Console.WriteLine();

                // If file exists display all saved guestbook entries
                if (File.Exists(filePath))
                {

                    // Post all the posts in the guestbook
                    serialize.DeSerialize(out _, out List<Player> list);
                    int i = 0;

                    Console.WriteLine("           ___________________________________________________            ");
                    Console.WriteLine("          |                                                   |           ");
                    Console.WriteLine("          |                    HIGH SCORES                    |           ");
                    Console.WriteLine("          |___________________________________________________|           ");
                    Console.WriteLine("          |                                                   |           ");
                    Console.WriteLine("          |          NAME                     SCORE           |           ");
                    Console.WriteLine("          |___________________________________________________|         \n");
                    int topFive = 5;
                    foreach (var obj in list.OrderByDescending(x => x.Score).Take(topFive))
                    {
                        Console.WriteLine($"\t\t    {obj.Name}  \t\t\t{obj.Score}\n");
                        i++;
                    }
                }
                // If file do not exists create the file and CLOSE IT so it doesn't interfere with future processes...
                if (!File.Exists(filePath))
                {
                    FileStream fs = File.Create(filePath);
                    fs.Close();
                }

                Console.WriteLine();
                Console.WriteLine();

                do
                {
                    Console.WriteLine("First, you must enter your name.");
                    userInput = Console.ReadLine();
               
                 if (userInput == cheatCode)
                {
                    Console.Clear();
                    cheat.CheatIndex();
                    Console.WriteLine("\n\t\tNow, choose your name, preferable to 'Cheater'.");
                    userInput = Console.ReadLine();
                    username = userInput;
                    Console.Clear();
                    }
                else
                {
                    username = userInput;
                }
                }
                while (string.IsNullOrEmpty(userInput));


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Good day, " + username + ", the following quiz will test your knowledge of"); // leave spaces for sentences between concatenated data
                Console.WriteLine("Manchester United, good luck.");
                Console.WriteLine();
                Console.ReadLine();
                Console.Clear();  //Clears the current screen, needs action such as "readline" so it won't supercede writelines
                Console.WriteLine("\n\tQuiz Time!");

                Timer timer = new Timer(300000); // Exit the quiz after 5 minutes
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

                string[] validValues = new string[] { "a", "b", "c", "d" }; // String containing all valid inputs from users

                Console.WriteLine("\n\tQuestion 1: Which year did Manchester United win the treble?\n");
                Console.WriteLine("\ta) 1992");
                Console.WriteLine("\tb) 1994");
                Console.WriteLine("\tc) 1997");
                Console.WriteLine("\td) 1999");
                Console.WriteLine();
                string answer1 = "d";
                string usersAnswer1;

                Console.Write("Answer: ");
                usersAnswer1 = Console.ReadLine();

                while (!validValues.Any(usersAnswer1.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer1 = Console.ReadLine();
                }

                //if (string.IsNullOrEmpty(usersAnswer1) || usersAnswer1.Trim().Length != 1 && usersAnswer1 != "a" || usersAnswer1 != "b" || usersAnswer1 != "c" || usersAnswer1 != "d")
                //{
                  //  Console.WriteLine("Please enter a valid letter");
                   // usersAnswer1 = Console.ReadLine();
                //} 

                if (usersAnswer1 == answer1)
                { 
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);

                Console.Clear();
                Console.WriteLine("\nA derby called 'War of the Roses' involves Manchester United and ...?\n");
                Console.WriteLine("\ta) Leeds United");
                Console.WriteLine("\tb) Sheffield United");
                Console.WriteLine("\tc) Wednesday United");
                Console.WriteLine("\td) Liverpool FC");
                string answer2 = "a";
                string usersAnswer2;

                Console.Write("Answer: ");
                usersAnswer2 = Console.ReadLine();

                while (!validValues.Any(usersAnswer2.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer2 = Console.ReadLine();
                }

                if (usersAnswer2 == answer2)
                {
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);
                Console.Clear();
                Console.WriteLine("\n\tWhich was the first manager after Sir Alex Ferguson?\n");
                Console.WriteLine("\ta) Luis Van Gaal");
                Console.WriteLine("\tb) Ryan Giggs");
                Console.WriteLine("\tc) David Moyes");
                Console.WriteLine("\td) José Mourinho");

                string answer3 = "c";
                string usersAnswer3;

                Console.Write("Answer: ");
                usersAnswer3 = Console.ReadLine();

                while (!validValues.Any(usersAnswer3.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer3 = Console.ReadLine();
                }

                if (usersAnswer3 == answer3)
                {
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);

                Console.Clear();
                Console.WriteLine("\n\tWhat is the name of the Manchester United stadium?\n");
                Console.WriteLine("\ta) Old Trafford");
                Console.WriteLine("\tb) Emirates Stadium");
                Console.WriteLine("\tc) White Hart Lane");
                Console.WriteLine("\td) Stamford Bridge");
                string answer4 = "a";
                string usersAnswer4;

                Console.Write("Answer: ");
                usersAnswer4 = Console.ReadLine();

                while (!validValues.Any(usersAnswer4.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer4 = Console.ReadLine();
                }

                if (usersAnswer4 == answer4)
                {
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);

                Console.Clear();
                Console.WriteLine("\n\tWhich year did the terrible flight disaster in Munich happen?\n");
                Console.WriteLine("\ta) 1938");
                Console.WriteLine("\tb) 1948");
                Console.WriteLine("\tc) 1958");
                Console.WriteLine("\td) 1968");
                string answer5 = "c";
                string usersAnswer5;

                Console.Write("Answer: ");

                usersAnswer5 = Console.ReadLine();

                while (!validValues.Any(usersAnswer5.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer5 = Console.ReadLine();
                }

                if (usersAnswer5 == answer5)
                {
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);
                Console.Clear();
                Console.WriteLine("\nWhich United captain did have a classic tunnel fight against Patrick Viera?\n");
                Console.WriteLine("\ta) Roy Keane");
                Console.WriteLine("\tb) Gary Neville");
                Console.WriteLine("\tc) David Beckham");
                Console.WriteLine("\td) Wayne Rooney");
                string answer6 = "a";
                string usersAnswer6;

                Console.Write("Answer: ");

                usersAnswer6 = Console.ReadLine();

                while (!validValues.Any(usersAnswer6.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer6 = Console.ReadLine();
                }

                if (usersAnswer6 == answer6)
                {
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);
                Console.Clear();
                Console.WriteLine("\nWhich shirt in United have a iconic meaning for the club and their fans?\n");
                Console.WriteLine("\ta) 1");
                Console.WriteLine("\tb) 3");
                Console.WriteLine("\tc) 7");
                Console.WriteLine("\td) 20");
                string answer7 = "c";
                string usersAnswer7;

                Console.Write("Answer: ");

                usersAnswer7 = Console.ReadLine();

                while (!validValues.Any(usersAnswer7.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer7 = Console.ReadLine();
                }

                if (usersAnswer7 == answer7)
                {
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);
                Console.Clear();
                Console.WriteLine("\n\tWhich player scissor kicked one supporter during a football game?\n");
                Console.WriteLine("\ta) Sir Bobby Charlton");
                Console.WriteLine("\tb) Juan Sebastian Véron");
                Console.WriteLine("\tc) Nemanja Vidic");
                Console.WriteLine("\td) Eric Cantona");
                string answer8 = "d";
                string usersAnswer8;

                Console.Write("Answer: ");

                usersAnswer8 = Console.ReadLine();

                while (!validValues.Any(usersAnswer8.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer8 = Console.ReadLine();
                }

                if (usersAnswer8 == answer8)
                {
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);
                Console.Clear();
                Console.WriteLine("\n\tWhen did United last win the Champions League?\n");
                Console.WriteLine("\ta) 1998");
                Console.WriteLine("\tb) 2008");
                Console.WriteLine("\tc) 2018");
                Console.WriteLine("\td) 2002");
                string answer9 = "b";
                string usersAnswer9;

                Console.Write("Answer: ");

                usersAnswer9 = Console.ReadLine();

                while (!validValues.Any(usersAnswer9.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer9 = Console.ReadLine();
                }

                if (usersAnswer9 == answer9)
                {
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);
                Console.Clear();

                Console.WriteLine("\nUnited won that game against Chelsea on penalties,\nthe United keeper saved the last penalty and hence United won. What was the keepers name?\n");
                Console.WriteLine("\ta) Peter Schmeichel");
                Console.WriteLine("\tb) Fabien Barthez");
                Console.WriteLine("\tc) David de Gea");
                Console.WriteLine("\td) Edwin van de Sar");
                string answer10 = "d";
                string usersAnswer10;

                Console.Write("Answer: ");

                usersAnswer10 = Console.ReadLine();

                while (!validValues.Any(usersAnswer10.Equals))
                {
                    Console.WriteLine("Please enter a valid letter");
                    usersAnswer10 = Console.ReadLine();
                }

                if (usersAnswer10 == answer10)
                {
                    YourScore++;
                    Console.Beep(2500, 200);
                }
                else Console.Beep(500, 800);
                Console.Clear();

                if (YourScore == 10)
                { 
                font.BonusRound();

                Console.WriteLine("To earn a bonus point: \n");
                Console.WriteLine("How many trophies did United win during the Sir Alex Ferguson era?\n");

                    int guess = 38;
                int usersGuess;

                Console.Write("Answer: ");
                usersGuess = Convert.ToInt32(Console.ReadLine());
                    if (usersGuess == guess)
                    {
                        YourScore++;
                        Console.Beep(2500, 200);
                    }
                    else Console.Beep(500, 800);
                } 
                else 
                {
                    Console.Clear();
                    Console.WriteLine("\n\tYour score is being calculated. Please type any key to continue...");
                    Console.ReadLine();
                }

                Console.Clear();
                if (YourScore == 11)
                    Console.WriteLine("\nCongratulations! You got a perfect score of 10 and you got the bonus question right! A true United supporter!");
                else if (YourScore == 10)
                    Console.WriteLine("\n\tGreat Job!! You got a " + YourScore + ", almost perfect! And for your information, United won 38 trophies with Sir Alex Ferguson");
                else if (YourScore == 9 || YourScore == 8 || YourScore == 7)
                    Console.WriteLine("\n\tGreat Job!! You got a " + YourScore + "!!");
                else if (YourScore == 6 || YourScore == 5)
                    Console.WriteLine("\n\tYou got a " + YourScore + ", not terrible!");
                else if (YourScore < 5)
                    Console.WriteLine("\n\tYour score is...     " + YourScore + ", fuck off you scouser");

                Console.WriteLine();

                Console.WriteLine("Would you like to play again? (Y/N)");
                usersChoice = Console.ReadLine();
                Console.Clear();

                add.Create(username, YourScore);
            }
            while (usersChoice == answer); //use this type of if statement for Y/N stuff

            Console.ReadKey();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.Clear();

            var quizMusic = new SoundPlayer();
           
            quizMusic.Stop();

            var stopTimer = new Timer();

            stopTimer.Stop();

            var font = new Font();

            font.FontGameOver();

        }
    }
}
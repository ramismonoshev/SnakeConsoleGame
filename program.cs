using System;
using System.Threading;

namespace Snake
{
    class Program
    {


        int foodX = 5;
        int foodY = 5;

        int segments = 4;

        char key;

        char[,] a = new char[20, 20] {
              { 'c', 'c', 'c', 'c', 'c','c', 'c', 'c', 'c', 'c','c', 'c', 'c', 'c', 'c','c', 'c', 'c', 'c', 'c'},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', 'c',},
            { 'c', 'c', 'c', 'c', 'c','c', 'c', 'c', 'c', 'c','c', 'c', 'c', 'c', 'c','c', 'c', 'c', 'c', 'c'},
        };

        int[] X = new int[100];
        int[] Y = new int[100];

        public void border()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(a[i, j]);
                }
                Console.WriteLine();
            }
        }

        Program()
        {
            X[0] = 2;
            Y[0] = 2;
        }

        private void drawSnake(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("∎");
        }

        int Height = 20;
        int Width = 20;

        private void writeFood(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("$");
        }

        private void refresh()
        {

           for (int i = 1; i < segments-3; i++)
                {
                    for (int j = 1; j < segments-3; j++)
                    {
                        Console.WriteLine(segments);
                        Console.WriteLine(i);
                        Console.WriteLine(j);
                        if (X[0] == X[i] && Y[0] == Y[j])
                        {
                            Console.WriteLine("Game Over!");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Do you want to play again? Type Yes to play again. Any key + enter to end the game.");
                            string bruh;
                            bruh = Console.ReadLine();
                            if (bruh.ToLower() == "yes")
                            {
                                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                            }
                            else
                            {
                                Environment.Exit(-1);
                            }
                        }
                    }
                }

            userInputKey();

            changingWhereTheHeadIs();

            ifTheHeadHitsTheWall();

            ifTheFoodIsEaten();

            printScore();

            consumeedFood_becomingLonger();

            UpdateSnakeAndFood();

            Thread.Sleep(40);
        }

        private void changingWhereTheHeadIs()
        {
            if (key == 'w' || key == 'W')
                Y[0]--;

            else if (key == 's' || key == 'S')
                Y[0]++;

            else if (key == 'd' || key == 'D')
                X[0]++;

            else if (key == 'a' || key == 'A')
                X[0]--;
            else if (key != 'a' && key != 's' && key != 'w' && key != 'd')
                Y[0]++;
        }

        private void ifTheHeadHitsTheWall()
        {
            if (a[X[0], Y[0]] == 'c')
            {
                Console.WriteLine("Game Over!");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Do you want to play again? Type Yes to play again. Any key + enter to end the game.");
                string playagain;
                playagain = Console.ReadLine();
                if (playagain.ToLower() == "yes")
                {
                    Console.Clear();
                    System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                    Console.Clear();
                }
                else
                {
                    Environment.Exit(-1);
                }
            }
        }

        private void ifTheFoodIsEaten()
        {
            if (X[0] == foodX && Y[0] == foodY)
            {
                segments++;
                Random rand2 = new Random((int)DateTime.Now.Ticks);

                foodX = rand2.Next(2, Width - 2);
                foodY = rand2.Next(2, Height - 2);

            }
        }

        private void consumeedFood_becomingLonger()
        {
            for (int i = segments; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
        }

        private void printScore()
        {
            Console.SetCursorPosition(0, 25);
            int score = segments - 1;
            Console.WriteLine("Your score is " + score);
        }

        private void userInputKey()
        {
            while (true)
                try
                {
                    if (Console.KeyAvailable)
                    {
                        Console.CursorVisible = false;
                        key = Console.ReadKey(true).KeyChar;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Please try again");
                }

        }

        private void UpdateSnakeAndFood()
        {
            for (int i = 0; i < segments; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                drawSnake(X[i], Y[i]);
                writeFood(foodX, foodY);
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();

            snakeCaseName();

            System.Threading.Thread.Sleep(1500);

            Program snake1 = new Program();

            while (true)
            {
                Console.Clear();
                snake1.border();
                snake1.refresh();
            }
        }

        private static void snakeCaseName()
        {
            while (true)
                try
                {
                    string snakeCaseName;
                    bool tf = false;

                    string hello = "Hello, welcome to Tony's snake game!";


                    gameSpeakMethod(hello, 0);
                    string hello2 = "Please use keys WSAD for up, down, left, right, respectively, to eat food with the snake";
                    gameSpeakMethod(hello2, 1);

                    string hello4 = "Please make your name at least 12 characters long and at most 25 characters long.";
                    gameSpeakMethod(hello4, 2);

                    string hello5 = "(snakes have long names because they're are long!)";
                    gameSpeakMethod(hello5, 3);


                    string hello6 = "Also, please include at least one lowercase letter, one uppercase letter, one digit, and one special character!";
                    gameSpeakMethod(hello6, 4);

                    string hello7 = "(snakes have pretty unique names!)";
                    gameSpeakMethod(hello7, 5);

                    string hello3 = "Please enter the name of your snake.";
                    gameSpeakMethod(hello3, 6);

                    while (true)
                    {
                        snakeCaseName = Console.ReadLine();

                        tf = true;

                        if (snakeCaseName.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()) < 0) tf = false;

                        if (snakeCaseName.IndexOfAny("0123456789".ToCharArray()) < 0) tf = false;  //I learned this method wayyy back in like january when i was solving algorithms in "CODEWARS.COM" while reading an editorial

                        if (snakeCaseName.IndexOfAny("!#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~".ToCharArray()) < 0) tf = false;

                        if (snakeCaseName.IndexOfAny("abcdefghijklmnopqrstuvwxyz".ToCharArray()) < 0) tf = false;

                        if (snakeCaseName.Length < 8 || 20 < snakeCaseName.Length) tf = false;

                        if (tf == true)
                        {
                            Console.WriteLine("Good job, you made a valid snake name!");
                            string hello8 = "Hello ";
                            gameSpeakMethod(hello8, 35);

                            for (int i = 0; i < snakeCaseName.Length; i++)
                            {
                                Console.SetCursorPosition(6 + i, 35);
                                Console.WriteLine(snakeCaseName[i]);
                                System.Threading.Thread.Sleep(35);
                            }
                            break;
                        }
                        else Console.WriteLine("You did not type in a valid snake name, please try again.");
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Please try again.");
                }
        }

        private static void gameSpeakMethod(string hello, int b)
        {
            for (int i = 0; i < hello.Length; i++)
            {
                Console.SetCursorPosition(i, b);
                Console.WriteLine(hello[i]);
                System.Threading.Thread.Sleep(35);
            }
        }
    }
}

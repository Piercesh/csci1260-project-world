namespace Video_Game
{
    public class Program
    {
        static void Main(string[] args)
        {
           ///This is to make the maze Random
            Random random = new Random();

            /// Here is the Width, Height, and moveLimits for the maze and player
            int[] widths = { 15, 19, 23 };
            int[] heights = { 11, 13, 15 };
            int[] moveLimits = { 100, 150, 220 };
            ///This is how it will keep limits as to how many moves you have made.
            Player player = new Player(1, 1, moveLimits[0]);

            ///Here in this code, it will keep track of how many rounds you have done,
            ///the limit is set to three.
            ///go through all three of the rounds and you win the game.
            for (int round = 1; round <= 3; round++)
            {
                char[,] maze = GenerateMaze(widths[round - 1], heights[round - 1], random);
                player.Move(1, 1);

                player.ResetMoves(moveLimits[round - 1]);
                int exitX = maze.GetLength(1) - 2;
                int exitY = maze.GetLength(0) - 2;
                ///Exit will be set as E.
                maze[exitX, exitY] = 'E';
                ///This is suppose to make the monster spawn
                var spawn = FindMonsterSpawn(maze, random);

                Monster monster = new Monster(spawn.x, spawn.y, round * 10, round * 30);
                ///This will place random items in the maze.
                PlaceRandomItem(maze, 'W', random);
                PlaceRandomItem(maze, 'H', random);

                ///This is how it will tell you when you clear the round or failed the round.
                bool roundComplete = false;
                while (!roundComplete && player.Health > 0 && player.MovesRemaining > 0)
                {
                    Console.Clear();

                    Console.WriteLine($"===== Round {round} OF 3 =======");
                    Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}");

                    Console.WriteLine($"Moves remaining: {player.MovesRemaining}");
                    Console.WriteLine($"Weapon: {player.EquippedWeapon}");
                    Console.WriteLine($"Attack damage: {player.GetAttackDamage()}");

                    if (monster.IsAlive)
                    {
                        Console.WriteLine($"Monster health: {monster.Health}");
                    }
                }
            }
            ///Here are the instruction for you to know.
            Console.WriteLine();

            Console.WriteLine("WASD = Move");
            Console.WriteLine("Space = Attack adjacent monster");
            Console.WriteLine("I = Open Inventory");
            Console.WriteLine("W = Weapon | H = Health potion");
            Console.WriteLine("E = Exit");

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.I)
            {
                player.UseInventoryItem();
                continue;
            }

            if (key == ConsoleKey.Spacebar)
            {
                if (!monster.IsAlive)
                {
                    Console.WriteLine("The Monster is Defeated!");
                    Console.ReadKey(true);
                    continue;
                }
                int distance = Math.Abs(player.X - monster.X) +
                    Math.Abs(player.Y - monster.Y);
                if (distance != 1)
                {
                    Console.WriteLine("Move next to the monster to attack!");
                    Console.ReadKey(true); continue;
                }
                if (!player.UseMove())
                    break;

                monster.TakeDamage(player.GetAttackDamage());
                Console.WriteLine($"You dealt {player.GetAttackDamage()} damage!");

                if (!monster.IsAlive) 
                {
                    Console.WriteLine("Monster defeated!");
                }
                else
                {
                    monster.MoveTowardsPlayer(maze, player);
                }
                if (monster.X == player.X && monster.Y == player.Y)
                {
                    monster.Attack(player);
                    Console.WriteLine($"The monster dealt {monster.Damage} damage!");

                    Console.WriteLine($"Health Remaining: {player.Health}");
                    if (player.Health > 0)
                        Console.ReadKey(true);
                    
                }
                int newX = player.X;
                int newY = player.Y;
                ///This is the buttons for you to use to move around.
                switch (key)
                {
                    case
                    ConsoleKey.W: newY--;
                        break;
                    case ConsoleKey.S: newY++;
                        break;
                    case ConsoleKey.A: newX--;
                        break;
                    case ConsoleKey.D: newX++;
                            break;
                }

                if (newX < 0 || newX >= maze.GetLength(1) || 
                    newY < 0 || newY >= maze.GetLength(0))
                {
                    continue;
                }

                if (maze[newY, newX] == '#') 
                    continue;

                if (!player.UseMove())
                    break;
                player.Move(newX, newY);
                if (GenerateMaze[newY, newX] == 'W')
                {
                    player.AddItem(new Weapon("Iron Sword", 15));
                    maze[newY, newX] = '.';
                    Console.WriteLine("You Found an Iron Sword!");
                    Console.ReadKey(true );
                }
                else if (maze[newY, newX == 'H'])
                {
                    player.AddItem(new Potion("Health Potion", 30));
                    maze[newY, newX] = '.';
                    Console.WriteLine("You Found a Health Potion!");
                    Console.ReadKey(true );
                }
                if (maze[player.Y, player.X] == 'E')
                {
                    roundComplete = true;
                    continue;
                }

            }
            Console.Clear();
            ///This is what will happen when you lose the game
            if (player.Health <= 0)
            {
                Console.WriteLine("GAME OVER!");
                Console.WriteLine("The Monster Defeated you!");

                Console.WriteLine($" You Reached round {round}");
                return;
            }
            if (!roundComplete)
            {
                Console.WriteLine("GAME OVER!");
                Console.WriteLine("You Ran Out of Moves");
                Console.WriteLine($"You Reached Round {round}.");
                return;
            }
            Console.WriteLine($"Round {round} completed!");
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}");

            if (round < 3)
            {
                Console.WriteLine("press any key to start the next round.");
                Console.ReadKey(true);
            }
            ///and this is what will show up when you win.
            Console.WriteLine();
            Console.WriteLine("Congratulations!");
            Console.WriteLine("You have completed all three rounds");
            Console.WriteLine($"Final health: {player.Health}");
            ///This is how the maze will generate and have all the things show up in the maze.
            static char[,] GenerateMaze(int width, int height, Random random)
            {
                char[,] maze = new char[width, height];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        maze[y, x] = '#';
                    }
                }

                Stack<(int x, int y)> stack = new Stack<(int x, int y)> ();
                maze[1, 1] = '.';
                stack.Push((1, 1));
                (int dx, int dy)[] directions =
                {
                    (0, -2),
                    (0, 2),
                    (-2, 0),
                    (2, 0),
                };

                while (stack.Count > 0)
                {
                    var current = stack.Peek();
                    List<(int x, int y, int dx, int dy)> options =
                        new List<(int x, int y, int dx, int dy)>();

                    foreach (var direction in directions)
                    {
                        int nx = current.x + direction.dx;
                        int ny = current.y + direction.dy;

                        if (nx > 0 && nx < width - 1 && ny > 0 && ny < height - 1 && maze[ny, nx] == '#')
                        {
                            options.Add((nx, ny, directions.dx, directions.dy));
                        }
                    }

                    if (options.Count == 0)
                    {
                        stack.Pop();
                        continue;
                    }

                    var chosen = options[random.Next(options.Count)];

                    maze[current.y + chosen.dy / 2, current.x + chosen.dx / 2] = '.';
                    maze[chosen.y, chosen.x] = '.';
                    stack.Push((chosen.x, chosen.y));

                    return maze;

                    ///This is to make sure the monster will spawn in a maze
                    static void (int x, int y, FindMonsterSpawn(char[,] maze), Random random)
                    {
                        List<(int x, int y)> choices = new List<(int x, int y)>();
                        int exitX = maze.GetLength(1) - 2;
                        int exitY = maze.GetLength(0) - 2;

                        for (int y = 1; y < maze.GetLength(0) - 1; y++)
                        {
                            for (int x = 1; x < maze.GetLength(1) - 1; x++)
                            {
                                int playerDistance = Math.Abs(x - 1) + Math.Abs(y - 1);

                                int exitDistance = Math.Abs(x - exitX) + Math.abs(y - exitY);
                                if (maze[y, x] == '.' && playerDistance >= 6 && exitDistance >= 4)
                                {
                                    choices.Add((x, y));
                                }
                            }
                        }
                    }
                    
                    if (choices.Count > 0)
                    {
                        return (maze.GetLength(1) - 2, 1);
                        return choices[random.Next(choices.Count)];
                    }
                    ///This is how it is going to place the random items to make sure you can get them.
                    static void PlaceRandomItem(char[,] maze, char symbol, Random Random)
                    {
                        List<(int x, int y)> choices = new List<(int x, int y)>();
                        for (int y = 1; y < maze.GetLength(0) - 1; y++)
                        {
                            for int x = 1; x < maze.GetLength(1) - 1; x++)
                            {
                                if (maze[y, x] == '.' && !(x == 1 && y == 1))
                                {
                                    choices.Add((x, y));
                                }
                            }
                        }

                        if (choices.Count == 0)
                            return;

                        var position = choices[Random.Next(choices.Count)];
                        maze[position.y, position.x] = symbol;
                    }
                    ///This will show you where you and the monster are on the maze
                    static void DrawMaze(char[,]maze, Player player, Monster monster)
                    {
                        for (int y = 0; y < maze.GetLength(0); y++)
                        {
                            for (int x = 0; x < maze.GetLength(1); x++)
                            {
                                if (x == player.X && y ==player.Y)
                                {
                                    Console.Write('P');
                                }
                                else if (monster.IsAlive && x == monster.X && y == monster.Y)
                                {
                                    Console.Write('M');
                                }
                                else
                                {
                                    Console.Write(maze[y, x]);
                                }
                            }
                        }
                        Console.WriteLine();
                    }



                }
                
               
                
            } 
           
        }
        
    }
}

using System;
using System.Linq;

namespace MarsRoverProblem
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            var maxPoints = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            var startPositions = Console.ReadLine().Trim().Split(' ');
            Position position = new Position();

            if (startPositions.Count() == 3)
            {
                position.X = Convert.ToInt32(startPositions[0]);
                position.Y = Convert.ToInt32(startPositions[1]);
                position.Direction = (Directions)Enum.Parse(typeof(Directions), startPositions[2]);
            }

            var moves = Console.ReadLine().ToUpper();

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'M':
                        position.MoveInSameDirection();
                        break;
                    case 'L':
                        position.Rotate90Left();
                        break;
                    case 'R':
                        position.Rotate90Right();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {move}");
                        break;
                }

                if (position.X < 0 || position.X > maxPoints[0] || position.Y < 0 || position.Y > maxPoints[1])
                {
                    Console.WriteLine($"Oops! Position can not be beyond bounderies (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                    break;
                }

                //Console.WriteLine($"{position.X} {position.Y} {position.Direction.ToString()}");
            }

            Console.WriteLine($"{position.X} {position.Y} {position.Direction.ToString()}");
            Console.ReadLine();
        }
    }
}

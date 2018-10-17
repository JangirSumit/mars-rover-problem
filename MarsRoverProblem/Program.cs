using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProblem
{
    public enum Directions
    {
        N = 1,//North
        S = 2,//South
        E = 3,//East
        W = 4//West
    }

    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public Directions direction { get; set; }

        public Position()
        {
            x = y = 0;
            direction = Directions.N;
        }

        public void UpdatePosition(int x, int y, Directions dir)
        {
            this.x = x;
            this.y = y;
            this.direction = dir;
        }

        public void Rotate90Left()
        {

        }

        public void Rotate90Right()
        {
            throw new NotImplementedException();
        }

        public void MoveInSameDirection()
        {
            switch (this.direction)
            {
                case Directions.N:
                    this.y += 1;
                    break;
                case Directions.S:
                    this.y -= 1;
                    break;
                case Directions.E:
                    this.x += 1;
                    break;
                case Directions.W:
                    this.x -= 1;
                    break;
                default:
                    break;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var maxPoints = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var startPositions = Console.ReadLine().Split(' ');
            Position position = new Position();

            if (startPositions.Count() == 2)
            {
                position = new Position
                {
                    x = Convert.ToInt32(startPositions[0]),
                    y = Convert.ToInt32(startPositions[1]),
                    direction = (Directions)Enum.Parse(typeof(Directions), startPositions[2])
                };
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
                        break;
                }
            }
        }
    }
}

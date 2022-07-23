using System;

namespace BoardGame
{
    public class BoardGame
    {
        public string RunGame(string steps)
        {
            if(string.IsNullOrWhiteSpace(steps))
            {
                throw new ArgumentException(nameof(steps));
            }
            char[] input = steps.ToCharArray();
            //Matrix size for 5 x 5
            // This values we can read  from console as input for nxn, in current scenario its 5 x 5
            int max = 4;
            int min = 0;
            // Directions
            char[] clockWiseDirection = { 'N', 'E', 'S', 'W' };
            char[] antiClockWiseDirection = { 'N', 'W', 'S', 'E' };
            //Startup direction.
            char currentDirection = 'N';
            // variable to show current direction with default values (0,0).
            int directionX = 0;
            int directionY = 0;
            foreach (var step in input)
            {
                switch (step)
                {
                    case 'R':
                        currentDirection = getDirection(clockWiseDirection, currentDirection);
                        break;
                    case 'L':
                        currentDirection = getDirection(antiClockWiseDirection, currentDirection);
                        break;
                    case 'M':
                        moveDirections(currentDirection, max, min, ref directionX, ref directionY);
                        break;
                }
            }
            return new string($"{directionX} {directionY} {currentDirection}");
        }

        /// <summary>
        /// Function to do movements based on board boundries.
        /// </summary>
        /// <param name="currentDirection"></param>
        /// <param name="directionX"></param>
        /// <param name="directionY"></param>
        private static void moveDirections(char currentDirection, int max, int min, ref int directionX, ref int directionY)
        {
            switch (currentDirection)
            {
                case 'N':
                    if (directionY < max)
                    {
                        directionY = directionY + 1;
                    }
                    break;
                case 'E':
                    if (directionX < max)
                    {
                        directionX = directionX + 1;
                    }
                    break;
                case 'S':
                    if (directionY > min)
                    {
                        directionY = directionY - 1;
                    }
                    break;
                case 'W':
                    if (directionX > min)
                    {
                        directionX = directionX - 1;
                    }
                    break;
            }
        }

        /// <summary>
        /// Method return's direction of pawn.
        /// </summary>
        /// <param name="directions"></param>
        /// <param name="currentDirection"></param>
        /// <returns></returns>
        private static char getDirection(char[] directions, char currentDirection)
        {
            int directionIndex = Array.IndexOf(directions, currentDirection);
            if (directionIndex == 3)
            {
                directionIndex = 0;
                currentDirection = directions[directionIndex];
            }
            else
            {
                currentDirection = directions[++directionIndex];
            }
            return currentDirection;
        }
    }
}

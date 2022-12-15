using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        const int MAXNOOFROLLS = 21;
        private int[] rolls = new int[MAXNOOFROLLS];

        private int currentRole = 0;
        public void Roll(int pins)
        {
            rolls[currentRole++] = pins;
            // Add your logic here. Add classes as needed.
        }

        public int GetScore()
        {
            int score = 0;
            int rollCounter = 0;
            const int MaxFrameCount = 10;
            for (int frame = 0; frame < MaxFrameCount; frame++)
            {
                if (IsSpare(rollCounter))
                {
                    score += 10 + GetSpareBonus(rollCounter);
                    rollCounter += 2;
                }
                else if (IsStrike(rollCounter))
                {
                    score += 10 + GetStrikeBonus(rollCounter);
                    rollCounter++;
                }
                else
                {
                    score += SunOfBallsInFrame(rollCounter);
                    rollCounter += 2;

                }

            }
            // Returns the final score of the game.
            return score;
        }

        private int GetSpareBonus(int rollCounter)
        {
            return rolls[rollCounter + 2];
        }

        private int GetStrikeBonus(int rollCounter)
        {
            return rolls[rollCounter + 1] + rolls[rollCounter + 2];
        }

        private int SunOfBallsInFrame(int rollCounter)
        {
            return rolls[rollCounter] + rolls[rollCounter + 1];
        }

        private bool IsStrike(int rollCounter)
        {
            return rolls[rollCounter] == 10;
        }

        private bool IsSpare(int rollCounter)
        {
            return rolls[rollCounter] + rolls[rollCounter + 1] == 10;
        }
    }
}


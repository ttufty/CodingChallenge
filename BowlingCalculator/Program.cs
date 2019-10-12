using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int throwOne, throwTwo = 0, prevFrame = 0, prevTwoFrame = 0, frameScore = 0, frame = 1, totalScore = 0, extraFrame;
            bool spare = false, strike = false, secondStrike = false;
                        
            for (; frame <= 10; frame ++)
            {
                if (frame > 1)
                {
                    Console.WriteLine("Total Score {0}:", totalScore);
                }

                Console.WriteLine("Please Enter your Scores for Frame {0}:", frame);
                do
                {
                    Console.Write("Throw 1:");
                    throwOne = int.Parse(Console.ReadLine());
                }
                while (throwOne > 10 || throwOne < 0);//checking for a valid score
                if (spare == true)// checking for a spare and adding the points
                {
                    prevFrame = 10 + throwOne;
                    spare = false;
                    totalScore = prevFrame + totalScore;
                }
                if (secondStrike == true && throwOne == 10) //checking fro 3 strikes in a row
                {
                    prevTwoFrame = 30;
                    secondStrike = false;
                    totalScore = prevTwoFrame + totalScore;
                }
                if (secondStrike == true && throwOne != 10) //checking for 2 strikes and a missed third
                {
                    prevTwoFrame = 10 + 10 + throwOne;
                    secondStrike = false;
                    totalScore = prevTwoFrame + totalScore;
                }
                if (strike == true && throwOne == 10) //checking for 2 strikes in a row
                {
                    secondStrike = true;
                    prevTwoFrame = 20;
                }

                if (throwOne < 10)// checking for strike on first throw
                {
                    do
                    {
                        Console.Write("Throw 2:");
                        throwTwo = int.Parse(Console.ReadLine());
                    }
                    while (throwTwo > (10 - throwOne) || throwTwo < 0);
                    if (throwOne + throwTwo == 10)// got a spare
                    {
                        spare = true;
                    }
                    if (secondStrike == true && frame == 10)//checking for 3 strikes in 10th frame
                    {
                        prevTwoFrame = 10 + 10 + throwTwo;
                        totalScore = prevTwoFrame + totalScore;
                        secondStrike = false;
                    }
                    if (strike == true && throwOne != 10)//strike on first throw and adding next two throws
                    {
                        prevFrame = 10 + throwOne + throwTwo;
                        totalScore = prevFrame + totalScore;
                        strike = false;                 
                    }
                    if (spare != true && strike != true && secondStrike != true)//no strike or spare made
                    {
                        frameScore = throwOne + throwTwo;
                        totalScore = frameScore + totalScore;
                    }
                }
                else
                {
                    // strike on the first throw
                    strike = true;
                    prevFrame = 10;
                }
                if (frame == 10 && strike == true)//tenth frame with a strike
                {
                    do
                    {
                        Console.Write("Extra frame:");
                        throwTwo = int.Parse(Console.ReadLine());
                    }
                    while (throwTwo > 10 || throwTwo < 0);
                    if (secondStrike == true)
                    {
                        prevTwoFrame = 10 + 10 + throwTwo;
                        totalScore = prevTwoFrame + totalScore;
                        secondStrike = false;
                        Console.WriteLine("Total Score {0}:", totalScore);
                    }
                }
                if (frame == 10 && (spare == true || strike == true))//tenth frame with spare or strike
                {
                    do
                    {
                        Console.Write("Extra frame:");
                        extraFrame = int.Parse(Console.ReadLine());
                    }
                    while (extraFrame > 10 || extraFrame < 0);
                    if (strike == true)
                    {
                        prevFrame = 10 + throwTwo + extraFrame;
                        totalScore = prevFrame + totalScore;
                        Console.WriteLine("Total Score {0}:", totalScore);
                    }
                    else
                    {
                        totalScore = totalScore + 10 + extraFrame;
                        Console.WriteLine("Total Score {0}:", totalScore);
                    }
                }
            }
        }
    }
}

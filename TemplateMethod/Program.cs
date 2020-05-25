﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            ScoringAlgorithm algorithm;
            Console.WriteLine("Men");
            algorithm = new MenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algorithm = new ChildrensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.ReadLine();
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);

            return CalculaterOverallScore(score, reduction);
        }

        public abstract int CalculaterOverallScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);        
    }

    class MenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculaterOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }

    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }

        public override int CalculaterOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }

    class ChildrensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }

        public override int CalculaterOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }
}

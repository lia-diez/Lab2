﻿using System;
using System.Linq;

namespace Lab2
{
    public class Teams
    {
        private int Points;
        private string Name;

        public string name
        {
            get
            {
                return Name;
            }
        }

        public int points
        {
            get
            {
                return Points;
            }
        }
        

        public Teams(string str)
        {
            string[] scores = str.Split(',');
            int points = 0;
            Name = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                int point1 = Int32.Parse(scores[i].Split(':')[0]);
                int point2 = Int32.Parse(scores[i].Split(':')[1]);
                if (point1>point2)
                {
                    points += 3;
                }else if (point1 == point2)
                {
                    points += 1;
                }
            }
            Points = points;
        }

        public  static string[] CreateResultingTable(Teams[] teams)
        {
            int[] points = teams.Select(a => a.points).ToArray();
            string[] names = teams.Select(a => a.name).ToArray();
            
            for (int i = 0; i < teams.Length; i++)
            {
                for (int j = i; j < teams.Length - 1; j++)
                {
                    if (teams[j].points < teams[j+1].points)
                    {
                        var temp = teams[j + 1];
                        teams[j + 1] = teams[j];
                        teams[j] = temp;
                    }       
                }
            }

            return teams.Select(a=> a.ToString()).ToArray();
            
            
        }
        public string ToString()
        {
            return $"Team name: {Name}, points: {Points}";
        }
    }
}
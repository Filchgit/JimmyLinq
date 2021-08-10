﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DocumentFormat.OpenXml.Bibliography;

namespace JimmyLinq
{
    public class Comic
    {
        public string Name { get; set; }
        public int IssueNumber { get; set; }
        public override string ToString() => $"{Name} Issue #{IssueNumber}";
        public static readonly IEnumerable<Comic> Catalog =
            new List<Comic>                                       // for some reason you can also leave off the () after Comic here and in construction below
        {
                new Comic{ Name = "Jonny America vs the Pinko", IssueNumber = 6 },
                new Comic{ Name = "Rock and Roll (limited edition)", IssueNumber = 19 },
                new Comic { Name = "Woman's Work", IssueNumber =36},
                new Comic { Name = "Hippie Madness (misprinted)", IssueNumber = 57},
                new Comic { Name = "Revenge of the New Wave Freak ( damaged)", IssueNumber = 68 },
                new Comic { Name = "Black Monday", IssueNumber =74 },
                new Comic { Name = "Tribal Madness", IssueNumber = 83 },
                new Comic { Name = "The Death of the Object", IssueNumber = 97}
        };
        public static readonly IReadOnlyDictionary<int, decimal> Prices =
            new Dictionary<int, decimal>                                          //() again these seem extraneous here
            {
                {6, 3600M },
                {19,500M },
                {36, 650M },
                {57, 13525M },        
                {68, 250M },
                {74, 75M },
                { 83, 25.75M },
                {97, 32.5M }
            };
        public static readonly IEnumerable<Review> Reviews = new[]
        {
            new Review(){Issue = 36, Critic = Critics.MuddyCritic, Score = 37.6 },
            new Review(){Issue = 74, Critic = Critics.RottenTornadoes, Score = 22.8 },
            new Review(){Issue = 74, Critic = Critics.MuddyCritic, Score = 84.2 },
            new Review(){Issue = 83, Critic = Critics.RottenTornadoes, Score = 89.4 },
            new Review(){Issue = 97, Critic = Critics.MuddyCritic, Score = 98.1 },
        };
    }
}
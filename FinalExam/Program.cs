using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExam
{
    public class Program
    {
        static void Main()
        {
            string inputCommand = string.Empty;

            Dictionary<string, List<string>> allBandsAndMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> allBandsPlayTime = new Dictionary<string, int>();

            while ((inputCommand = Console.ReadLine()) != "start of concert")
            {
                string[] currentCommand = inputCommand.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                if (currentCommand[0] == "Add")
                {
                    string currentBandToAdd = currentCommand[1];
                    string[] currentMembersToAdd = currentCommand[2].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                    if (!allBandsAndMembers.ContainsKey(currentBandToAdd) && !allBandsPlayTime.ContainsKey(currentBandToAdd))
                    {
                        allBandsAndMembers[currentBandToAdd] = new List<string>();
                        allBandsPlayTime[currentBandToAdd] = 0;

                        for (int i = 0; i < currentMembersToAdd.Length; i++)
                        {
                            if (!allBandsAndMembers[currentBandToAdd].Contains(currentMembersToAdd[i]))
                            {
                                allBandsAndMembers[currentBandToAdd].Add(currentMembersToAdd[i]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < currentMembersToAdd.Length; i++)
                        {
                            if (!allBandsAndMembers[currentBandToAdd].Contains(currentMembersToAdd[i]))
                            {
                                allBandsAndMembers[currentBandToAdd].Add(currentMembersToAdd[i]);
                            }
                        }
                    }
                }
                else if (currentCommand[0] == "Play")
                {
                    string currentBandWithPlayTime = currentCommand[1];

                    int currentBandPlayTime = int.Parse(currentCommand[2]);

                    if (!allBandsAndMembers.ContainsKey(currentBandWithPlayTime) && !allBandsPlayTime.ContainsKey(currentBandWithPlayTime))
                    {
                        allBandsAndMembers[currentBandWithPlayTime] = new List<string>();
                        allBandsPlayTime[currentBandWithPlayTime] = currentBandPlayTime;
                    }
                    else
                    {
                        allBandsPlayTime[currentBandWithPlayTime] += currentBandPlayTime;
                    }
                }
            }

            string bandToPrintMembers = Console.ReadLine();
            int totalBandTime = 0;

            foreach (var kvp in allBandsPlayTime)
            {
                totalBandTime += kvp.Value;
            }

            Console.WriteLine($"Total time: {totalBandTime}");

            foreach (var kvp in allBandsPlayTime.OrderByDescending(b => b.Value).ThenBy(b => b.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine(bandToPrintMembers);

            foreach (var kvp in allBandsAndMembers)
            {
                if (kvp.Key == bandToPrintMembers)
                {
                    foreach (var member in kvp.Value)
                    {
                        Console.WriteLine($"=> {member}");
                    }
                }
            }
        }
    }
}
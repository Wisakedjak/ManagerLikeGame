using System;
using System.Collections.Generic;
using UnityEngine;

namespace ManagerLikeGame
{
    [Serializable]
    public class Team 
    {
        public Team(string teamName, Sprite teamLogo, string teamBranch, Sprite teamBranchLogo, int teamOffence, int teamDefence, int teamSpeed, int teamStamina, int teamMorale, int teamPassing, int teamPrestige, List<Player> players)
        {
            TeamName = teamName;
            TeamLogo = teamLogo;
            TeamBranch = teamBranch;
            TeamBranchLogo = teamBranchLogo;
            TeamOffence = teamOffence;
            TeamDefence = teamDefence;
            TeamSpeed = teamSpeed;
            TeamStamina = teamStamina;
            TeamMorale = teamMorale;
            TeamPassing = teamPassing;
            TeamPrestige = teamPrestige;
            Players = players;
        }
        
        public int TeamPrestige { get; private set; }
        public string TeamName { get; private set; }

        public Sprite TeamLogo { get; private set; }
        
        public string TeamBranch { get; private set; }

        public Sprite TeamBranchLogo { get; private set; }

        public int TeamOffence { get; private set; }

        public int TeamDefence { get; private set; }

        public int TeamSpeed { get; private set; }

        public int TeamStamina { get; private set; }

        public int TeamMorale { get; private set; }
        
        public int TeamPassing { get; private set; }
        
        public List<Player> Players { get; private set; }

        public int TeamOverall => CalculateTeamOverall();
        
        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
        
        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
        
        public int CalculateTeamOverall()
        {
            int total = 0;
            foreach (var player in Players)
            {
                total += player.PlayerOverall;
            }

            return total / Players.Count;
        }
        
        public int CalculateTeamOffence()
        {
            int total = 0;
            foreach (var player in Players)
            {
                total += player.PlayerOffence;
            }

            return total / Players.Count;
        }
        
        public int CalculateTeamDefence()
        {
            int total = 0;
            foreach (var player in Players)
            {
                total += player.PlayerDefence;
            }

            return total / Players.Count;
        }
        
        public int CalculateTeamSpeed()
        {
            int total = 0;
            foreach (var player in Players)
            {
                total += player.PlayerSpeed;
            }

            return total / Players.Count;
        }
        
        public int CalculateTeamStamina()
        {
            int total = 0;
            foreach (var player in Players)
            {
                total += player.PlayerStamina;
            }

            return total / Players.Count;
        }
        
        public int CalculateTeamMorale()
        {
            int total = 0;
            foreach (var player in Players)
            {
                total += player.PlayerMorale;
            }

            return total / Players.Count;
        }
        
        public int CalculateTeamPassing()
        {
            int total = 0;
            foreach (var player in Players)
            {
                total += player.PlayerPassing;
            }

            return total / Players.Count;
        }
        
        public int IncreasePrestige(int value)
        {
            return TeamPrestige += value;
        }
        
        public int DecreasePrestige(int value)
        {
            return TeamPrestige -= value;
        }
    }
}
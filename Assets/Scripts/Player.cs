using System;
using UnityEngine;

namespace ManagerLikeGame
{
    [Serializable]
    public class Player 
    {
        public Player(string playerName, Sprite playerImage,string playerAge, string playerNationality,string playerJerseyNumber, Sprite playerTeamLogo, string playerBranch, Sprite playerBranchLogo, string playerPosition, Sprite playerPositionLogo, int playerOffence, int playerDefence, int playerSpeed, int playerStamina, int playerMorale, int playerPassing, int playerLeadership)
        {
            PlayerName = playerName;
            PlayerImage = playerImage;
            PlayerAge = playerAge;
            PlayerNationality = playerNationality;
            PlayerJerseyNumber = playerJerseyNumber;
            PlayerTeamLogo = playerTeamLogo;
            PlayerBranch = playerBranch;
            PlayerBranchLogo = playerBranchLogo;
            PlayerPosition = playerPosition;
            PlayerPositionLogo = playerPositionLogo;
            PlayerOffence = playerOffence;
            PlayerDefence = playerDefence;
            PlayerSpeed = playerSpeed;
            PlayerStamina = playerStamina;
            PlayerMorale = playerMorale;
            PlayerPassing = playerPassing;
            PlayerLeadership = playerLeadership;
        }
        
        public string PlayerName { get; private set; }
        
        public Sprite PlayerImage { get; private set; }
        
        public string PlayerAge { get; private set; }
        
        public string PlayerNationality { get; private set; }
        
        public string PlayerJerseyNumber { get; private set; }
        
        public Sprite PlayerTeamLogo { get; private set; }
        
        public string PlayerBranch { get; private set; }

        public Sprite PlayerBranchLogo { get; private set; }
        
        public string PlayerPosition { get; private set; }

        public Sprite PlayerPositionLogo { get; private set; }

        public int PlayerOffence { get; private set; }

        public int PlayerDefence { get; private set; }

        public int PlayerSpeed { get; private set; }

        public int PlayerStamina { get; private set; }

        public int PlayerMorale { get; private set; }
        
        public int PlayerPassing { get; private set; }
        
        public int PlayerLeadership { get; private set; }
        
        public int PlayerOverall => (PlayerOffence + PlayerDefence + PlayerSpeed + PlayerStamina + PlayerMorale + PlayerPassing + PlayerLeadership) / 7;

        public void IncreaseOffence(int value)
        {
            PlayerOffence += value;
        }
        
        public void IncreaseDefence(int value)
        {
            PlayerDefence += value;
        }
        
        public void IncreaseSpeed(int value)
        {
            PlayerSpeed += value;
        }
        
        public void IncreaseStamina(int value)
        {
            PlayerStamina += value;
        }
        
        public void IncreaseMorale(int value)
        {
            PlayerMorale += value;
        }
        
        public void IncreasePassing(int value)
        {
            PlayerPassing += value;
        }
        
        public void IncreaseLeadership(int value)
        {
            PlayerLeadership += value;
        }
        
        public void DecreaseOffence(int value)
        {
            PlayerOffence -= value;
        }
        
        public void DecreaseDefence(int value)
        {
            PlayerDefence -= value;
        }
        
        public void DecreaseSpeed(int value)
        {
            PlayerSpeed -= value;
        }
        
        public void DecreaseStamina(int value)
        {
            PlayerStamina -= value;
        }
        
        public void DecreaseMorale(int value)
        {
            PlayerMorale -= value;
        }
        
        public void DecreasePassing(int value)
        {
            PlayerPassing -= value;
        }
        
        public void DecreaseLeadership(int value)
        {
            PlayerLeadership -= value;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

namespace ManagerLikeGame
{
    public class SaveNLoadManager : MonoBehaviour
    {

        private void Start()
        {
            Sprite sprite = Resources.Load<Sprite>("PlaceHolderSprites/Tuncer");
            sprite.name = "Tuncer";
            Sprite teamSprite = Resources.Load<Sprite>("PlaceHolderSprites/Fenerbahce");
            teamSprite.name = "Fenerbahce";
            Sprite leagueSprite = Resources.Load<Sprite>("PlaceHolderSprites/SuperLig");
            leagueSprite.name = "SuperLig";
            League league = new League("Super Lig", leagueSprite, "Football", null, new List<Team>()
            { new Team("Fenerbahçe", teamSprite, "Football", null, 80, 70, 90, 85, 75
                , 85, 80, new List<Player>()
                {
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                },"4-4-2"),{ new Team("Beşiktaş", teamSprite, "Football", null, 80, 70, 90, 85, 75
                , 85, 80, new List<Player>()
                {
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                    new Player("Mahmut Tuncer",sprite, "31", "Turkey", "69",null, "Football", null, "FW", null, 75, 85, 80, 90, 70, 80, 85),
                }, "4-4-2")}});
            SaveLeagueData(league);
            
        }
        public List<PlayerData> datas = new List<PlayerData>(20);

        public void SaveLeagueData(League league)
        {
            LeagueData leagueData = new LeagueData
            {
                leagueName = league.Name,
                leagueLogo = league.Logo.name,
                leagueBranch = league.Branch,
                leagueBranchLogo = "league.BranchLogo.name",
                teams = new TeamData[league.Teams.Count]
            };
            for (int i = 0; i < league.Teams.Count; i++)
            {
                leagueData.teams[i] = SaveTeamData(league.Teams[i]);
            }
            string json = JsonUtility.ToJson(leagueData);
            string path = Application.persistentDataPath + "/"  + "LeagueData.json";
            File.WriteAllText(path, json);
        }
        private TeamData SaveTeamData(Team team)
        {
            TeamData teamData = new TeamData
            {
                teamName = team.TeamName,
                teamLogo = team.TeamLogo.name,
                teamBranch = team.TeamBranch,
                teamBranchLogo = "team.TeamBranchLogo.name",
                teamOffence = team.TeamOffence,
                teamDefence = team.TeamDefence,
                teamSpeed = team.TeamSpeed,
                teamStamina = team.TeamStamina,
                teamMorale = team.TeamMorale,
                teamPassing = team.TeamPassing,
                teamPrestige = team.TeamPrestige,
                players = new PlayerData[team.Players.Count],
                teamFormation = team.TeamFormation
            };
            for (int i = 0; i < team.Players.Count; i++)
            {
                teamData.players[i] = new PlayerData
                {
                    playerName = team.Players[i].PlayerName,
                    playerImage = team.Players[i].PlayerImage.name,
                    playerAge = team.Players[i].PlayerAge,
                    playerNationality = team.Players[i].PlayerNationality,
                    playerJerseyNumber = team.Players[i].PlayerJerseyNumber,
                    playerTeamLogo = "team.Players[i].PlayerTeamLogo.name",
                    playerBranch = team.Players[i].PlayerBranch,
                    playerBranchLogo = "team.Players[i].PlayerBranchLogo.name",
                    playerPosition = team.Players[i].PlayerPosition,
                    playerPositionLogo = "team.Players[i].PlayerPositionLogo.name",
                    playerOffence = team.Players[i].PlayerOffence,
                    playerDefence = team.Players[i].PlayerDefence,
                    playerSpeed = team.Players[i].PlayerSpeed,
                    playerStamina = team.Players[i].PlayerStamina,
                    playerMorale = team.Players[i].PlayerMorale,
                    playerPassing = team.Players[i].PlayerPassing,
                    playerLeadership = team.Players[i].PlayerLeadership
                };
            }
            
            /*string json = JsonUtility.ToJson(teamData);
            PlayerPrefs.SetString(teamData.teamName+"TeamData", json);*/

            return teamData;
        }
        
        public Team LoadTeamData(string teamName)
        {
            string json = PlayerPrefs.GetString(teamName+"TeamData");
            TeamData teamData = JsonUtility.FromJson<TeamData>(json);
            return CreateTeam(teamData);
        }
        
        private Team CreateTeam(TeamData teamData)
        {
            List<Player> players = new List<Player>();
            foreach (var playerData in teamData.players)
            {
                Sprite playerSprite= Resources.Load<Sprite>("PlaceHolderSprites/"+playerData.playerImage);
                players.Add(new Player(playerData.playerName,playerSprite, playerData.playerAge, playerData.playerNationality, playerData.playerJerseyNumber, null, playerData.playerBranch, null, playerData.playerPosition, null, playerData.playerOffence, playerData.playerDefence, playerData.playerSpeed, playerData.playerStamina, playerData.playerMorale, playerData.playerPassing, playerData.playerLeadership));
            }
            Sprite teamSprite = Resources.Load<Sprite>("PlaceHolderSprites/"+teamData.teamLogo);
            return new Team(teamData.teamName, teamSprite, teamData.teamBranch, null, teamData.teamOffence, teamData.teamDefence, teamData.teamSpeed, teamData.teamStamina, teamData.teamMorale, teamData.teamPassing, teamData.teamPrestige, players,teamData.teamFormation);
        }
    }
    
    [Serializable]
    public class LeagueData
    {
        public string leagueName;
        public string leagueLogo;
        public string leagueBranch;
        public string leagueBranchLogo;
        public TeamData[] teams;
    }
    
    [Serializable]
    public class TeamData
    {
        public string teamName;
        public string teamLogo;
        public string teamBranch;
        public string teamBranchLogo;
        public int teamOffence;
        public int teamDefence;
        public int teamSpeed;
        public int teamStamina;
        public int teamMorale;
        public int teamPassing;
        public int teamPrestige;
        public PlayerData[] players;
        public string teamFormation;
    }
    
    [Serializable]
    public class PlayerData
    {
        public string playerName;
        public string playerImage;
        public string playerAge;
        public string playerNationality;
        public string playerJerseyNumber;
        [CanBeNull] public string playerTeamLogo;
        public string playerBranch;
        [CanBeNull] public string playerBranchLogo;
        public string playerPosition;
        [CanBeNull] public string playerPositionLogo;
        public int playerOffence;
        public int playerDefence;
        public int playerSpeed;
        public int playerStamina;
        public int playerMorale;
        public int playerPassing;
        public int playerLeadership;
    }
}
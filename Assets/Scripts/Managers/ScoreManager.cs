using ManagerLikeGame;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    private Dictionary<string, TeamStats> _teamStats = new Dictionary<string, TeamStats>();

    public void InitializeTeams(List<Team> teams)
    {
        foreach (var team in teams)
        {
            _teamStats[team.TeamName] = new TeamStats(team.TeamName);
        }
    }

    public List<TeamStats> GetTeamStats()
    {
        return new List<TeamStats>(_teamStats.Values);
    }

    public void RegisterMatchResult(Team homeTeam, Team awayTeam, int homeGoals, int awayGoals)
    {
        TeamStats homeStats = _teamStats[homeTeam.TeamName];
        TeamStats awayStats = _teamStats[awayTeam.TeamName];

        homeStats.GamesPlayed++;
        awayStats.GamesPlayed++;

        homeStats.GoalsScored += homeGoals;
        awayStats.GoalsScored += awayGoals;

        homeStats.GoalsConceded += awayGoals;
        awayStats.GoalsConceded += homeGoals;

        if (homeGoals > awayGoals)
        {
            homeStats.Wins++;
            awayStats.Losses++;
            homeStats.Points += 3;
        }
        else if (homeGoals < awayGoals)
        {
            awayStats.Wins++;
            homeStats.Losses++;
            awayStats.Points += 3;
        }
        else
        {
            homeStats.Draws++;
            awayStats.Draws++;
            homeStats.Points += 1;
            awayStats.Points += 1;
        }
    }

    public void PrintLeagueTable()
    {
        List<TeamStats> sortedTeams = new List<TeamStats>(_teamStats.Values);
        sortedTeams.Sort((a, b) => b.Points.CompareTo(a.Points));

        Debug.Log(" LÝG TABLOSU:");
        foreach (var team in sortedTeams)
        {
            Debug.Log($"{team.TeamName} - Puan: {team.Points}, Oynanan: {team.GamesPlayed}, Galibiyet: {team.Wins}, Beraberlik: {team.Draws}, Maðlubiyet: {team.Losses}, Averaj: {team.GoalDifference()}");
        }
    }
}

public class TeamStats
{
    public string TeamName;
    public int GamesPlayed = 0;
    public int Wins = 0;
    public int Draws = 0;
    public int Losses = 0;
    public int GoalsScored = 0;
    public int GoalsConceded = 0;
    public int Points = 0;

    public TeamStats(string name)
    {
        TeamName = name;
    }

    public int GoalDifference()
    {
        return GoalsScored - GoalsConceded;
    }
}

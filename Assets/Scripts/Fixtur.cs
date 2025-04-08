using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ManagerLikeGame
{
    public class Fixtur : MonoBehaviour
    {
        private LeagueObject _leagueObject;
        private TeamObject _selectedTeam;  
        private List<Team> _opponents;  
        private int _currentMatchIndex = 0;  
        private ScoreManager _scoreManager; 


        public GameObject VersusPrefab;  
        public GameObject ScorePrefab;
        public Transform ScoreContent;
        public Transform VersusContent;  


        public List<List<(Team, Team)>> fixtureMatrix = new List<List<(Team, Team)>>();

        public void LeagueObjectSend(LeagueObject leagueObject, TeamObject selectedTeam)
        {
            _leagueObject = leagueObject;
            _selectedTeam = selectedTeam;
            _opponents = new List<Team>();

            print($"Toplam Takým Sayýsý: {_leagueObject.League.Teams.Count}");

            _scoreManager = new ScoreManager();
            _scoreManager.InitializeTeams(_leagueObject.League.Teams);

            GenerateFixture();
        }

        private void GenerateFixture()
        {
            List<Team> teams = new List<Team>(_leagueObject.League.Teams);
            ShuffleTeams(teams);

            int matchesPerRound = teams.Count / 2;
            int totalRounds = teams.Count - 1;

            

            for (int round = 0; round < totalRounds; round++)
            {
                List<(Team, Team)> roundMatches = new List<(Team, Team)>();

                for (int match = 0; match < matchesPerRound; match++)
                {
                    Team homeTeam = teams[match];
                    Team awayTeam = teams[teams.Count - 1 - match];

                    roundMatches.Add((homeTeam, awayTeam));

                    GameObject matchItem = Instantiate(VersusPrefab, VersusContent);
                    Text leftText = matchItem.transform.Find("Left").GetComponent<Text>();
                    Text rightText = matchItem.transform.Find("Right").GetComponent<Text>();

                    leftText.text = homeTeam.TeamName;
                    rightText.text = awayTeam.TeamName;

                    if (homeTeam.TeamName == _selectedTeam.Team.TeamName)
                    {
                        leftText.color = Color.red;
                        _opponents.Add(awayTeam); 
                    }
                    else if (awayTeam.TeamName == _selectedTeam.Team.TeamName)
                    {
                        rightText.color = Color.red;
                        _opponents.Add(homeTeam);
                    }
                }

                Team lastTeam = teams[teams.Count - 1];
                teams.RemoveAt(teams.Count - 1);
                teams.Insert(1, lastTeam);

                ShowOpponent(_opponents[_currentMatchIndex]);
                fixtureMatrix.Add(roundMatches);
            }

            
        }



        public void PlayNextMatch()
        {
            if (_currentMatchIndex < fixtureMatrix.Count)
            { 
                PlayMatchesInRound(fixtureMatrix, _currentMatchIndex);
                _currentMatchIndex++; 
                ShowOpponent(_opponents[_currentMatchIndex]);
            }
            else
            {
                Debug.Log("Tüm maçlar oynandý!");
                _scoreManager.PrintLeagueTable();
            }

        }

        public void PlayMatchesInRound(List<List<(Team, Team)>> fixtureMatrix, int currentIndexMatch)
        {
            List<(Team, Team)> round = fixtureMatrix[currentIndexMatch];

            Debug.Log($"Hafta {currentIndexMatch + 1}:");

            for (int matchIndex = 0; matchIndex < round.Count; matchIndex++)
            {
                var match = round[matchIndex];
                Team homeTeam = match.Item1;
                Team awayTeam = match.Item2;

                Debug.Log($"Maç: {homeTeam.TeamName} vs {awayTeam.TeamName}");

                int homeGoals = Random.Range(0, 6);
                int awayGoals = Random.Range(0, 6); 

                _scoreManager.RegisterMatchResult(homeTeam, awayTeam, homeGoals, awayGoals);

                Debug.Log($"Sonuç: {homeTeam.TeamName} {homeGoals} - {awayGoals} {awayTeam.TeamName}");

                
            }


        }

        public void UpdateScoreboard()
        {
            List<TeamStats> sortedTeams = new List<TeamStats>(_scoreManager.GetTeamStats());
            sortedTeams.Sort((a, b) => b.Points.CompareTo(a.Points));

            foreach (Transform child in ScoreContent)
            {
                Destroy(child.gameObject);
            }

            foreach (var teamStats in sortedTeams)
            {
                GameObject scoreItem = Instantiate(ScorePrefab, ScoreContent);

                Text teamNameText = scoreItem.transform.Find("TeamsName").GetComponent<Text>();
                Text pointsText = scoreItem.transform.Find("TeamsScore").GetComponent<Text>();
                Text goalsText = scoreItem.transform.Find("TeamsGoal").GetComponent<Text>();

                teamNameText.text = teamStats.TeamName;
                pointsText.text = teamStats.Points.ToString();
                goalsText.text = teamStats.GoalsScored.ToString();
            }

        }

        private void ShowOpponent(Team opponent)
        {
            Debug.Log($"Rakip takým: {opponent.TeamName}");
        }




        private void ShuffleTeams(List<Team> teams)                                                                                      
        {
            System.Random random = new System.Random();
            int n = teams.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Team temp = teams[k];
                teams[k] = teams[n];
                teams[n] = temp;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ManagerLikeGame
{
    public class GameManager : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] private SaveNLoadManager saveNLoadManager;
        [SerializeField] private UIManager uiManager;
        [SerializeField] private TeamMainMenuManager teamMainMenuManager;

        [SerializeField] private List<Team> teams=new List<Team>();
        [SerializeField] private List<League> leagues=new List<League>();

        private Team selectedTeam;
        

        private void Awake()
        {
            uiManager.Subscriptions();
        }

        private void Start()
        {
            Subscriptions();
            LoadLeagues();
            LoadTeams();
        }

        private void Subscriptions()
        {
            uiManager.OnPlayButtonClicked += OnPlayButtonClicked;
            uiManager.OnTeamsButtonClicked += OnTeamsButtonClicked;
            uiManager.OnContinueButtonClicked += OnContinueButtonClicked;
        }

        private void LoadTeams()
        {
            Team team = saveNLoadManager.LoadTeamData("Fenerbahçe");
            teams.Add(team);
        }

        private void LoadLeagues()
        {
            League league = saveNLoadManager.LoadLeagueData();
            leagues.Add(league);
        }

        private void OnTeamsButtonClicked()
        {
            uiManager.CreateTeams(teams);
        }

        private void OnPlayButtonClicked()
        {
            if (uiManager.SelectedTeam==null)
            {
                Debug.Log("Please select a league");
                uiManager.CreateLeagues(leagues);
                return;
            }
            Debug.Log("Play button clicked");
            
        }
        
        private void OnContinueButtonClicked()
        {
            selectedTeam = GetSelectedTeam();
            uiManager.ContinueAfterTeamSelect();
            teamMainMenuManager.SetTeam(selectedTeam);
        }
        
        private Team GetSelectedTeam()
        {
            return uiManager.SelectedTeam.Team;
        }
    }
    
    //TODO: Lose prestige when other team win with handicap
}
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

        [SerializeField] private List<Team> teams=new List<Team>();
        

        private void Awake()
        {
            uiManager.Subscriptions();
        }

        private void Start()
        {
            Subscriptions();
            LoadTeams();
        }

        private void Subscriptions()
        {
            uiManager.OnPlayButtonClicked += OnPlayButtonClicked;
            uiManager.OnTeamsButtonClicked += OnTeamsButtonClicked;
        }

        private void LoadTeams()
        {
            Team team = saveNLoadManager.LoadTeamData("Fenerbahçe");
            teams.Add(team);
        }

        private void OnTeamsButtonClicked()
        {
            uiManager.CreateTeams(teams);
        }

        private void OnPlayButtonClicked()
        {
            if (uiManager.SelectedTeam==null)
            {
                Debug.Log("Please select a team");
                uiManager.CreateTeams(teams);
                return;
            }
            Debug.Log("Play button clicked");
            
        }
    }
    
    //TODO: Lose prestige when other team win with handicap
}
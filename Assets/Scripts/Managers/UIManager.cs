using System;
using System.Collections.Generic;
using ManagerLikeGame.UIControllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace ManagerLikeGame
{
    public class UIManager : MonoBehaviour
    {
        [Header("Serialize Fields")] 
        [SerializeField] private Button playButton;
        [SerializeField] private Button teamsButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private GameObject substitutePlayerGo;
        [SerializeField] private Transform formations;
        
        [Header("Canvases")]
        [SerializeField] private GameObject mainMenuCanvas;
        [SerializeField] private GameObject matchCanvas;
        
        [Header("Panels")] 
        [SerializeField] private GameObject teamPanel;
        [SerializeField] private GameObject leaguePanel;
        [SerializeField] private GameObject rosterPanel;
        [SerializeField] private GameObject schedulePanel;
        [SerializeField] private GameObject betPanel;

        [Header("Fixtur")]
        [SerializeField] private Fixtur _fixtur;
        
        private LeagueObject _leagueObject;

        private TeamPanelController _teamPanelController;
        private LeaguePanelController _leaguePanelController;
        public TeamObject SelectedTeam{get; private set;}
        
        
        public event Action OnPlayButtonClicked;
        public event Action OnTeamsButtonClicked;
        public event Action OnContinueButtonClicked;


        public void Subscriptions()
        {
            playButton.onClick.AddListener(PlayButtonClicked);
            teamsButton.onClick.AddListener(TeamsButtonClicked);
            continueButton.onClick.AddListener(ContinueButtonClicked);
            for (int i = 0; i < formations.childCount; i++)
            {
                var button = formations.GetChild(i).GetComponent<Button>();
                var formation = button.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                button.onClick.AddListener(() => ChangeFormation(formation));
            }
            GetComponents();
        }
        
        private void GetComponents()
        {
            _teamPanelController = teamPanel.GetComponent<TeamPanelController>();
            _leaguePanelController = leaguePanel.GetComponent<LeaguePanelController>();
        }
        
        private void PlayButtonClicked()
        {
            OnPlayButtonClicked?.Invoke();
        }
        
        private void TeamsButtonClicked()
        {
            OnTeamsButtonClicked?.Invoke();
        }

        private void ContinueButtonClicked()
        {
            OnContinueButtonClicked?.Invoke();
        }

        public void CreateLeagues(List<League> leagues)
        {
            print(leagues.Count);
            foreach (var l in leagues)
            {
                CreateLeague(l);
            }
            OpenCloseLeaguePanel(true);
        }

        private void CreateLeague(League league)
        {
            _leaguePanelController.CreateLeague(league).OnSelectButtonClicked += OnLeagueSelectButtonClicked;
        }

        public void CreateTeams(List<Team> teams)
        {
            foreach (var t in teams)
            {
                CreateTeam(t);
            }
            OpenCloseTeamsPanel(true);
        }

        private void OpenCloseTeamsPanel(bool open)
        {
            teamPanel.SetActive(open);
        }
        
        private void OpenCloseLeaguePanel(bool open)
        {
            leaguePanel.SetActive(open);
        }
        

        public void OpenCloseRosterPanel(bool open)
        {
            rosterPanel.SetActive(open);
        }

        public void OpenCloseSchedulePanel(bool open)
        {
            schedulePanel.SetActive(open);
        }

        public void OpenCloseBetPanel(bool open)
        {
             betPanel.SetActive(open);
        }
        
        private void CreateTeam(Team team)
        {
            _teamPanelController.CreateTeam(team).OnSelectButtonClicked+= OnTeamSelectButtonClicked;
            
        }

        private void OnTeamSelectButtonClicked(TeamObject teamObject)
        {
            /*if (SelectedTeam==teamObject)
            {
                return;
            }*/
            if (SelectedTeam != null)
            {
                SelectedTeam.selectedImage.SetActive(false);
            }
            SelectedTeam = teamObject;
            SelectedTeam.selectedImage.SetActive(true);
            _teamPanelController.DestroyAll();
            _teamPanelController.CreatePlayer(teamObject.Team);
        }
        
        private void ChangeFormation(string formation)
        {
            SelectedTeam.Team.TeamFormation = formation;
            OnTeamSelectButtonClicked(SelectedTeam);
        }
        
        private void OnLeagueSelectButtonClicked(LeagueObject leagueObject)
        {
            CreateTeams(leagueObject.League.Teams);
            OpenCloseLeaguePanel(false);
            OpenCloseTeamsPanel(true);
            _leagueObject = leagueObject;
        }

        public void ContinueAfterTeamSelect()
        {
            OpenCloseTeamsPanel(false);
            OpenCloseLeaguePanel(false);
            _fixtur.LeagueObjectSend(_leagueObject, SelectedTeam);
        }
    }
}
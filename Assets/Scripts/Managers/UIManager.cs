using System;
using System.Collections.Generic;
using ManagerLikeGame.UIControllers;
using UnityEngine;
using UnityEngine.UI;


namespace ManagerLikeGame
{
    public class UIManager : MonoBehaviour
    {
        [Header("Serialize Fields")] 
        [SerializeField] private Button playButton;
        [SerializeField] private Button teamsButton;
        [SerializeField] private GameObject substitutePlayerGo;
        
        
        [Header("Canvases")]
        [SerializeField] private GameObject mainMenuCanvas;
        [SerializeField] private GameObject matchCanvas;
        
        [Header("Panels")] 
        [SerializeField] private GameObject teamPanel;
        

        private TeamPanelController _teamPanelController;
        public TeamObject SelectedTeam{get; private set;}
        
        
        public event Action OnPlayButtonClicked;
        public event Action OnTeamsButtonClicked;
        
        public void Subscriptions()
        {
            playButton.onClick.AddListener(PlayButtonClicked);
            teamsButton.onClick.AddListener(TeamsButtonClicked);
            GetComponents();
        }
        
        private void GetComponents()
        {
            _teamPanelController = teamPanel.GetComponent<TeamPanelController>();
        }
        
        private void PlayButtonClicked()
        {
            OnPlayButtonClicked?.Invoke();
        }
        
        private void TeamsButtonClicked()
        {
            OnTeamsButtonClicked?.Invoke();
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
        
        private void CreateTeam(Team team)
        {
            _teamPanelController.CreateTeam(team).OnSelectButtonClicked+= OnSelectButtonClicked;
            
        }

        private void OnSelectButtonClicked(TeamObject teamObject)
        {
            if (SelectedTeam==teamObject)
            {
                return;
            }
            if (SelectedTeam != null)
            {
                SelectedTeam.selectedImage.SetActive(false);
            }
            SelectedTeam = teamObject;
            SelectedTeam.selectedImage.SetActive(true);
            int counter = 0;
            foreach (var t in teamObject.Team.Players)
            {
                if (counter<11)
                {
                    _teamPanelController.CreatePlayer(t);
                    counter++;
                    continue;
                }
                _teamPanelController.CreateSubstitutePlayer(t);
            }
        }
    }
}
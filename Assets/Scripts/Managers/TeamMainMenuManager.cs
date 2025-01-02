using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ManagerLikeGame
{
    public class TeamMainMenuManager : MonoBehaviour
    {
        [Header("Serialize Fields")]
        [SerializeField] private GameObject teamMainMenuPanel;
        [SerializeField] private Image teamLogo;
        [SerializeField] private TextMeshProUGUI teamName;
        
        private Team team { get; set; }
        
        public void SetTeam(Team team)
        {
            this.team = team;
            Initialize();
        }

        private void Initialize()
        {
            OpenCloseTeamMainPanel(true);
            teamLogo.sprite = team.TeamLogo;
            teamName.text = team.TeamName;
        }
        
        private void OpenCloseTeamMainPanel(bool open)
        {
            teamMainMenuPanel.SetActive(open);
        }
    }
}
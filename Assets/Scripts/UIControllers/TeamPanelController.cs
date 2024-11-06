using System;
using UnityEngine;

namespace ManagerLikeGame.UIControllers
{
    public class TeamPanelController : MonoBehaviour
    {
        [Header("Serialize Fields")]
        [SerializeField] private GameObject substitutePlayerPrefab;
        [SerializeField] private Transform substitutePlayerParent;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject teamPrefab;
        [SerializeField] private Transform teamParent;
        
        public void CreateSubstitutePlayer(Player player)
        {
            PlayerSubstituteObject playerSubstituteGo = Instantiate(substitutePlayerPrefab, substitutePlayerParent).GetComponent<PlayerSubstituteObject>();
            playerSubstituteGo.SetPlayer(player);
        }
        
        public void CreatePlayer(Player player)
        {
            PlayerObject playerGo = Instantiate(playerPrefab, substitutePlayerParent).GetComponent<PlayerObject>();
            playerGo.SetPlayer(player);
        }

        public TeamObject CreateTeam(Team playerTeam)
        {
            TeamObject teamGo = Instantiate(teamPrefab, teamParent).GetComponent<TeamObject>();
            teamGo.SetTeam(playerTeam);
            return teamGo;
        }

        private void OnDisable()
        {
            foreach (Transform child in substitutePlayerParent)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in teamParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
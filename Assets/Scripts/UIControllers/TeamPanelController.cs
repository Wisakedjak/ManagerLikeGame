using System;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private List<Transform> formationPositions=new List<Transform>();
        
        private List<GameObject> players = new List<GameObject>();

        public void CreatePlayer(Team team)
        {
            var formation = CheckFormation(team.TeamFormation);
            int formationIndex = formation.Count-4;
            int index = 0;
            for (var i = 0; i < formation.Count; i++)
            {
                var t = formation[i];
                for (int j = 0; j < t; j++)
                {
                    PlayerObject go = Instantiate(playerPrefab, formationPositions[formationIndex].GetChild(i).transform)
                        .GetComponent<PlayerObject>();
                    players.Add(go.gameObject);
                    go.SetPlayer(team.Players[index]);
                    index++;
                }
            }

            for (int i = index; i < team.Players.Count; i++)
            {
                PlayerSubstituteObject substituteGo = Instantiate(substitutePlayerPrefab, substitutePlayerParent).GetComponent<PlayerSubstituteObject>();
                substituteGo.SetPlayer(team.Players[index]);
            }
        }

        public TeamObject CreateTeam(Team playerTeam)
        {
            TeamObject teamGo = Instantiate(teamPrefab, teamParent).GetComponent<TeamObject>();
            teamGo.SetTeam(playerTeam);
            return teamGo;
        }
        
        private List<int> CheckFormation(string formation)
        {
           var split = formation.Split('-').Select(int.Parse).ToList();
           split.Reverse();
           split.Add(1);
           split.Reverse();
           return split;
        }
        

        public void DestroyAll()
        {
            foreach (Transform child in substitutePlayerParent)
            {
                Destroy(child.gameObject);
            }

            DestroyAllPlayers();
        }

        private void DestroyAllPlayers()
        {
            foreach (var player in players)
            {
                Destroy(player);
            }

            players.Clear();
        }

        private void OnDisable()
        {
            DestroyAll();
            foreach (Transform child in teamParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
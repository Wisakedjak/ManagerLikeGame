using System.Collections.Generic;
using UnityEngine;

namespace ManagerLikeGame
{
    public class League
    {
        public League(string name, Sprite logo, string branch, Sprite branchLogo, List<Team> teams)
        {
            Name = name;
            Logo = logo;
            Branch = branch;
            BranchLogo = branchLogo;
            Teams = teams;
        }

        public string Name { get; private set; }

        public Sprite Logo { get; private set; }

        public string Branch { get; private set; }

        public Sprite BranchLogo { get; private set; }

        public List<Team> Teams { get; private set; }
    }
}
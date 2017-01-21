using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Gui.GamesLogic
{
    /// <summary>
    /// Simple object thats needed for the object to move with the LevelController.
    /// </summary>
    public class LevelObject : MonoBehaviour
    {
        private const float outofLevelY = 2;
        private Boolean isKillingItself = false;

        void start()
        {
            
        }

        void Update()
        {
        }
    }
}

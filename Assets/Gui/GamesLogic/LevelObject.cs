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
        private const float outofLevelY = -10;
        private Transform parentTransform;
        private Boolean shouldRemoveItself = false;

        void Update()
        {
            if (shouldRemoveItself && parentTransform.position.y + this.transform.position.y < outofLevelY)
            {
                shouldRemoveItself = true;
                GoKillYourself();
            }    
        }

        public void SetParentTransform(Transform parent)
        {
            this.parentTransform = parent;
        }

        private void GoKillYourself()
        {
            UnityEngine.Object.Destroy(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Gui.GamesLogic
{
    /// <summary>
    /// A really simple class for spawning objects so they always spawn
    /// at specific points.
    /// </summary>
    public class SpawnPoint : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        void Start()
        {
            spriteRenderer = this.GetComponent<SpriteRenderer>();
            if (spriteRenderer)
            {
                spriteRenderer.enabled = true; //Only shown in editor
            }
        }
        void Update()
        {
            
        }
    }
}

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
        private const float outofLevelY = 10;
        public float speedX;
        public float speedY;
        
        private MeshRenderer meshRenderer;
        private Rigidbody2D body;
        private Vector2 velocity;


        public Boolean isGood = true;

        void Start()
        {
            this.meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
            this.body = this.gameObject.GetComponent<Rigidbody2D>();
            this.body.velocity = new Vector2(speedX, -speedY);
        }

        void Update()
        {
            //updateMovement();
            //Todo: Remove when out of the world!
        }

        private void updateMovement()
        {
            velocity = this.body.velocity;
            velocity.y += speedX;
            velocity.y += speedY;
            this.body.velocity = velocity;
        }

        
    }
}

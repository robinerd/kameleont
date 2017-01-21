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
        private Vector2 velocity;
        private Vector3 position;

        public Boolean isGood = true;
        private Slurpable slurpAbleCheck;

        void Start()
        {
            this.meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
            this.slurpAbleCheck = this.gameObject.GetComponent<Slurpable>();

            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
            //this.body = this.gameObject.GetComponent<Rigidbody2D>();
            //this.body.velocity = new Vector2(speedX, -speedY);
        }

        void Update()
        {
            if (slurpAbleCheck != null)
            {
                if (!slurpAbleCheck.isAttached)
                {
                    position = this.transform.position;
                    position.y -= speedY;
                    this.transform.position = position;
                }
            }
            else
            {
                position = this.transform.position;
                position.y -= speedY;
                this.transform.position = position;
            }
            
            //updateMovement();
            //Todo: Remove when out of the world!
        }

        //private void updateMovement()
        //{
        //    velocity = this.body.velocity;
        //    velocity.y += speedX;
        //    velocity.y += speedY;
        //    this.body.velocity = velocity;
        //}

        
    }
}

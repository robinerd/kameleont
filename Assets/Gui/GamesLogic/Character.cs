using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Gui.GamesLogic
{
    public class Character : MonoBehaviour
    {
        public float speedLeft;
        public float speedRight;

        public float minX;
        public float maxX;

        private float movementCooldown = 0f;
        public float movementWaitPerClick;

        private Rigidbody2D body;
        
        public Character()
        {
            this.body = gameObject.GetComponent<Rigidbody2D>();
            Console.WriteLine("body:", body);
            var test = 2;
        }

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            updateMovementCooldown();
            updateMovement();
            updateTongue();
        }

        private void updateMovementCooldown()
        {
            if (movementCooldown > 0f)
            {
                this.movementCooldown -= Time.deltaTime;
                if (this.movementCooldown < 0f)
                    this.movementCooldown = 0;
            }
        }

        private void updateMovement()
        {
            bool left = Input.GetButtonDown("MoveLeft");
            bool right = Input.GetButtonDown("MoveRight");

            //No movement if both, making sure of it with zeh code!
            if (movementCooldown <= 0)
            {
                if ((left && right) == false)
                {
                    if (left)
                    {
                        goLeft();
                    }
                    else if (right)
                    {
                        goRight();
                    }
                }
            }
        }

        private void goLeft()
        {
            movementCooldown = movementWaitPerClick;
            this.body.velocity = new Vector2(this.body.velocity.x - speedLeft, this.body.velocity.y);
            //this.transform.position = new Vector3(this.transform.position.x - speedLeft, this.transform.position.y, this.transform.position.z);
        }

        private void goRight()
        {
            movementCooldown = movementWaitPerClick;
            //this.transform.position = new Vector3(this.transform.position.x + speedRight, this.transform.position.y, this.transform.position.z);
        }

        private void updateTongue()
        {
            //Robin does awesome magic here
        }
    }
}

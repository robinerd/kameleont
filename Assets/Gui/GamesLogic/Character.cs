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
       
        public float movementWaitPerClick;
        public float velocityReduce;


        private Vector2 velocity;
        private float startY;
        private Boolean resetSpeedOnReverse = false;

        private float movementCooldown = 0f;

        private Rigidbody2D body;

        public float xMin;
        public float xMax;
        private float xDivider = 1.2f;

        void Start()
        {
            this.body = gameObject.GetComponent<Rigidbody2D>();
            startY = this.transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            velocity = this.body.velocity;
            velocity.y = 0;
            updateMovementCooldown();
            updateMovement();
            alwaysReduceSpeed();
            //keepY();
            updateTongue();

            //Debug.Log("this.transform.position.x: " + this.transform.position.x);
            //Cheap camera control
            if (this.transform.position.x < xMin)
            {
                this.velocity.x = speedRight / xDivider;
            }

            else if (this.transform.position.x > xMax)
            {
                this.velocity.x = -speedLeft / xDivider;
            }

            this.body.velocity = velocity;
            //Debug.Log("speed: " + this.body.velocity.x);
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
            if (resetSpeedOnReverse && velocity.x > 0)
                velocity.x = 0;
            velocity.x -= speedLeft; //Todo: Use time.delta here?

            if (velocity.x >= 0 && velocity.x < speedRight) //To stop the dead in its tracks movement
                velocity.x = -speedLeft;

            //this.body.velocity = new Vector2(this.body.velocity.x - speedLeft, this.body.velocity.y);
            //this.transform.position = new Vector3(this.transform.position.x - speedLeft, this.transform.position.y, this.transform.position.z);
        }

        private void goRight()
        {
            movementCooldown = movementWaitPerClick;
            if (resetSpeedOnReverse && velocity.x < 0)
                velocity.x = 0;
            velocity.x += speedRight; //Todo: Use time.delta here?

            if (velocity.x <= 0 && velocity.x > -speedLeft) //To stop the dead in its tracks movement
                velocity.x = speedRight;

            //this.transform.position = new Vector3(this.transform.position.x + speedRight, this.transform.position.y, this.transform.position.z);
        }

        private void keepY()
        {
            //this.body.position = new Vector2(this.body.position.x, this.body.position.y);v
            Vector3 pos = this.transform.position;
            pos.y = startY;
            this.transform.position = pos;
        }

        private void alwaysReduceSpeed()
        {
            //Shitty if cases, but aint got no time to use cool unity stuff!
            if (velocity.x < 0)
            {
                this.velocity.x += velocityReduce * Time.deltaTime;
                if (this.velocity.x > 0)
                    this.velocity.x = 0;
            }
            else if (this.velocity.x > 0)
            {
                this.velocity.x -= velocityReduce * Time.deltaTime;
                if (this.velocity.x < 0)
                    this.velocity.x = 0;
            }
        }

        private void updateTongue()
        {
            //Robin does awesome magic here
        }
    }
}

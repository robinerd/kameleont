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
            updateMovement();

            //Debug.Log("this.transform.position.x: " + this.transform.position.x);
            //Cheap camera control

            if ((this.transform.position.x < xMin && velocity.x < 0) ||
                (this.transform.position.x > xMax && velocity.x > 0))
            {
                this.velocity.x = 0;
            }
            this.body.velocity = velocity;
            //Debug.Log("speed: " + this.body.velocity.x);
        }

        private void updateMovement()
        {
            bool left = Input.GetButton("MoveLeft");
            bool right = Input.GetButton("MoveRight");

            //No movement if both, making sure of it with zeh code!
            velocity.x = 0;
            if ((left && right) == false)
            {
                if (left)
                {
                    velocity.x = -speedLeft; //Todo: Use time.delta here?
                }
                else if (right)
                {
                    velocity.x = speedRight; //Todo: Use time.delta here?
                }
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Obstacle"))
            {
                FlowMeter.flow -= 20;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Gui.GamesLogic
{
    public class StoneCollideChecker: MonoBehaviour
    {
        private Boolean hasCollided = false;
        static int argh = 0;
        private Rigidbody2D body;

        void Start()
        {
            this.body = gameObject.GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter(Collision col)
        {
            //Debug.Log("collision!: " + argh++);
            Debug.Log("collison: " + argh + " -: " + col.transform.position);

            if (col.gameObject.name == "ChameleonTMP")
            {
            }

            // Debug-draw all contact points and normals
            foreach (ContactPoint contact in col.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.green);
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("2d: " + argh + " -: " + col.transform.position);

            //Debug.Log("2d: " + argh++);

            if (col.gameObject.name == "ChameleonTMP")
            {
            }

            // Debug-draw all contact points and normals
            //foreach (ContactPoint contact in col.contacts)
            //{
            //    Debug.DrawRay(contact.point, contact.normal, Color.green);
            //}
        }


        //void OnCollisionEnter2D(Collision2D col)
        //{
        //    if (!hasCollided)
        //    {
        //        if (col.gameObject.name == "ChameleonTMP" || col.gameObject.name == "Character")
        //        {
        //            if (this.gameObject.transform.position.y >= -0.20 && this.gameObject.transform.position.y < -0.30f)
        //            {
        //                hasCollided = true;
        //                Debug.Log("Character has collided with a stone!: " + col.gameObject.name);
        //                Debug.Log("this: " + this.transform.position + " col: " + col.gameObject.transform.position);
        //                FlowMeter.LoseEverything();
        //                GameObject.Destroy(this.gameObject);
        //            }
        //        }
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Gui.GamesLogic
{
    public class StoneCollideChecker: MonoBehaviour
    {
        Tongue tongueRoot;
        void Start()
        {
            tongueRoot = GameObject.FindObjectOfType<Tongue>();
        }

        void Update() {
            Collider col = GetComponent<Collider>();
            if(col && col.bounds.Contains(tongueRoot.transform.position))
            {
                tongueRoot.HitObstacle();
                this.enabled = false;
            }
        }
    }
}

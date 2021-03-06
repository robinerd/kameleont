﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Gui.GamesLogic
{
    public class LevelMover : MonoBehaviour
    {
        private float movementY = 0.1f;
        private float outOfScreenY = 10;
        private Vector3 position;
        private LevelObject[] children;

        public void IncreaseSpeed(float speed)
        {
            //Todo, add timer to music, causes level to move faster over time?
            this.movementY += speed;
        }
        void Start()
        {
            setupChildren();
        }

        private void setupChildren()
        {
            children = gameObject.GetComponentsInChildren<LevelObject>();
        }

        void Update()
        {
            //Movement of Level
            this.position = transform.position;
            this.position.y -= movementY;
            this.transform.position = position;
        }
    }
}

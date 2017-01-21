using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Gui.GamesLogic
{
    public class LevelController : MonoBehaviour
    {
        private float movementY = 0.1f;
        private Vector3 position;

        public void IncreaseSpeed(float speed)
        {
            //Todo, add timer to music, causes level to move faster over time?
            this.movementY += speed;
        }
        void Start()
        {
            parentChildren();
        }

        private void parentChildren()
        {
            var children = gameObject.GetComponentsInChildren<LevelObject>();
            Console.WriteLine("count: ", children.Length);
            foreach (var child in children)
            {
                child.SetParentTransform(this.transform);
                //child.transform.SetParent(this.transform);
                Console.WriteLine("child: ", child);

            }
        }

        void Update()
        {
            this.position = transform.position;
            this.position.y -= movementY;
            this.transform.position = position;
        }
    }
}

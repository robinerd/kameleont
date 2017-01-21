using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Gui.GamesLogic
{
    public class LevelSpawner: MonoBehaviour
    {
        private int percentageGoodRequired = 20;
        private float cooldownSpawn = 0;

        public float cooldownPerSpawn;

        public List<LevelObject> listGoodItems;
        public List<LevelObject> listEvilItems;

        void Start()
        {
            
        }

        void Update()
        {
            cooldownSpawn -= Time.deltaTime;
            if (cooldownSpawn <= 0)
            {
                cooldownSpawn = cooldownPerSpawn;
                SpawnRandomObject();
            }
        }

        public void SpawnRandomObject()
        {
            int chance = Random.Range(0, 100);

            //Debug.Log("Spawning object with chance: " + chance);

            if (chance > percentageGoodRequired)
            {
                SpawnGood();
            }
            else
            {
                SpawnEvil();
            }

        }

        public void SpawnGood()
        {
            
        }

        private void SpawnEvil()
        {
            
        }
    }
}

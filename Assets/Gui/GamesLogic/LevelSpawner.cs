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

        public List<SpawnPoint> listSpawnPoints;

        //private List<LevelObject> listChildren;

        private Boolean spawnForward = true; //false = reverse

        private int spawnIndex;

        void Start()
        {
            //listChildren = new List<LevelObject>();
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

        private void checkChildrenPos()
        {

            //foreach (var child in listChildren)
            //{
            //    if (child.transform.position.y <= 0)
            //    {
            //        UnityEngine.Object.Destroy(child.gameObject);
            //    }
            //}
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
            int rand = 0;
            try
            {
                rand = Random.Range(0, listGoodItems.Count);
                //Debug.Log("Good rand: " + rand);
                LevelObject newObj = UnityEngine.Object.Instantiate(listGoodItems[rand]);
                SetPos(newObj);
            }
            catch(Exception e)
            {
                Debug.Log("good crash!: " + e.ToString());
                Debug.Log("index: " + rand);
                Debug.Log("items: " + listGoodItems.Count);
            }
        }

        private void SpawnEvil()
        {
            int rand = 0;
            try
            {
                rand = Random.Range(0, listEvilItems.Count);
                //Debug.Log("Evil rand: " + rand);
                LevelObject newObj = UnityEngine.Object.Instantiate(listEvilItems[rand]);
                SetPos(newObj);
            }
            catch (Exception e)
            {
                Debug.Log("Evil crash!: " + e.ToString());
                Debug.Log("index: " + rand);
                Debug.Log("items: " + listEvilItems.Count);
            }
        }

        private void SetPos(LevelObject newObj)
        {
            newObj.transform.position = listSpawnPoints[spawnIndex].transform.position;
            newObj.transform.rotation = new Quaternion(0, 0, 0, 1);

            if (spawnForward)
            {
                spawnIndex++; //Forward
            }
            else
            {
                spawnIndex--; //Reverse
            }

            if (spawnIndex >= listSpawnPoints.Count)
            {
                spawnIndex = 0;
            }
            else if (spawnIndex < 0)
            {
                spawnIndex = 0;
            }
        }
    }
}

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
        private int percentageGoodRequired = 5;
        private float cooldownSpawn = 0;

        public float cooldownPerSpawn;

        public List<LevelObject> listGoodItems;
        public List<LevelObject> listNeutral;
        public List<LevelObject> listEvilItems;

        public List<SpawnPoint> listSpawnPoints;

        //private List<LevelObject> listChildren;

        private bool spawnForward = false; //false = reverse
        private bool spawnRandom = true; //false = reverse

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
                int chanceStone = Random.Range(0, 10);
                if (chanceStone == 1) //10% to spawn a stone!
                {
                    SpawnNeutral();
                }
                else
                {
                    SpawnEvil();
                }
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
            catch (Exception e)
            {
                Debug.Log("good crash!: " + e.ToString());
                Debug.Log("index: " + rand);
                Debug.Log("items: " + listGoodItems.Count);
            }
        }

        public void SpawnNeutral()
        {
            //Stones and stuff
            int rand = 0;
            try
            {
                rand = Random.Range(0, listNeutral.Count);
                LevelObject newObj = UnityEngine.Object.Instantiate(listNeutral[rand]);
                SetPos(newObj);
            }
            catch (Exception e)
            {
                Debug.Log("neutral crash!: " + e.ToString());
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
                spawnIndex = listSpawnPoints.Count - 1;
            }

            if(spawnRandom)
            {
                //Ignore above things and overwrite with randomness
                spawnIndex = Random.Range(0, listSpawnPoints.Count); //NOTE that the second parameter is EXCLUSIVE
            }
        }

        public void EatAndIncreaseSpawnSpeed(float scoreAdd)
        {
            //Current score values range from 5 to 25, so this sort of makes sense
            if (scoreAdd > 0)
            {
                cooldownPerSpawn -= (scoreAdd/1000);
                Debug.Log("Cooldown per spawn shortened by: " + scoreAdd / 500);
                if (cooldownPerSpawn <= 0.05f)
                    cooldownPerSpawn = 0.05f;
            }
            else
            {
                //No reducing of cooldown when eating bad stuff!
                //That's for whuzzis!
                ////Eating bad stuff increases cooldown a bit less
                //cooldownPerSpawn -= (scoreAdd/1000);
                //if (cooldownPerSpawn > 3)
                //    cooldownPerSpawn = 3;
                Debug.Log("Cooldown per spawn increased by: " + scoreAdd / 1000);
            }

            percentageGoodRequired += 3; //Per candy!
            if (percentageGoodRequired >= 70)
            {
                percentageGoodRequired = 70; //at least 10% chance to get candy!
            }

            Debug.Log("Cooldown:  " + cooldownPerSpawn);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [Header("ZombieSpawn Var")]
    public GameObject zombiePrefab;
    public Transform[] zombieSpawnPosition;
    public GameObject dangerZone;
    private float repeatCycle = 1f;
    public int zombieToSpawn;

    [Header("Sound")]
    public AudioClip dangerZoneSound;
    public AudioSource audioSource;

    //private void Start()
    //{
    //    StartCoroutine(Spawn());
    //}

    //IEnumerator Spawn()
    //{
    //    int count = 0;

    //    if (gameObject.tag == "Player")
    //    {
    //        while (count < zombieToSpawn)
    //        {
    //            int randomIndex = Random.Range(0, zombieSpawnPosition.Length);

    //            GameObject obj = Instantiate(zombieSpawnPosition[randomIndex]);

    //            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));

    //            obj.transform.position = child.position;

    //            yield return new WaitForSeconds(1f);

    //            count++;
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner", 1f, repeatCycle);
            audioSource.PlayOneShot(dangerZoneSound);
            StartCoroutine(dangerZoneTimer());
            //Destroy(gameObject, 5f);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator EnemySpawner()
    {
        int count = 0;

        if (gameObject.tag == "Player")
        {
            while (count < zombieToSpawn)
            {
                int randomIndex = Random.Range(0, zombieSpawnPosition.Length);

                Transform obj = Instantiate(zombieSpawnPosition[randomIndex]);

                Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));

                obj.transform.position = child.position;

                yield return new WaitForSeconds(1f);

                count++;
            }
        }

        //int zombieToSpawn = Mathf.RoundToInt(Random.Range(0f, zombieSpawnPosition.Length - 1));
        Instantiate(zombiePrefab, zombieSpawnPosition[zombieToSpawn].transform.position, zombieSpawnPosition[zombieToSpawn].transform.rotation);
        //Instantiate(zombiePrefab, zombieSpawnPosition[zombieToSpawn].transform.position, Quaternion.identity);
    }

    IEnumerator dangerZoneTimer()
    {
        dangerZone.SetActive(true);
        yield return new WaitForSeconds(5f);
        dangerZone.SetActive(false);
    }
}

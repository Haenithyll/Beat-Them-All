using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnnemyPrefab,Character;
    MainGame MainGame;
    public int Round=0;
    int numberofennemy=0;
    bool _spawnEnnemie = true;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        MainGame = GameObject.FindWithTag("MainGame").GetComponent<MainGame>();
        
    }

    private void Update() {

        Round=MainGame.round_nbr;
        if(numberofennemy>Round*10)
        {
            _spawnEnnemie=false;
            MainGame.round_nbr++;
            StartCoroutine(WaitBeforeDestroy());  
        }
    }
    IEnumerator SpawnRoutine()
    {
        while(_spawnEnnemie)
        {
            yield return new WaitForSeconds(2f);
            numberofennemy++;
            int spawnpoint = Random.Range(0, 2);
            if(spawnpoint==0)
            {
                Instantiate(EnnemyPrefab, new Vector3(-4, 0.3f, 13), Quaternion.identity);
            }
            else
            {
                Instantiate(EnnemyPrefab, new Vector3(4.6f, 0.3f, 8.5f), Quaternion.identity);
            }
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
}

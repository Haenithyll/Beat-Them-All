using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    public GameObject player,SpawnManager;
    public int round_nbr=1;
    GameObject actualSpawner;
    Text round;
    int actualRound=0;
    private void Awake() {
        Instantiate(player, new Vector3(0, 3, 0), Quaternion.identity);
    }

    private void Start() {
        round = GameObject.FindWithTag("Round_nbr").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if(round_nbr==5)
        {
            Win();
        }
        if(player.activeSelf!)
        {
            GameOver();
        }
        {

        }
        if(actualRound!=round_nbr){
            actualRound=round_nbr;
            round.text=actualRound.ToString();
            Debug.Log("Round "+actualRound);
            actualSpawner=Instantiate(SpawnManager, gameObject.transform.position, Quaternion.identity);
            actualSpawner.GetComponent<SpawnManager>().Round=round_nbr;
        }

    }

    void Win()
    {}
    void GameOver()
    {}
}

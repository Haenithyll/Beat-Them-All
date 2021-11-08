using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public GameObject player,SpawnManager;

    GameObject actualSpawner,character;
    //Rounds
    [System.NonSerialized]
    public int round_nbr=1;
    Text round;
    int actualRound=0;
    //Scene to load
    public string Win_scene;
    public string GameOver_scene;
    //
    private void Awake() {
        character=Instantiate(player, new Vector3(0, 3, 0), Quaternion.identity);
        Cursor.visible = false;
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
        if(!character.activeSelf)
        {
            GameOver();
        }
        {

        }
        if(actualRound!=round_nbr){
            actualRound=round_nbr;
            round.text=actualRound.ToString();
            actualSpawner=Instantiate(SpawnManager, gameObject.transform.position, Quaternion.identity);
            actualSpawner.GetComponent<SpawnManager>().Round=round_nbr;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuBeatEmAll");
        }

    }

    void Win()
    {
        SceneManager.LoadScene(Win_scene);
    }
    void GameOver()
    {
        SceneManager.LoadScene(GameOver_scene);
    }
}

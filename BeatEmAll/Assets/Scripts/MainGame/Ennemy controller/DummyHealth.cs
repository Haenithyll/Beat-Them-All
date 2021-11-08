using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealth : MonoBehaviour, IDamageable
{
    public int startingHealth = 4;
    public float HitTime = 0.1f;
    private int currentHealth;
    public Color HitColor;

    [SerializeField]
    private GameObject Explosion;
    Color actualcolor;

    //Round info
    int actual_round;

    private void Awake() {
        actual_round= GameObject.FindWithTag("MainGame").GetComponent<MainGame>().round_nbr;
    }
    void Start()
    {
        currentHealth = startingHealth*actual_round;
        actualcolor = GetComponentInChildren<Renderer>().material.color;
    }

    public void Damage(int damage, Vector3 hitPoint)
    {
        currentHealth -= damage;

        GetComponentInChildren<Renderer>().material.SetColor("_Color", HitColor);
        StartCoroutine(WaitAndRecolor(actualcolor));
        ;

        if (currentHealth <= 0) 
        {
            Defeated();
        }
    }

    void Defeated()
    {
        Destroy(gameObject);
        Instantiate(Explosion,gameObject.transform.position,Quaternion.identity);
    }
    
    private IEnumerator WaitAndRecolor(Color col) {
        {
            yield return new WaitForSeconds(HitTime);
            GetComponentInChildren<Renderer>().material.SetColor("_Color",actualcolor);
        }
    }
}

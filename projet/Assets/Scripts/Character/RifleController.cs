using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RifleController : MonoBehaviour
{

    public float range = 50;
    public int damage = 1,ammo=30;
    public Text my_text;
    private Camera fpsCam;
    private Image ImageColor;
    private void Awake()
    {
        my_text= GameObject.FindWithTag("Ammo").GetComponent<Text>();
        my_text.text=ammo.ToString();
        fpsCam = GetComponentInChildren<Camera>();
        ImageColor = GameObject.FindWithTag("CrossHair").GetComponent<Image>();
    }

    void Update()
    {
        my_text.text=ammo.ToString();
        RaycastHit hit;
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
        {
            Debug.DrawLine(rayOrigin, hit.point, Color.red);
            if (hit.transform.tag == "Ennemy")
            {
                ImageColor.color = Color.red;
            }
            else
            {
                ImageColor.color = Color.white;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && ammo>0)
            {
                IDamageable dmgScript = hit.collider.gameObject.GetComponent<IDamageable>();

                ammo--;

                if (dmgScript != null)
                {
                    dmgScript.Damage(damage, hit.point);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * 200f);
                }

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ammo=30;
            }
        }



    }
}
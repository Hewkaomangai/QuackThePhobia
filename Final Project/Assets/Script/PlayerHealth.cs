using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] HP;
    public static int hpValue = 3;
    public static bool IsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hpValue == 3)
        {
            HP[0].SetActive(true);
            HP[1].SetActive(true);
            HP[2].SetActive(true);
        }
        else if (hpValue == 2)
        {
            HP[0].SetActive(true);
            HP[1].SetActive(true);
            HP[2].SetActive(false);
        }
        else if (hpValue == 1)
        {
            HP[0].SetActive(true);
            HP[1].SetActive(false);
            HP[2].SetActive(false);
        }
        else if (hpValue == 0)
        {
            HP[0].SetActive(false);
            HP[1].SetActive(false);
            HP[2].SetActive(false);
        }
    }

    
}

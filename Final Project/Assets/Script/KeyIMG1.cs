using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyIMG1 : MonoBehaviour
{
    public GameObject keyIMG1, keyIMG2, keyIMG3, keyIMG4, keyIMG5, keyIMG6;
    // Start is called before the first frame update
    void Start()
    {
        keyIMG1.SetActive(false);
        keyIMG2.SetActive(false);
        keyIMG3.SetActive(false);
        keyIMG4.SetActive(false);
        keyIMG5.SetActive(false);
        keyIMG6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Key1.hasKey01 == true)
        {
            keyIMG1.SetActive(true);
        }
        if (Key1.hasKey02 == true)
        {
            keyIMG2.SetActive(true);
            Debug.Log("ShowKey2");
        }
        if (Key1.hasF2KEY == true)
        {
            keyIMG3.SetActive(true);
        }
        if (Key1.hasF2KEY1 == true)
        {
            keyIMG4.SetActive(true);
        }
        if (Key1.hasF2KEY2 == true)
        {
            keyIMG5.SetActive(true);
        }
        if (Key1.hasF2KEY3 == true)
        {
            keyIMG6.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key1 : MonoBehaviour
{
    public GameObject Key;
    public static bool hasKey01, hasKey02, hasF2KEY, hasF2KEY1, hasF2KEY2, hasF2KEY3 = false;

    private bool inRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CompareTag("Key1") && inRange == true)
        {
            Key.SetActive(false);
            hasKey01 = true;
            Debug.Log("Key1");
        }
        else if
        (Input.GetKeyDown(KeyCode.E) && CompareTag("Key2") && inRange == true)
        {
            Key.SetActive(false);
            hasKey02 = true;
            Debug.Log("Key2");
        }
        else if
        (Input.GetKeyDown(KeyCode.E) && CompareTag("F2KEY") && inRange == true)
        {
            Key.SetActive(false);
            hasF2KEY = true;
            Debug.Log("Key3");
        }
        else if
        (Input.GetKeyDown(KeyCode.E) && CompareTag("F2KEY1") && inRange == true)
        {
            Key.SetActive(false);
            hasF2KEY1 = true;
            Debug.Log("Key4");
        }
        else if
        (Input.GetKeyDown(KeyCode.E) && CompareTag("F2KEY2") && inRange == true)
        {
            Key.SetActive(false);
            hasF2KEY2 = true;
            Debug.Log("Key5");
        }
        else if
        (Input.GetKeyDown(KeyCode.E) && CompareTag("F2KEY3") && inRange == true)
        {
            Key.SetActive(false);
            hasF2KEY3 = true;
            Debug.Log("Key6");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
}

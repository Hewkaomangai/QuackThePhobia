using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    public GameObject ItemFrame;
    public GameObject Item;
    public bool itemInRange;
    public static bool isStun;
    // Start is called before the first frame update
    void Start()
    {
        itemInRange = false;
        isStun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CompareTag("Heal") && Input.GetKeyUp(KeyCode.E) && itemInRange == true)
        {
            Item.SetActive(false);
            HealBar.hpValue += 1;
        }
        else if (CompareTag("Stun") && Input.GetKeyDown(KeyCode.E) && itemInRange == true)
        {  
            StartCoroutine(setStun());
        }
        else if (CompareTag("Stun2") && Input.GetKeyDown(KeyCode.E) && itemInRange == true)
        {
            StartCoroutine(setStun());
        }
    }

    private IEnumerator setStun()
    {
        Item.SetActive(false);
        isStun = true;
        yield return new WaitForSeconds(5f);
        isStun = false;
        Debug.Log("not stun");
        ItemFrame.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        itemInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        itemInRange = false;
    }
}

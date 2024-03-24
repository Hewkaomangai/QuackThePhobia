using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject Door;
    public Animator animatorDoorOpen;
    private bool inRange = false;

    void Start()
    {
        inRange = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasKey01 == true && CompareTag("Door1"))
        {
            animatorDoorOpen.SetBool("openDoor", true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasKey01 == false && CompareTag("Door1"))
        {
            UnityEngine.Debug.Log("You don't have KEY1");
        }
        if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasKey02 == true && CompareTag("Door2"))
        {
            animatorDoorOpen.SetBool("openDoor", true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasKey02 == false && CompareTag("Door2"))
        {
            UnityEngine.Debug.Log("You don't have KEY2");
        }
        if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasF2KEY == true && CompareTag("Door3"))
        {
            animatorDoorOpen.SetBool("openDoor", true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasF2KEY == false && CompareTag("Door3"))
        {
            UnityEngine.Debug.Log("You don't have Floor 2 Entrance Key");
        }
        if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasF2KEY1 == true && CompareTag("Door4"))
        {
            animatorDoorOpen.SetBool("openDoor", true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasF2KEY1 == false && CompareTag("Door4"))
        {
            UnityEngine.Debug.Log("You don't have Floor 2 Key 1");
        }
        if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasF2KEY2 == true && CompareTag("Door5"))
        {
            animatorDoorOpen.SetBool("openDoor", true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasF2KEY2 == false && CompareTag("Door5"))
        {
            UnityEngine.Debug.Log("You don't have Floor 2 Key 2");
        }
        if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasF2KEY3 == true && CompareTag("Door6"))
        {
            animatorDoorOpen.SetBool("openDoor", true);
            DoorWarp.isWarp = true;
            Key1.hasKey01 = false;
            Key1.hasKey02 = false;
            Key1.hasF2KEY = false;
            Key1.hasF2KEY1 = false;
            Key1.hasF2KEY2 = false;
            Key1.hasF2KEY3 = false;
            StartCoroutine(SetDelay());
        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasF2KEY3 == false && CompareTag("Door6"))
        {
            UnityEngine.Debug.Log("You don't have Floor 2 Key 3");
        }
        if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasKey01 == true && Key1.hasKey02 == true && Key1.hasF2KEY == true && Key1.hasF2KEY1 == true && Key1.hasF2KEY2 == true && Key1.hasF2KEY3 == true && CompareTag("DoorM2"))
        {
            animatorDoorOpen.SetBool("openDoor", true);
            animatorDoorOpen.SetBool("openDoor", true);
            DoorWarp.isWarp = true;
            Key1.hasKey01 = false;
            Key1.hasKey02 = false;
            Key1.hasF2KEY = false;
            Key1.hasF2KEY1 = false;
            Key1.hasF2KEY2 = false;
            Key1.hasF2KEY3 = false;
            StartCoroutine(SetDelay2());

        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange == true && Door && Key1.hasKey01 == false && Key1.hasKey02 == false && Key1.hasF2KEY == false && Key1.hasF2KEY1 == false && Key1.hasF2KEY2 == false && Key1.hasF2KEY3 == false && CompareTag("DoorM2"))
        {
            UnityEngine.Debug.Log("You don't have all Key");
        }
    }

    private IEnumerator SetDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Scene2");
    }

    private IEnumerator SetDelay2()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("CS2");
    }
    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("In");
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        UnityEngine.Debug.Log("Out");
        inRange = false;
    }
}

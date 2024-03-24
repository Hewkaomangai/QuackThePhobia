using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWarp : MonoBehaviour
{
    private bool inRange = false;
    public static bool isWarp = false;

    public int plusX, plusY, plusZ;
    public GameObject Player;
    public GameObject Door;
    public CharacterController isActive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
        {
            isWarp = true;
            StartCoroutine(SetDelay());
        }
    }

    private IEnumerator SetDelay()
    {
        yield return new WaitForSeconds(1.5f);
        isActive.enabled = false;
        Player.transform.position = new Vector3(Door.transform.position.x - plusX, Door.transform.position.y, Door.transform.position.z - plusZ);
        isActive.enabled = true;
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

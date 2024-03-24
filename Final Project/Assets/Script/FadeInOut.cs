using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public static bool Fadein;
    public GameObject black;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        black.SetActive(false);
        Fadein = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(DoorWarp.isWarp == true)
        {
            In();
        }
    }

    private IEnumerator DelayFade()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("Fadein", false);
        animator.SetBool("Fadeout", true);
        Fadein = false;
        black.SetActive(false);
        Debug.Log("Out");
        
    }

    private void In()
    {
        black.SetActive(true);
        Fadein = true;
        animator.SetBool("Fadein", true);
        animator.SetBool("Fadeout", false);
        Debug.Log("In");
        StartCoroutine(DelayFade());
        DoorWarp.isWarp = false;
    }
}

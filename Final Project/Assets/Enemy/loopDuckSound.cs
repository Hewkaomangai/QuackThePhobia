using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopDuckSound : MonoBehaviour
{
    public AudioSource Duckaudio;

    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(LoopAudio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoopAudio()
    {
        Duckaudio = GetComponent<AudioSource>();
        float length = Duckaudio.clip.length;
        int randomNumber = UnityEngine.Random.Range(5, 15);

        while (true)
        {
            Duckaudio.Play();
            yield return new WaitForSeconds(randomNumber);
        }
    }
}

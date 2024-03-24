using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public List<AudioClip> playerWalk;
    public AudioSource playerSource;
    public int pos;

    public static PlayerWalk instance;
    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playWalking()
    {
        pos = (int)Mathf.Floor(Random.Range(0, playerWalk.Count));
        playerSource.PlayOneShot(playerWalk[pos]);
    }
}

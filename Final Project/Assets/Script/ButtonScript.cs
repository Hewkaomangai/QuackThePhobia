using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject UI_Start, UI_Credit;

    // Start is called before the first frame update
    void Start()
    {
        UI_Start.SetActive(true);
        UI_Credit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene("CS1");
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonCredit()
    {
        UI_Start.SetActive(false);
        UI_Credit.SetActive(true);
    }

    public void ButtonCreditBack()
    {
        UI_Start.SetActive(true);
        UI_Credit.SetActive(false);
    }
}

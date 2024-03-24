using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript_Game : MonoBehaviour
{
    public GameObject UI_Died, UI_Pause, UI_Game;
    public static bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        UI_Died.SetActive(false);
        UI_Pause.SetActive(false);
        UI_Game.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isPause == false)
        {
            PauseGame();
        }
        if (HealBar.hpValue <= 0 || FieldOfView.isDead == true || FieldOfView.isDead == true)
        {
            DeadGame();
        }
    }

    public void DeadGame()
    {
        UI_Died.SetActive(true);
        UI_Pause.SetActive(false);
        UI_Game.SetActive(false);
        isPause = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PauseGame()
    {
        UI_Died.SetActive(false);
        UI_Pause.SetActive(true);
        UI_Game.SetActive(false);
        isPause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        UI_Died.SetActive(false);
        UI_Pause.SetActive(false);
        UI_Game.SetActive(true);
        isPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPause = false;
        HealBar.hpValue = 3;
        FieldOfView.isDead = false;
        FieldOfView1.isDead = false;
        PlayerHealth.IsDead = false;
        Key1.hasKey01 = false;
        Key1.hasKey02 = false;
        Key1.hasF2KEY = false;
        Key1.hasF2KEY1 = false;
        Key1.hasF2KEY2 = false;
        Key1.hasF2KEY3 = false;
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene("Title");
        isPause = false;
    }
}

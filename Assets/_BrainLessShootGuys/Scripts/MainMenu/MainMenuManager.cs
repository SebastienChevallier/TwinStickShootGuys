using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{ 
    public Button[] mainMenuButton;
    public GameObject[] mainMenuGameObjects;
    private Animator[] mainMenuAnim;

    void Start()
    {
        mainMenuAnim = new Animator[mainMenuGameObjects.Length];
        for (int i = 0; i < mainMenuGameObjects.Length; i++)
        {
            mainMenuGameObjects[i].SetActive(true);
            mainMenuAnim[i] = mainMenuGameObjects[i].GetComponent<Animator>();
        }
        UpdateSubMenu(0);
    }

    public void UpdateSubMenu(int i)
    {
        EventSystem.current.SetSelectedGameObject(null);
        for (int j = 0; j < mainMenuButton.Length; j++)
        {
            if (j == i)
            {
                mainMenuGameObjects[j].SetActive(true);
                EventSystem.current.SetSelectedGameObject(mainMenuButton[j].gameObject);
            }
            else
            {
                mainMenuGameObjects[j].SetActive(false);
            }
        }

        foreach (Animator anim in mainMenuAnim)
        {
            anim.SetBool("start", false);
        }
    }
}

using UnityEngine;

public class UI_Tools : MonoBehaviour
{
    private PlayerMovement player;
    public Transform layoutParent;
    public GameObject prefabStat;
    public GameObject panel;
    public bool panelOpen = false;

    private void Start()
    {
        player = GameObject.FindAnyObjectByType<PlayerMovement>();

        foreach(PairStat st in player._stats._Stats)
        {
            GameObject go = Instantiate(prefabStat, layoutParent);

            if(go.TryGetComponent(out UI_Stat ui))
            {
                ui.SetupStat(st);
            }
        }

        panel.SetActive(panelOpen);
    }

    public void OpenMenu()
    {
        if(panelOpen)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
}

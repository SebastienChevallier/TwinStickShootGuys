using UnityEngine;
using UnityEngine.UIElements;

public class UIMoveRect : MonoBehaviour
{
    public PlayerMovement player;
    public Vector3[] positions;
    private Animator animator;
    public bool[] invertUI;

    void Start()
    {
        PlayerMovement[] players = FindObjectsOfType<PlayerMovement>();
        animator = GetComponent<Animator>();
        for (int i = 0; i < players.Length; i++)
        {
            transform.localPosition = positions[i];
            //animator.SetBool("inverted", invertUI);
        }
    }
}

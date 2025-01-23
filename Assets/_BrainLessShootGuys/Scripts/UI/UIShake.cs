using System.Collections;
using UnityEngine;

public class UIShake : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShakeUI()
    {
        animator.CrossFade("UI_Shake", 0);
    }
}
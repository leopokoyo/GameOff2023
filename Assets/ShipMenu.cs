using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMenu : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenMenu()
    {
        animator.SetBool("isActive", true);
    }

    public void CloseMenu()
    {
        animator.SetBool("isActive", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILisetenerStone : MonoBehaviour
{
    private UIProgressBar progressBar;

    private void Awake()
    {
        progressBar = FindObjectOfType<UIProgressBar>();
       
    }

    private void OnDestroy()
    {
        if (progressBar != null) progressBar.BarHit();
    }
}

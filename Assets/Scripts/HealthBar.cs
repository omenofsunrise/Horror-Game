using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
 
    public Image bar;
    public float fill;

    private void Start()
    {
        fill = 1f;
    }

    private void Update()
    {
        bar.fillAmount = fill;
    }





}

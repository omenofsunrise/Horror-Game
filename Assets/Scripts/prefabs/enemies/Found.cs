using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Found : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Attack>().targetFound = true;
    }

 
}

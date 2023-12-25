using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHolderController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseGates()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) != null)
            {
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}

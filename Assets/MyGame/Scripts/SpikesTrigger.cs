using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GlobalVariables.PLATFORMTAG))
        {
            Destroy(col.gameObject);
        }
    }

}

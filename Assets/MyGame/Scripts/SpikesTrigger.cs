using UnityEngine;

public class SpikesTrigger : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GlobalVariables.PLATFORMTAG))
        {
            Destroy(col.gameObject);
        }
        else if (col.CompareTag(GlobalVariables.PLAYERTAG))
        {
            col.GetComponent<Player>().Death();
        }
    }
}

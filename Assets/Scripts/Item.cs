using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
    
    public void Collect()
    {
        Debug.Log("Item Collected");

        Destroy(gameObject);
    }
}

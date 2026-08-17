using UnityEngine;

public class BlastDie : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 1);
    }
    
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}

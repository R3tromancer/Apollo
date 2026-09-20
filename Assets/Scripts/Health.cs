using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints;
    [SerializeField] GameObject explosion;




    public void ReduceHealth(int damageRecieved)
    {
        healthPoints -= damageRecieved;
        if(healthPoints <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }      
    
     
}

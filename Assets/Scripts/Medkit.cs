using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float healAmount = 50;


    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
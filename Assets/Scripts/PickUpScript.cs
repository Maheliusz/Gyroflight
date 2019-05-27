using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public PickUpType pickUpType;
    public float amount = 0f;

    public enum PickUpType
    {
        POINTS,
        HEALTH,
        DAMAGE
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerScript = other.gameObject.GetComponent<PlaneController>();
        switch (pickUpType)
        {
            case PickUpScript.PickUpType.POINTS:
                Debug.Log("points picked up");
                playerScript.AddScore(amount);
                break;
            case PickUpScript.PickUpType.HEALTH:
                Debug.Log("health picked up");
                playerScript.Heal(amount);
                break;
            case PickUpScript.PickUpType.DAMAGE:
                Debug.Log("damage picked up");
                playerScript.DealDamage(amount);
                break;
        }
        Destroy(this.gameObject);
    }
}

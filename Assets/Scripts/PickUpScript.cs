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

    private void Update()
    {
        Vector3 position = this.transform.position;
        position[2] = this.transform.parent.transform.position.z;
        this.transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerScript = other.gameObject.GetComponent<PlayerState>();
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
}

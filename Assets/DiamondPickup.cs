using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    //[SerializeField] GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory inventory;
        inventory = collision.gameObject.GetComponent<PlayerInventory>();
        
        if (inventory != null)
        {
            //door.SetActive(false);
            inventory.diamonds += 1;
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}

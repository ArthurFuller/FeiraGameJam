using UnityEngine;

public class WeigthDetector : MonoBehaviour
{

    PlayerController player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BoxWeight box = collision.GetComponent<BoxWeight>();

        if (box != null)
        {
            player.realWeight += box.weight;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BoxWeight box = (collision.GetComponent<BoxWeight>());

        if (box != null)
        {
            player.realWeight -= box.weight;
        }
    }
}

using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    public PlayerController player;            // Referência ao PlayerController
    public BoxSpawn boxSpawner;       // Referência ao BoxSpawner (lista)

    public void DestroyLastBox()
    {
        if (boxSpawner.boxesInCart.Count > 0)
        {
            GameObject lastBox = boxSpawner.boxesInCart[boxSpawner.boxesInCart.Count - 1];
            BoxWeight boxWeight = lastBox.GetComponent<BoxWeight>();

            boxSpawner.boxesInCart.Remove(lastBox); // Remove da lista
            Destroy(lastBox); // Destrói a caixa
        }
    }
}
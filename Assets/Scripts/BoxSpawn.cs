using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{

    [SerializeField] GameObject boxPrefab;
    [SerializeField] Transform spawnPoint;

    public List<GameObject> boxesInCart = new List<GameObject>();

    public  void SpawnBox()
    {
        GameObject newBox = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
        boxesInCart.Add(newBox);
    }

}

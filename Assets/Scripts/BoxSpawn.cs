using UnityEngine;

public class BoxSpawn : MonoBehaviour
{

    [SerializeField] GameObject boxPrefab;
    [SerializeField] Transform spawnPoint;

    public  void SpawnBox()
    {
        Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
    }

}

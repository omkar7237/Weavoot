using JetBrains.Annotations;
using UnityEngine;

public class sortingOrder : MonoBehaviour
{  

    public int obstacleOrder = 10; // Higher than stars' order
    public string obstacleLayer = "Obstacles"; // Your layer name

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingLayerName = obstacleLayer;
            sr.sortingOrder = obstacleOrder;
        }
    }
    void Update()
    {
        
    }
}

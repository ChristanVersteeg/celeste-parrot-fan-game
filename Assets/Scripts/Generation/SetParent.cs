using UnityEngine;

public class SetParent : MonoBehaviour
{  
    void Start()
    {
        transform.parent = FindObjectOfType<GridMovement>().transform;
    }
}

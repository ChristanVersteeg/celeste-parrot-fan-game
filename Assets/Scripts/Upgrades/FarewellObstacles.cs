using UnityEngine;
using static UnityEngine.KeyCode;
using static UnityEngine.Vector3;

public class FarewellObstacles : MonoBehaviour
{
    private int farewell;
    private int speed = 10;
    [SerializeField] private GameObject farewellPrefab;
    private void Start()
    {
        farewell = PlayerPrefs.GetInt(nameof(farewell));
        farewell = int.MaxValue; //Haha debug code go brrr
    }

    private void InstantiateWithKeyDirection(KeyCode key, Vector3 direction, Quaternion rotation)
    {
        if (!Input.GetKeyDown(key)) return;
        if (farewell == 0) return;
        
        Rigidbody2D rb = Instantiate(farewellPrefab, transform.position, rotation).GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
        //Yes this is inneficient and I should just put it in a seperate layer and turn of that specific layer
        //Do I care?
        //No.
        //Not my problem.
        Physics2D.IgnoreCollision(rb.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        farewell--;
    }

    private void Update()
    {
        InstantiateWithKeyDirection(UpArrow, up, Quaternion.Euler(0, 0, 0));
        InstantiateWithKeyDirection(DownArrow, down, Quaternion.Euler(0, 0, 180)); 
        InstantiateWithKeyDirection(RightArrow, right, Quaternion.Euler(0, 0, -90));
    }
}
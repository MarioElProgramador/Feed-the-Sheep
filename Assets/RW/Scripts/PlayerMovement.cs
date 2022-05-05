using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    float horizontalBoundary = 22;

    Vector2 HorizontalVerticalInput;

    public GameObject hayBalePrefab; //Reference to the Hay Bale prefab.
    public Transform haySpawnpoint; //The point from which the hay will to be shot.
    public float shootInterval; //The smallest amount of time between shots
    private float shootTimer; //A timer that to keep track whether the machine can shoot

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        hayBalePrefab.tag = "Hay";
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }

    private void UpdateMovement()
    {
        HorizontalVerticalInput[0] = Input.GetAxisRaw("Horizontal");
        HorizontalVerticalInput[1] = Input.GetAxisRaw("Vertical");

        // Left, Up
        if ((HorizontalVerticalInput[0] < 0 || HorizontalVerticalInput[1] > 0) && transform.position.x > -horizontalBoundary) // Left Boundary
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        // Right, Down
        else if ((HorizontalVerticalInput[0] > 0 || HorizontalVerticalInput[1] < 0) && transform.position.x < horizontalBoundary) // Right Boundary
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }
}

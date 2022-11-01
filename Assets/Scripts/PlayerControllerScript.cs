using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float playerSpeed;
    public float minX, maxX, minY, maxY;
    public GameObject lasetBeam, laserBeamSpawn;
    public float fireRate = 0.25f;
    private float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 8; 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement;
        float verticalMovement;
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horizontalMovement, verticalMovement);
        GetComponent<Rigidbody2D>().velocity = newVelocity * playerSpeed;

        float newX, newY;

        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);

        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);

        if(Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            //GameObject.Instantiate();
            GameObject goObj;
            goObj = Instantiate(lasetBeam, laserBeamSpawn.transform.position, laserBeamSpawn.transform.rotation);
            goObj.transform.Rotate(new Vector3(0, 0, 0));

            timer = 0;
        }
        timer += Time.deltaTime;
    }
}

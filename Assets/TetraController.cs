using UnityEngine;
using System.Collections;

public class TetraController : MonoBehaviour {

  private Rigidbody rb;
  public float speed;
  public GameObject[] thrusters;
  public GameObject rearThruster;
  public GameObject rightThruster;
  public GameObject leftThruster;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {

  }

  void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    float thrust = 0.0f;

    if (moveHorizontal < 0.01f)
    {
      //rb.AddForce( * speed);      
    }

    RaycastHit hit;
    foreach (GameObject thruster in thrusters)
    {
      Ray thrustRay = new Ray(thruster.transform.position, Vector3.down);
      if (Physics.Raycast(thrustRay, out hit, 2))
      {
        thrust = (2.0f - hit.distance) * (2.0f - hit.distance);        
      }
    }


    Ray thrustRay2 = new Ray(transform.position, Vector3.down);
    if (Physics.Raycast(thrustRay2, out hit, 2))
    {
      thrust = (2.0f - hit.distance) * (2.0f - hit.distance);
    }

    Vector3 movement = new Vector3(moveHorizontal, thrust, moveVertical);

    rb.AddForce(movement * speed);
  }

}

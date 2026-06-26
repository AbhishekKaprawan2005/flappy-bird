using UnityEngine;

public class pipemovement : MonoBehaviour
{
    public float speed = 5f;
     
    private float leftedge;

    private void Start()
    {
        leftedge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }


    private void Update()
    {                                        // ensures smooth movement, making it frame-rate independent.
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < leftedge)
        {
            Destroy(gameObject);             // Destroying
        }
    }

}

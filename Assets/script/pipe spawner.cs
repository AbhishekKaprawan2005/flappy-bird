using UnityEngine;

public class PipeSpawner : MonoBehaviour  
{
    public GameObject prefabs; 

    public float spawnrate = 1f;

    public float maxheight = -1f;

    public float minheight = 1f;

    private void OnEnable()                               
    {
        InvokeRepeating(nameof(Spawn), spawnrate, spawnrate);
    }

    private void OnDisable()                                 // when player looses game, everything stops
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {                                                               // no rotation
        GameObject pipe = Instantiate(prefabs, transform.position, Quaternion.identity);    // clone the existing object
        pipe .transform.position += Vector3.up * Random.Range(minheight,maxheight);         // spawn the pipe
    }

}

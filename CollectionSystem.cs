using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSystem : MonoBehaviour
{
    public int random;
    public Transform[] spawners;
    public IEnumerator spawning;
    public GameManager gmObject;

    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("GameManager").GetComponent<GameManager>();

        random = Random.Range(0,spawners.Length); //Choose a random location
        Debug.Log(random);
        spawning = Spawning();
        StartCoroutine(spawning);
    }

    public IEnumerator Spawning()
    {
        while (gmObject.gameOver == false) //While the game is not over
        {
            //Set Ghosties Position to a random spawn location
            transform.position = spawners[random].position;

            yield return new WaitForSeconds(2);//Wait 2 Seconds

            random = Random.Range(0, spawners.Length);
            Debug.Log(random);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gmObject.collectedGhost = true;
            Destroy(gameObject);
        }
    }
}

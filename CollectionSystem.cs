using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectionSystem : MonoBehaviour
{
    public GameManagerScript gameManager;   
    public TMP_Text info;                   
    public Slider bar;                      
    public IEnumerator collect;             
    public float timer;
    public float timerMax = 2f;
    public float points;

    // Start is called before the first frame update
    void Start()
    {
        bar.gameObject.SetActive(false);    
        info.text = "";                     
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            //Change Information Text to "Collecting"
            info.text = "Collecting";
            //Show the Slider
            bar.gameObject.SetActive(true);
            //Set collect variable to Collecting method
            collect = Collecting();
            //Start the collecting coroutine
            StartCoroutine(collect);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //If other tag's gameobject has the tag player
        if (other.gameObject.tag == "Player")
        {
            //  Start the timer
            timer += Time.deltaTime;
            //  Start increasing the value of the bar by timer times 0.01
            bar.value += (timer * .01f);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        //Stop the collecting coroutine
        StopCoroutine(collect);
        //Set Information Text to an empty string
        info.text = "";
        //Hide the bar
        bar.gameObject.SetActive(false);
        //Set the bar value to 0
        bar.value = 0;
        //Reset the timer
        timer = 0;
    }

    public IEnumerator Collecting()
    {
        yield return new WaitForSeconds(timerMax); 
        gameManager.score += points;             

        Destroy(gameObject);                
    }

}

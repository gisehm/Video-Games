using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepositScript : MonoBehaviour
{
    public GameManager gmObject;
    public TMP_Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        gmObject = GameObject.Find("GameManager").GetComponent<GameManager>();
        infoText.text = "Gargoylie: Hey! Come here!";
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the other gameObject has the tag Player
        if (other.gameObject.tag == "Player")
        {
            //If gameManagerObject's collected bool is true
            if (gmObject.collectedGhost == true)
            {
                //Add 1 to the score in GameManagerScript
                gmObject.score += 1;
                //Set gameManagerObject's collected bool to false
                gmObject.collectedGhost = false;
                //Else
            }
            else
            {
                //Show a message that says "I lost my ghost friend!\nPlease
                infoText.text = "I lost my ghost friend!";
                //Catch the Ghost!";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        infoText.text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GMScript : MonoBehaviour
{
    public int lastPlayerAttackDamage;
    public int playerHP;
    public int enemyHP;
    public TextMeshProUGUI informationText;
    public bool hasGameEnded;
    public bool isPlayerTurn;
    public bool playerDefended;
    public bool skillAvailable;
    public bool firstTime = true;
    public Button attackButton;
    public Button defendButton;
    public Button skillButton;
    public GameObject player;
    public GameObject enemy;
    public GameObject explosionPrefab;
    public GameObject explosionMobilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        playerHP = 1000;
        enemyHP = 1000;
        hasGameEnded = false;
        isPlayerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGameEnded == false)
        {
            informationText.text = "Player HP:" + playerHP + "\nEnemy HP:" + enemyHP;
            if (playerHP <= 0)
            {
                informationText.text = "You lose...";
                Destroy(player);
                hasGameEnded = true;
            }

            else if (enemyHP <= 0)
            {
                informationText.text = "You win!";
                Destroy(enemy);
                hasGameEnded = true;
            }
            if (isPlayerTurn == true)
            {
                Debug.Log("Player's turn!");
                attackButton.interactable = true;
                defendButton.interactable = true;
                firstTime = false;

                if (skillAvailable == true)
                {
                    skillButton.interactable = true;
                }

                else if (skillAvailable == false)
                {
                    skillButton.interactable = false;
                }
            }

            else if (isPlayerTurn == false)
            {
                Debug.Log("Enemy's turn!");
                EnemyAttack();
                attackButton.interactable = false;
                defendButton.interactable = false;
                skillButton.interactable = false;
            }
        }
    }
    public void PlayerAttack()
    {
        Debug.Log("Player attacks!");
        lastPlayerAttackDamage = Random.Range(150, 301);
        enemyHP -= lastPlayerAttackDamage;
        isPlayerTurn = false;
        Instantiate(explosionPrefab, new Vector3(8f, 1f, 0f), Quaternion.identity);
    }
    public void PlayerDefend()
    {
        Debug.Log("Player defends!");
        playerDefended = true;
        isPlayerTurn = false;
        skillAvailable = true;
        Instantiate(explosionPrefab, new Vector3(8f, 1f, 0f), Quaternion.identity);
    }
    public void PlayerSkill()
    {
        Debug.Log("Player uses a skill!");
        lastPlayerAttackDamage = Random.Range(300, 501);
        enemyHP -= lastPlayerAttackDamage;
        skillAvailable = false;
        isPlayerTurn = false;
        Instantiate(explosionPrefab, new Vector3(8f, 1f, 0f), Quaternion.identity);
    }
    public void EnemyAttack()
    {
        if (playerDefended == false)
        {
            playerHP -= Random.Range(150, 301);
        }
        else if (playerDefended == true)
        {
            playerHP -= Random.Range(50, 101);
            if (Random.Range(0, 100) < 25)
            {
                PlayerAttack();
            }
            playerDefended = false;
        }

        isPlayerTurn = true;
        GetComponent<AudioSource>().Play();
        Instantiate(explosionMobilePrefab, new Vector3(-8f, -1f, 0f), Quaternion.identity);
    }
}

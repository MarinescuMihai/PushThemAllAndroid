using System.Collections.Generic;
using UnityEngine;

public class GroundCountdown : MonoBehaviour
{
    public bool isCreated;
    public GameObject Enemy;

    float timeRemaining = 10;
    TextMesh countDownTxt;
    GameObject theGround;
    GameObject countScore;

    private void Start()
    {
        countDownTxt = gameObject.GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 3 && !isCreated)
            {
                isCreated = true;
                theGround = Instantiate(gameObject, GetGroudPosition(), gameObject.transform.rotation);
            }
        }
        else
        {
            isCreated = false;
        }

        countDownTxt.text = ((int)timeRemaining).ToString();
    }

    private void Awake()
    {
        Destroy(gameObject, 10);
        timeRemaining = 10;
        isCreated = false;
        CreateEnemy();
        UpdateScore();
        //ChangeCameraBackground();
    }

    Vector3 GetGroudPosition()
    {
        var randomNumber = Random.Range(0, 3);

        switch(randomNumber)
        {
            case 0:
                return new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
            case 1:
                return new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);
            case 2:
                return new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 5);
            default:
                return new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 5);
        }
    }

    void CreateEnemy()
    {
        var enemyPositions = new List<Vector3>() { 
            new Vector3(gameObject.transform.position.x + 1.5f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z - 1f),
            new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z - 1f),
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z - 2),
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z),
            new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z - 0.97f)
            };
        foreach (var position in enemyPositions)
        {
            Instantiate(Enemy, position, gameObject.transform.rotation);
        }
       
    }

    void UpdateScore()
    {
        //ScoreManager.Instance.Score++;
        //ScoreManager.Instance.UpdateScore();

        GameObject.Find("GameManager").GetComponent<ScoreManager>().Score++;
        GameObject.Find("GameManager").GetComponent<ScoreManager>().UpdateScore();
    }
}

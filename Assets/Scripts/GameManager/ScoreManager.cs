using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public Text ScoreTextPanel;
    public int Score = -1;

    void Awake()
    {
        if (Instance == null)
        { 
            Instance = this;
        } 
        else if (Instance != this) 
        {
            Destroy(this); 
        }
    }

    public void UpdateScore()
    {
        ScoreTextPanel.text = $"SCORE: {Score}";
    }
}

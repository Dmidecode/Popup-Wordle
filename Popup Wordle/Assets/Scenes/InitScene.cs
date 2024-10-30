using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimerText;
    private int score;

    public float targetTime = 60.0f;

    void Awake()
    {
        string path = "Assets/Scenes/words.txt";
        var lines = File.ReadAllLines(path);
    }

    void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    private void Update()
    {
        targetTime -= Time.deltaTime;
        TimerText.text = $"{targetTime:0.##} s";
        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreText.text = "Score: " + score;
    }
    void timerEnded()
    {
        //do your stuff here.
    }
}

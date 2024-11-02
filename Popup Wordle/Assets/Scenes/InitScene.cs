using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.DebugUI;

public class InitScene : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI InputField;
    public GameObject PopingWordPanel;
    public GameObject WordExample;
    public string[] Words;

    private List<GameObject> words;

    public float targetTime = 60.0f;

    void Awake()
    {
        string path = "Assets/Scenes/words.txt";
        Words = File.ReadAllLines(path);
        words = new List<GameObject>();
    }

    void Start()
    {
        ScoreData.Score = 0;
        UpdateScore(0);
        this.FocusOnInput();
        this.PopAWord();
    }

    private void Update()
    {
        // Timer
        targetTime -= Time.deltaTime;
        TimerText.text = $"{targetTime:0.##} s";
        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    string GetAWordFromDico()
    {
        int num = UnityEngine.Random.Range(0, this.Words.Length - 1);
        return this.Words[num];
    }


    public void OnInputFieldTextSubmit(string inputText)
    {
        Debug.Log("Input text changed: " + inputText);
        this.PopAWord();
        this.FocusOnInput();

        var currentWords = this.words.Select(x => x.GetComponent<WordScript>().TextShowing.text);
        if (currentWords.Contains(inputText.ToLower()))
        {
            GameObject go = this.words.Find(x => x.GetComponent<WordScript>().TextShowing.text == inputText);
            Destroy(go);
            this.words.Remove(go);
            UpdateScore(inputText.Length);
            switch (inputText.Length)
            {
                case 4:
                    ScoreData.IVWords += 1;
                    break;
                case 5:
                    ScoreData.VWords += 1;
                    break;
                case 6:
                    ScoreData.VIWords += 1;
                    break;
                case 7:
                    ScoreData.VIIWords += 1;
                    break;
                case 8:
                    ScoreData.VIIIWords += 1;
                    break;
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        ScoreData.Score += scoreToAdd;
        ScoreText.text = "Score: " + ScoreData.Score;
    }
    void timerEnded()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ScoreScene");
    }

    void FocusOnInput()
    {
        foreach (var input in InputField.GetComponents<TMP_InputField>())
        {
            input.text = "Text";
            input.ActivateInputField();
        }
    }

    void PopAWord()
    {
        if (this.WordExample == null || this.PopingWordPanel == null)
        {
            return;
        }

        // instancier un nouveau mot au milieu du panel
        GameObject newWord = Instantiate(this.WordExample, this.PopingWordPanel.transform);
        words.Add(newWord);

        WordScript wordScript = this.WordExample.GetComponent<WordScript>();
        wordScript.TextShowing.text = this.GetAWordFromDico();
        if (wordScript.TextShowing.text.Length > 10)
            wordScript.Background.sizeDelta = new Vector3(200, 0);

        // positionne
        RectTransform rectTransform = this.PopingWordPanel.GetComponent<RectTransform>();
        Vector3 position = wordScript.GetNewPositionWithinPanelLimit(rectTransform);
        newWord.transform.Translate(position);
        Debug.Log("Newtransform = " + newWord.transform.position);
    }
}

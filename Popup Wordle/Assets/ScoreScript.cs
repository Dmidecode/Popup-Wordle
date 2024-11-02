using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI DifficultyText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI IVWordText;
    public TextMeshProUGUI VWordText;
    public TextMeshProUGUI VIWordText;
    public TextMeshProUGUI VIIWordText;
    public TextMeshProUGUI VIIIWordText;
    
    void Start()
    {
        DifficultyText.text = $"Difficulty: {ScoreData.Difficulty.ToString()}";
        ScoreText.text = $"Score: {ScoreData.Score}";
        IVWordText.text = $"Four Words: {ScoreData.IVWords}";
        VWordText.text = $"Five Words: {ScoreData.VWords}";
        VIWordText.text = $"Six Words: {ScoreData.VIWords}";
        VIIWordText.text = $"Seven Words: {ScoreData.VIIWords}";
        VIIIWordText.text = $"Eight Words: {ScoreData.VIIIWords}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

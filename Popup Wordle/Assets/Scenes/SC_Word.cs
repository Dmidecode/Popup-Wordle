using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class WordScript : MonoBehaviour
{
    public TextMeshProUGUI TextShowing;
    public TextAsset DicoFile;
    public RectTransform Background;
    public RectTransform PopingWordPanelLimit;
    public float Speed;

    public string[] DicoWords;
    private Vector3 MovingDirection = Vector3.right;

    void Start()
    {

    }

    void Update()
    {
        // Update is called once per frame
        this.LaunchCoRoutineToMove();
    }

    public Vector3 GetNewPositionWithinPanelLimit(RectTransform panel)
    {
        Debug.Log("position = " + panel.position);
        Debug.Log("rect = " + panel.rect);

        float x = Random.Range(panel.rect.x, panel.rect.width + panel.rect.x);
        float y = Random.Range(panel.rect.y, panel.rect.height + panel.rect.y);
        Vector3 position = new Vector3(x, y, panel.position.z);
        Debug.Log("NewPosition = " + position);
        return position;
    }

    void LaunchCoRoutineToMove()
    {
        //            Vector3 newPosition = this.GetNewPositionWithinPanelLimit(parent);
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        rectTransform.Translate(MovingDirection * this.Speed * Time.deltaTime);
        Debug.Log("AtferTranslate = " + rectTransform.position);

        Vector3 limitMin = new Vector3(this.PopingWordPanelLimit.position.x + this.PopingWordPanelLimit.rect.xMin + rectTransform.rect.width, 0);
        Vector3 limitMax = new Vector3(this.PopingWordPanelLimit.position.x + this.PopingWordPanelLimit.rect.xMax, 0);
        Debug.Log("grandparent position = " + this.PopingWordPanelLimit.position);
        Debug.Log("limitMin = " + limitMin.x + " limitMax = " + limitMax.x);

        if (rectTransform.position.x <= limitMin.x)
        {
            MovingDirection = Vector3.right;
        }
        else if (rectTransform.position.x >= limitMax.x)
        {
            MovingDirection = Vector3.left;
        }
    }
}
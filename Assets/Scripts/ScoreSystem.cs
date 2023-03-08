using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private static int _score = 0;

    [SerializeField]
    private TMP_Text _text;

    public void IncrementScore()
    {
        _score++;
        Debug.Log("Score is now " + _score);
    }

    void Update()
    {
        _text.text = "Score: " + _score.ToString();
        Debug.Log(_text.text);
    }
}

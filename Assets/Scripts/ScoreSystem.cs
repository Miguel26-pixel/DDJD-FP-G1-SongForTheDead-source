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
    }

    void Update()
    {
        _text.text = "Score: " + _score.ToString();
    }

    public int getScore()
    {
        return _score;
    }
}

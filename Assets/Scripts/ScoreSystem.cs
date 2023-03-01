using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private int _score = 0;

    [SerializeField]
    private TMP_Text _text;

    public void IncrementScore()
    {
        _score++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Score: " + _score.ToString();
    }
}

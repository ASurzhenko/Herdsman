using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text ScoresText;
    private void Start() {
        ScoresText.text = $"Scorec: {PlayerData.Scores.ToString()}";
    }
    private void OnEnable() {
		PlayerData.OnPlayerScoresChange += OnPlayerScoresChangeHandler;
	}
    private void OnPlayerScoresChangeHandler(int scores)
    {
        ScoresText.text = $"Scorec: {scores.ToString()}";
    }
}

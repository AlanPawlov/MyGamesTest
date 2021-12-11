using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ScoreController
{
    private SaveData[] _highScores;
    public Action<int> OnScoreChange = delegate { };

    public int CurrentScore { get; private set; }

    public ScoreController()
    {
        Initialize();
    }

    private void Initialize()
    {
        _highScores = SaveLoadController.Instance.Load();
        if (_highScores == null) FillSavesWithStandartValues();
    }

    public void CheckNewResult(string name)
    {
        var newResult = new SaveData();
        newResult.name = name;
        newResult.scores = CurrentScore;

        var tempArray = new SaveData[11];
        _highScores.CopyTo(tempArray, 0);
        tempArray[10] = newResult;
        var sortedArray = SortScore(tempArray);

        for (int i = 0; i < _highScores.Length; i++)
        {
            _highScores[i] = sortedArray[i];
        }
        SaveLoadController.Instance.Save(_highScores);
    }

    private SaveData[] SortScore(SaveData[] data)
    {

        var sortedScores = from s in data
                           orderby s.scores descending
                           select s;

        SaveData[] sortedArray = sortedScores.ToArray();
        return sortedArray;
    }

    public void ChangeScore(int score)
    {
        CurrentScore += score;
        OnScoreChange.Invoke(CurrentScore);
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }

    public SaveData GetScore(int index)
    {
        SaveData data = new SaveData();
        data.name = _highScores[index].name;
        data.scores = _highScores[index].scores;

        return data;
    }

    private void FillSavesWithStandartValues()
    {
        _highScores = new SaveData[10];

        for (int i = 0; i < 10; i++)
        {
            _highScores[i] = new SaveData();
        }

        _highScores[0].name = "Boon";
        _highScores[0].scores = 999;
        _highScores[1].name = "Tobias";
        _highScores[1].scores = 998;
        _highScores[2].name = "John";
        _highScores[2].scores = 60;
        _highScores[3].name = "Diesel";
        _highScores[3].scores = 50;
        _highScores[4].name = "Sheperd";
        _highScores[4].scores = 45;
        _highScores[5].name = "Raziel";
        _highScores[5].scores = 43;
        _highScores[6].name = "Rayne";
        _highScores[6].scores = 40;
        _highScores[7].name = "Bruce";
        _highScores[7].scores = 30;
        _highScores[8].name = "Shrek";
        _highScores[8].scores = 19;
        _highScores[9].name = "Dante";
        _highScores[9].scores = 8;
    }
}

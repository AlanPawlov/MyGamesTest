using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameRules _rules;
    [SerializeField] private SquaresList _squaresTypes;
    [SerializeField] private SequenceSquareContainerView _sequenceContainerView;
    [SerializeField] private UsablesSquareContainerView _usablesContainerView;
    [SerializeField] private SquareView _squarePrefab;

    private SequenceSquareController _sequenceSquareController;
    private UsableSquareController _usableSquareController;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        Initialize();
    }

    #endregion

    #region Methods

    private void Initialize()
    {
        _sequenceSquareController = new SequenceSquareController();
        _usableSquareController = new UsableSquareController();
        _sequenceContainerView = FindObjectOfType<SequenceSquareContainerView>();
        _sequenceContainerView.SetUp(_rules, _squaresTypes, _sequenceSquareController, _squarePrefab);
        _usablesContainerView = FindObjectOfType<UsablesSquareContainerView>();
        _usablesContainerView.SetUp(_rules, _squaresTypes, _sequenceSquareController, _squarePrefab, _usableSquareController);
        Subscribe();
        PlayGame();
    }

    private void Subscribe()
    {
        _sequenceSquareController.OnCompletteBuildSequence += WinGame;
        _sequenceSquareController.OnErrorSquare += LoseGame;
        _sequenceContainerView.OnHideSequence += SetUpUsableSquare;
    }

    private void SetUpUsableSquare()
    {
        _usablesContainerView?.CreateUsableSquare();
    }

    public void PlayGame()
    {
        _sequenceContainerView?.StartMatch();
    }

    public void LoseGame()
    {
        Debug.Log("You Lose");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinGame()
    {
        Debug.Log("You Win");
        Clear();
        PlayGame();
    }

    private void Clear()
    {
        _sequenceSquareController.Clear();
        _usableSquareController.Clear();
    }
    #endregion
}

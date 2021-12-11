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
    private SquareController _squareController;
    private MenuController _menuController;
    private ScoreController _scoreController;

    private int _level = 0;
    #endregion

    #region UnityMethods
    private void OnEnable()
    {
        Initialize();
        InjectToMenus();
        Subscribe();
        SetStartScreen();
    }
    #endregion

    #region Methods

    private void Initialize()
    {
        _menuController = new MenuController();
        _scoreController = new ScoreController();
        _squareController = new SquareController(_rules);

        _sequenceContainerView = FindObjectOfType<SequenceSquareContainerView>();
        _usablesContainerView = FindObjectOfType<UsablesSquareContainerView>();
        _sequenceContainerView.SetUp(_rules, _squaresTypes, _squarePrefab);
        _usablesContainerView.SetUp(_rules, _squaresTypes, _squarePrefab);
    }

    private void Subscribe()
    {
        _menuController.OnPlayGame += PlayGame;
        _squareController.OnCompletteBuildSequence += WinGame;
        _squareController.OnErrorSquare += LoseGame;
        _squareController.OnEndTime += LoseGame;
    }

    private void InjectToMenus()
    {
        MonoBehaviour[] items = FindObjectsOfType<MonoBehaviour>();

        for (int i = 0; i < items.Length; i++)
        {
            DependencyInjection(items[i]);
        }
    }

    public void DependencyInjection(object view)
    {
        if (view is IRequireDependency<MenuController>)
        {
            IRequireDependency<MenuController> item = (IRequireDependency<MenuController>)view;
            item.AssignDependency(_menuController);
        }
        if (view is IRequireDependency<ScoreController>)
        {
            IRequireDependency<ScoreController> item = (IRequireDependency<ScoreController>)view;
            item.AssignDependency(_scoreController);
        }
        if (view is IRequireDependency<SquareController>)
        {
            IRequireDependency<SquareController> item = (IRequireDependency<SquareController>)view;
            item.AssignDependency(_squareController);
        }
    }

    private void SetStartScreen()
    {
        _menuController.SwitchMenu(MenuTypes.MainMenu);
    }

    public void PlayGame()
    {
        _squareController.CreateSequenceSquare(_level);
    }

    public void LoseGame()
    {
        Debug.Log("Lose");
        _menuController.SwitchMenu(MenuTypes.EnterName);
        _level = 0;
        Clear();
    }

    public void WinGame()
    {
        _level++;
        _scoreController.ChangeScore(_rules.RewardScore);
        Clear();
        PlayGame();
    }

    private void Clear()
    {
        _squareController.Clear();
    }
    #endregion
}

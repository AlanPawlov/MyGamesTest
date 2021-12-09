using System;
using UnityEngine;


namespace Mafia
{
    public class CustomProcess
    {
        #region Fields

        private Action _action = delegate { };
        private bool _isBusy = false;

        private SceneDriver _sceneDriver;

        #endregion


        #region Properties

        public bool IsActive { get => _isBusy; }

        #endregion


        #region ClassLifeCycles

        public CustomProcess()
        {
            _sceneDriver = GameObject.FindObjectOfType<SceneDriver>();
        }

        #endregion


        #region Methods

        public void StartProcess(Action action)
        {
            if (_isBusy)
            {
                EndProcess();
            }
            _action = action;
            _sceneDriver.OnUpdate += _action;
            _isBusy = true;
        }

        public void RestartProcess()
        {
            _sceneDriver.OnUpdate += _action;
            _isBusy = true;
        }

        public void EndProcess()
        {
            _sceneDriver.OnUpdate -= _action;
            _isBusy = false;
        }

        #endregion
    }
}

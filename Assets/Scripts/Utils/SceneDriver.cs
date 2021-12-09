using System;
using UnityEngine;


namespace Mafia
{
    public class SceneDriver : MonoBehaviour
    {
        #region Fields

        public event Action OnUpdate = delegate { };

        #endregion


        #region UnityMethods

        private void Update()
        {
            OnUpdate.Invoke();
        }

        #endregion
    }
}

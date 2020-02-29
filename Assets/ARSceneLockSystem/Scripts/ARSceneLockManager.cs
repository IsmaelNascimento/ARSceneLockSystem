using System;
using System.Collections.Generic;
using UnityEngine;

namespace IsmaelNascimentoAssets.ARSceneLockSystem
{
    public class ARSceneLockManager : MonoBehaviour
    {
        #region VARIABLES

        private static ARSceneLockManager instance;
        public static ARSceneLockManager Instance
        {
            get { return instance = (instance is null) ? new GameObject("[AR_SCENE_LOCK_MANAGER]").AddComponent<ARSceneLockManager>() : instance; }
        }
        private bool isARSceneLock;
        public Action<bool> OnCallARSceneLockSystem;

        #endregion

        #region PUBLIC_METHODS

        public void CallSingleARSceneLockSystem()
        {
            if (isARSceneLock) UnlockARScene(); else LockARScene();
            OnCallARSceneLockSystem?.Invoke(isARSceneLock);
        }

        public void CallMultipleARSceneLockSystem()
        {
            if (isARSceneLock) MultipleUnlockARScene(); else MultipleLockARScene();
            OnCallARSceneLockSystem?.Invoke(isARSceneLock);
        }

        public void LockARScene()
        {
            GetARSceneActivaded().SetLock(GetLockParentTemp());
            isARSceneLock = true;
        }

        public void MultipleLockARScene()
        {
            GetARScenesActivaded().ForEach(arscene => arscene.SetLock(GetLockParentTemp()));
            isARSceneLock = true;
        }

        public void UnlockARScene()
        {
            GetARSceneActivaded().SetStateOriginal();
            isARSceneLock = false;
        }

        public void MultipleUnlockARScene()
        {
            GetARScenesActivaded().ForEach(arScene => arScene.SetStateOriginal());
            isARSceneLock = false;
        }

        #endregion

        #region PRIVATE_METHODS

        private ARScene GetARSceneActivaded() { return FindObjectOfType<ARScene>(); }

        private List<ARScene> GetARScenesActivaded() { return new List<ARScene>(FindObjectsOfType<ARScene>()); }

        private Transform GetLockParentTemp() { return Camera.main.transform; }

        #endregion
    }
}
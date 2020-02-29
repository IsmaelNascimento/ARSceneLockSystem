using System;
using System.Collections.Generic;
using UnityEngine;

namespace IsmaelNascimentoAssets
{
    public class ARSceneLockManager : MonoBehaviour
    {
        #region VARIABLES

        private static ARSceneLockManager instance;
        public static ARSceneLockManager Instance
        {
            get { return instance = (instance is null) ? new GameObject("[AR_SCENE_LOCK_MANAGER]").AddComponent<ARSceneLockManager>() : instance; }
            //set { }
        }
        private bool isARSceneLock;
        public Action<bool> OnCallARSceneLockSystem;

        #endregion

        #region MONOBEHAVBIOUR_METHODS

        //private void Start()
        //{
        //    Instance = this;
        //}

        #endregion

        #region PUBLIC_METHODS

        public Transform GetARSceneActiveTransform()
        {
            return FindObjectOfType<ARScene>().transform;
        }

        public List<Transform> GetARScenesActiveTransform()
        {
            List<Transform> arScenesActiveTransform = new List<Transform>();

            foreach (var arScene in FindObjectsOfType<ARScene>()) 
                arScenesActiveTransform.Add(arScene.transform);

            return arScenesActiveTransform;
        }

        public ARScene GetARSceneActive()
        {
            return FindObjectOfType<ARScene>();
        }

        public List<ARScene> GetARScenesActive()
        {
            return new List<ARScene>(FindObjectsOfType<ARScene>());
        }

        public Transform GetLockParentTemp()
        {
            return Camera.main.transform;
        }

        public void CallSingleARSceneLockSystem()
        {
            if (isARSceneLock)
                UnlockARScene();
            else
                LockARScene();

            OnCallARSceneLockSystem?.Invoke(isARSceneLock);
        }

        public void CallMultipleARSceneLockSystem()
        {
            if (isARSceneLock)
                MultipleUnlockARScene();
            else
                MultipleLockARScene();

            OnCallARSceneLockSystem?.Invoke(isARSceneLock);
        }

        #endregion

        #region PRIVATE_METHODS

        private void LockARScene()
        {
            GetARSceneActiveTransform().SetParent(GetLockParentTemp());
            isARSceneLock = true;
        }

        private void UnlockARScene()
        {
            GetARSceneActiveTransform().SetParent(GetARSceneActive().GetParentOriginal());
            isARSceneLock = false;
        }

        private void MultipleLockARScene()
        {
            GetARScenesActiveTransform().ForEach(arscene => arscene.SetParent(GetLockParentTemp()));
            isARSceneLock = true;
        }

        private void MultipleUnlockARScene()
        {
            for (int index = 0; index < GetARScenesActiveTransform().Count; index++)
                GetARScenesActiveTransform()[index].SetParent(GetARScenesActive()[index].GetParentOriginal());

            isARSceneLock = false;
        }

        #endregion
    }
}
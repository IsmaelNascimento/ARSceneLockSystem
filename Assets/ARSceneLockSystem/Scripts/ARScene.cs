using UnityEngine;

namespace IsmaelNascimentoAssets.ARSceneLockSystem
{
    public class ARScene : MonoBehaviour
    {
        #region VARIABLES

        private Transform parentOriginal;
        private Vector3 positionOriginal;
        private Quaternion rotationOriginal;

        #endregion

        #region MONOBEHAVIHOUR_METHODS

        private void OnEnable()
        {
            parentOriginal = transform.parent;
            positionOriginal = transform.localPosition;
            rotationOriginal = transform.localRotation;
        }

        #endregion

        #region PUBLIC_METHODS

        public void SetStateOriginal()
        {
            transform.parent = parentOriginal;
            transform.localPosition = positionOriginal;
            transform.localRotation = rotationOriginal;
        }

        public void SetLock(Transform newParent) { transform.parent = newParent; }

        #endregion
    }
}
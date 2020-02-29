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
            positionOriginal = transform.position;
            rotationOriginal = transform.rotation;
        }

        #endregion

        #region PUBLIC_METHODS

        public void SetStateOriginal()
        {
            transform.parent = parentOriginal;
            transform.position = positionOriginal;
            transform.rotation = rotationOriginal;
        }

        public void SetLock(Transform newParent) { transform.parent = newParent; }

        #endregion
    }
}
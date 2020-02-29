using UnityEngine;

namespace IsmaelNascimentoAssets
{
    public class ARScene : MonoBehaviour
    {
        #region VARIABLES

        private Transform parentOriginal;

        #endregion

        #region MONOBEHAVIHOUR_METHODS

        private void OnEnable()
        {
            parentOriginal = transform.parent;
        }

        #endregion

        #region PUBLIC_METHODS

        public Transform GetParentOriginal()
        {
            return parentOriginal;
        }

        #endregion
    }
}
using UnityEngine.UI;

namespace IsmaelNascimentoAssets
{
    public class SingleLockButton : GenericLockButton
    {
        #region MONOBEHAVIOUR_METHODS

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(ARSceneLockManager.Instance.CallSingleARSceneLockSystem);
        }

        #endregion
    }
}
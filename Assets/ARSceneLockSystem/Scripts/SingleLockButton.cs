using UnityEngine.UI;

namespace IsmaelNascimentoAssets.ARSceneLockSystem
{
    public class SingleLockButton : GenericLockButton
    {
        #region MONOBEHAVIOUR_METHODS

        private void Start() { GetComponent<Button>().onClick.AddListener(ARSceneLockManager.Instance.CallSingleARSceneLockSystem); }

        #endregion
    }
}
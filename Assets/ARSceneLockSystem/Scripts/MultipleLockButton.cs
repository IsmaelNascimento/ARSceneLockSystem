using UnityEngine.UI;

namespace IsmaelNascimentoAssets.ARSceneLockSystem
{
    public class MultipleLockButton : GenericLockButton
    {
        #region MONOBEHAVIOUR_METHODS

        private void Start() { GetComponent<Button>().onClick.AddListener(ARSceneLockManager.Instance.CallMultipleARSceneLockSystem); }

        #endregion
    }
}
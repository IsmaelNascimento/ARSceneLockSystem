using UnityEngine;
using UnityEngine.UI;

namespace IsmaelNascimentoAssets
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class GenericLockButton : MonoBehaviour
    {
        public enum ChangeType
        {
            Color,
            Image,
            ColorImage
        }
        #region VARIABLES

        [SerializeField] private ChangeType changeType = ChangeType.Color;
        [Header("CHANGE TYPE = COLOR")]
        [SerializeField] private Color lockColor = Color.red;
        [SerializeField] private Color unlockColor = Color.green;
        [Header("CHANGE TYPE = IMAGE")]
        [SerializeField] private Sprite lockImage;
        [SerializeField] private Sprite unlockImage;

        #endregion

        #region MONOBEHAVIOUR_METHODS

        private void Awake()
        {
            ARSceneLockManager.Instance.OnCallARSceneLockSystem = isARSceneLock =>
            {
                switch (changeType)
                {
                    case ChangeType.Color: ChangeColorButton(isARSceneLock); break;
                    case ChangeType.Image: ChangeImageButton(isARSceneLock); break;
                    case ChangeType.ColorImage: ChangeColorImageButton(isARSceneLock); break;
                }
            };
        }

        #endregion

        #region PRIVATE_METHODS

        private void ChangeColorButton(bool isARSceneLock)
        {
            if (isARSceneLock)
                GetComponent<Image>().color = lockColor;
            else
                GetComponent<Image>().color = unlockColor;
        }

        private void ChangeImageButton(bool isARSceneLock)
        {
            if (isARSceneLock)
                GetComponent<Image>().sprite = lockImage;
            else
                GetComponent<Image>().sprite = unlockImage;
        }

        private void ChangeColorImageButton(bool isARSceneLock)
        {
            if (isARSceneLock)
            {
                GetComponent<Image>().color = lockColor;
                GetComponent<Image>().sprite = lockImage;
            }
            else
            {
                GetComponent<Image>().color = unlockColor;
                GetComponent<Image>().sprite = unlockImage;
            }
        }

        #endregion
    }
}
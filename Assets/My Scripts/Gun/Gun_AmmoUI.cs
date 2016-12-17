using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DeadEnd
{
    public class Gun_AmmoUI : MonoBehaviour
    {
        public InputField currenAmmoField;
        public InputField carriedAmmoField;
        private Gun_Master gunMaster;
        
        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventAmmoChanged += UpdateAmmoUI;
        }

        void OnDisable()
        {
            gunMaster.EventAmmoChanged -= UpdateAmmoUI;
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
        }

        void UpdateAmmoUI(int currentAmmo, int carriedAmmo)
        {
            if(currenAmmoField != null)
            {
                currenAmmoField.text = currentAmmo.ToString();
            }

            if(carriedAmmoField != null)
            {
                carriedAmmoField.text = carriedAmmo.ToString();
            }
        }
    }
}


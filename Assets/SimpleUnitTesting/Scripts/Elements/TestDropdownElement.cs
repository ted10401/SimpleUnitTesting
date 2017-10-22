using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace SimpleUnitTesting
{
    public class TestDropdownElement : MonoBehaviour
    {
        private BaseUnitTesting m_unitTesting;
        private UnitTestingData m_unitTestingData;
        private List<Dropdown.OptionData> m_optionData;

        public void SetData(BaseUnitTesting unitTesting, UnitTestingData unitTestingData)
        {
            m_unitTesting = unitTesting;
            m_unitTestingData = unitTestingData;

            gameObject.transform.Find("TitleText").GetComponent<Text>().text = m_unitTestingData.MethodName.ToScriptName();

            TestDropdown attribute = m_unitTestingData.Attribute as TestDropdown;
            m_optionData = attribute.OptionData;

            Dropdown dropdown = GetComponentInChildren<Dropdown>();
            dropdown.onValueChanged.RemoveAllListeners();
            dropdown.onValueChanged.AddListener(OnValueChange);
            dropdown.ClearOptions();
            dropdown.AddOptions(m_optionData);
        }


        public void OnValueChange(int value)
        {
            if (null == m_unitTesting)
            {
                return;
            }

            object[] data = new object[]{ m_optionData[value] };

            m_unitTesting.RunTestMethod(m_unitTestingData.MethodName, data);
        }
    }
}
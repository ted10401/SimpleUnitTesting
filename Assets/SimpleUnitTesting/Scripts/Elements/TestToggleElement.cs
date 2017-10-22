using UnityEngine;
using UnityEngine.UI;

namespace SimpleUnitTesting
{
    public class TestToggleElement : MonoBehaviour
    {
        private BaseUnitTesting m_unitTesting;
        private UnitTestingData m_unitTestingData;

        public void SetData(BaseUnitTesting unitTesting, UnitTestingData unitTestingData)
        {
            m_unitTesting = unitTesting;
            m_unitTestingData = unitTestingData;

            gameObject.transform.Find("TitleText").GetComponent<Text>().text = m_unitTestingData.MethodName.ToScriptName();

            TestToggle attribute = m_unitTestingData.Attribute as TestToggle;

            Toggle toggle = GetComponent<Toggle>();
            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener(OnToggleChanged);
            toggle.isOn = attribute.IsOn;
        }


        public void OnToggleChanged(bool value)
        {
            if (null == m_unitTesting)
            {
                return;
            }

            object[] data = new object[]{ value };

            m_unitTesting.RunTestMethod(m_unitTestingData.MethodName, data);
        }
    }
}
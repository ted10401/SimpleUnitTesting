using UnityEngine;
using UnityEngine.UI;

namespace SimpleUnitTesting
{
    public class TestInputFieldElement : MonoBehaviour
    {
        private BaseUnitTesting m_unitTesting;
        private UnitTestingData m_unitTestingData;

        public void SetData(BaseUnitTesting unitTesting, UnitTestingData unitTestingData)
        {
            m_unitTesting = unitTesting;
            m_unitTestingData = unitTestingData;

            gameObject.transform.Find("TitleText").GetComponent<Text>().text = m_unitTestingData.MethodName.ToScriptName();

            GetComponentInChildren<InputField>().onValueChanged.RemoveAllListeners();
            GetComponentInChildren<InputField>().onValueChanged.AddListener(OnValueChanged);
        }


        public void OnValueChanged(string value)
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
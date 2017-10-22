using UnityEngine;
using UnityEngine.UI;

namespace SimpleUnitTesting
{
    public class TestButtonElement : MonoBehaviour
    {
        private BaseUnitTesting m_unitTesting;
        private UnitTestingData m_unitTestingData;

        public void SetData(BaseUnitTesting unitTesting, UnitTestingData unitTestingData)
        {
            m_unitTesting = unitTesting;
            m_unitTestingData = unitTestingData;

            gameObject.transform.Find("TitleText").GetComponent<Text>().text = m_unitTestingData.MethodName.ToScriptName();

            Button button = GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(OnButtonClicked);
        }


        public void OnButtonClicked()
        {
            if (null == m_unitTesting)
            {
                return;
            }

            m_unitTesting.RunTestMethod(m_unitTestingData.MethodName);
        }
    }
}
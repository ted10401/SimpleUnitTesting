using UnityEngine;
using UnityEngine.UI;

namespace SimpleUnitTesting
{
    public class TestSliderElement : MonoBehaviour
    {
        private BaseUnitTesting m_unitTesting;
        private UnitTestingData m_unitTestingData;
        private Text m_valueText;

        public void SetData(BaseUnitTesting unitTesting, UnitTestingData unitTestingData)
        {
            m_unitTesting = unitTesting;
            m_unitTestingData = unitTestingData;

            gameObject.transform.Find("TitleText").GetComponent<Text>().text = m_unitTestingData.MethodName.ToScriptName();
            m_valueText = gameObject.transform.Find("ValueText").GetComponent<Text>();

            TestSlider attribute = m_unitTestingData.Attribute as TestSlider;

            Slider slider = GetComponentInChildren<Slider>();
            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(OnValueChanged);
            slider.minValue = attribute.MinValue;
            slider.maxValue = attribute.MaxValue;
            slider.value = attribute.InitValue;
            m_valueText.text = attribute.InitValue.ToString();
        }


        public void OnValueChanged(float value)
        {
            if (null == m_unitTesting)
            {
                return;
            }

            object[] data = new object[]{ value };

            m_unitTesting.RunTestMethod(m_unitTestingData.MethodName, data);
            m_valueText.text = value.ToString();
        }
    }
}
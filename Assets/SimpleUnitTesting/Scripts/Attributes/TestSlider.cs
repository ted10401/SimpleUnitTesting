
namespace SimpleUnitTesting
{
    public class TestSlider : System.Attribute
    {
        public float MinValue { get { return m_minValue; } }
        private float m_minValue;

        public float MaxValue { get { return m_maxValue; } }
        private float m_maxValue;

        public float InitValue { get { return m_initValue; } }
        private float m_initValue;

        public TestSlider(float minValue = 0, float maxValue = 1, float initValue = 0)
        {
            m_minValue = minValue;
            m_maxValue = maxValue;
            m_initValue = initValue;
        }
    }
}
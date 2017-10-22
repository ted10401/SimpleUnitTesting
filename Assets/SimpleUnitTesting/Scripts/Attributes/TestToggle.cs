
namespace SimpleUnitTesting
{
    public class TestToggle : System.Attribute
    {
        public bool IsOn { get { return m_isOn; } }
        private bool m_isOn;

        public TestToggle(bool isOn = false)
        {
            m_isOn = isOn;
        }
    }
}
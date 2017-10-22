
namespace SimpleUnitTesting
{
    public class UnitTestingData
    {
        public string MethodName { get { return m_methodName; } }
        private string m_methodName;

        public System.Attribute Attribute { get { return m_attribute; } }
        private System.Attribute m_attribute;

        public UnitTestingData(string methodName, System.Attribute attribute)
        {
            m_methodName = methodName;
            m_attribute = attribute;
        }
    }
}

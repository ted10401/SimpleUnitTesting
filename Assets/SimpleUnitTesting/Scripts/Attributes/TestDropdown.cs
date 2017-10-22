using UnityEngine.UI;
using System.Collections.Generic;

namespace SimpleUnitTesting
{
    public class TestDropdown : System.Attribute
    {
        public List<Dropdown.OptionData> OptionData { get { return m_optionData; } }
        private List<Dropdown.OptionData> m_optionData;

        public TestDropdown(params string[] optionText)
        {
            m_optionData = new List<Dropdown.OptionData>();

            for (int i = 0; i < optionText.Length; i++)
            {
                m_optionData.Add(new Dropdown.OptionData(optionText[i]));
            }
        }
    }
}
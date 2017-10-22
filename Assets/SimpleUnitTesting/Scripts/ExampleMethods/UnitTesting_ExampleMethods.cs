using UnityEngine;
using UnityEngine.UI;
using SimpleUnitTesting;

public class UnitTesting_ExampleMethods : BaseUnitTesting
{
    [TestButton]
    public void TestButton()
    {
        Debug.LogError("UnitTesting_Examples.TestButton");
    }


    [TestDropdown("A", "B", "C", "D")]
    public void TestDropDown(Dropdown.OptionData data)
    {
        Debug.LogError("UnitTesting_Example.TestDropDown = " + data.text);
    }


    [TestInputField]
    public void TestInputField(string value)
    {
        Debug.LogError("UnitTesting_Example.TestInputField = " + value);
    }


    [TestSlider]
    public void TestSlider(float value)
    {
        Debug.LogError("UnitTesting_Example.TestSlider = " + value);
    }


    [TestSlider(0, 10, 5)]
    public void TestSliderWithInitialValue(float value)
    {
        Debug.LogError("UnitTesting_Example.TestSliderWithInitialValue = " + value);
    }


    [TestToggle]
    public void TestToggle(bool value)
    {
        Debug.LogError("UnitTesting_Example.TestToggle = " + value);
    }


    [TestToggle(true)]
    public void TestToggleWithInitialTrue(bool value)
    {
        Debug.LogError("UnitTesting_Example.TestToggleWithInitialTrue = " + value);
    }
}

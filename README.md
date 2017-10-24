# Simple Unit Testing plugin for Unity
_Copyright (c) 2017 Ted Sie. All rights reserved._

The Simple Unit Testing plugin for Unity is an open-source project whose goal is to provide a plugin that allows Unity developer to implement unit test methods with easy steps.

## Overview
The Simple Unit Testing plugin for Unity allows you to create test methods with custom attributes. The plugin provides support for the following attributes.

Attributes:

* [TestButton]
* [TestDropdown]
* [TestInputField]
* [TestSlider]
* [TestToggle]

System requirements:

* Unity 4.6 or above.
  *Note: Unity released UGUI system with 4.6*

## Attributes Introduce
[TestButton]

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_script_button.png" height="75px" />

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_ui_button.png" height="25px" />


[TestDropdown]

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_script_dropdown.png" height="75px" />

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_ui_dropdown.png" height="25px" />


[TestInputField]

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_script_inputfield.png" height="75px" />

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_ui_inputfield.png" height="25px" />


[TestSlider]

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_script_slider.png" height="75px" />

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_ui_slider.png" height="25px" />


[TestToggle]

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_script_toggle.png" height="75px" />

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_ui_toggle.png" height="25px" />


## How to setup new unit testing
1. Create a new Scene

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_step_create_scene.png" style="zoom:50%" />


2. Create a new Canvas

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_step_create_canvas.png" style="zoom:50%" />


3. Drag UnitTestingGenerator in Canvas

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_step_drag_generator.png" style="zoom:50%" />


4. Write new test method with custom attributes

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_step_write_script.png" style="zoom:50%" />


5. Add component to UnitTestingObject

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_step_add_component.png" style="zoom:50%" />


6. Play

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_step_play.png" style="zoom:50%" />
<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_example.gif" style="zoom:50%" />


## Drag Helper
The UnitTestingDragHelper is a simple switch to open/close the unit testing screen.
The idea is from iOS AssistiveTouch.

<img src="https://github.com/ted10401/SimpleUnitTesting/blob/master/GithubResources/simple_unit_testing_drag_helper.gif" style="zoom:50%" />
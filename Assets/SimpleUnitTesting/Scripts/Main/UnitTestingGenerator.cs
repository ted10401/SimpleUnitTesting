using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleUnitTesting;
using UnityEngine.UI;

public class UnitTestingGenerator : MonoBehaviour
{
    [SerializeField] private Button m_closeButton;
    [SerializeField] private GameObject m_unitTestingObject;
    [SerializeField] private Transform m_contentRoot;

    [Header("Template References")]
    [SerializeField] private GameObject m_templateParent;
    [SerializeField] private Text m_templateTitle;
    [SerializeField] private GameObject m_templateSpace;

    [Header("Template Unit Test Elements")]
    [SerializeField] private TestButtonElement m_templateTestButtonElement;
    [SerializeField] private TestDropdownElement m_templateTestDropdownElement;
    [SerializeField] private TestInputFieldElement m_templateTestInputFieldElement;
    [SerializeField] private TestSliderElement m_templateTestSliderElement;
    [SerializeField] private TestToggleElement m_templateTestToggleElement;

    private float m_maxWidth = 0f;
    private float m_spaceWidth;
    private BaseUnitTesting[] m_unitTestings;

    private void Awake()
    {
        if (null != m_closeButton)
        {
            if (null != GetComponentInParent<UnitTestingDragHelper>())
            {
                m_closeButton.onClick.AddListener(GetComponentInParent<UnitTestingDragHelper>().OnFullScreenCloseButtonClicked);
            }
        }

        m_spaceWidth = m_templateParent.GetComponent<GridLayoutGroup>().spacing.x;

        StartCoroutine(Generate());
    }


    private IEnumerator Generate ()
    {
        Clear();

        if (null == m_unitTestingObject)
        {
            Debug.LogError("[UnitTestingGenerator] m_unitTestingObject is null.");
            yield break;
        }

        m_unitTestings = m_unitTestingObject.GetComponents<BaseUnitTesting>();
        if (null == m_unitTestings ||
            m_unitTestings.Length < 1)
        {
            Debug.LogError("[UnitTestingGenerator] No unit testing scripts in \"" + m_unitTestingObject.name + "\"");
            yield break;
        }

        GameObject cacheInstance = null;

        for (int i = 0; i < m_unitTestings.Length; i++)
        {
            if (!m_unitTestings[i].enabled)
            {
                continue;
            }

            cacheInstance = Instantiate<GameObject>(m_templateTitle.gameObject, m_contentRoot);
            cacheInstance.GetComponent<Text>().text = m_unitTestings[i].GetType().Name;
            cacheInstance.SetActive(true);

            if (m_maxWidth == 0)
            {
                yield return new WaitForEndOfFrame();

                m_maxWidth = cacheInstance.GetComponent<RectTransform>().sizeDelta.x;
                m_maxWidth -= m_contentRoot.GetComponent<VerticalLayoutGroup>().padding.left * 2;
            }

            GameObject cacheParent = Instantiate<GameObject>(m_templateParent.gameObject, m_contentRoot);
            cacheParent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(m_maxWidth / 2 - m_spaceWidth, 100);
            cacheParent.SetActive(true);

            GenerateTestButtons(m_unitTestings[i], cacheParent.transform);
            GenerateTestToggles(m_unitTestings[i], cacheParent.transform);

            if (cacheParent.transform.childCount == 0)
            {
                Destroy(cacheParent);
            }

            cacheParent = Instantiate<GameObject>(m_templateParent.gameObject, m_contentRoot);
            cacheParent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(m_maxWidth - m_spaceWidth, 100);
            cacheParent.SetActive(true);

            GenerateTestInputFields(m_unitTestings[i], cacheParent.transform);
            GenerateTestSliders(m_unitTestings[i], cacheParent.transform);
            GenerateTestDropdowns(m_unitTestings[i], cacheParent.transform);

            if (cacheParent.transform.childCount == 0)
            {
                Destroy(cacheParent);
            }

            cacheInstance = Instantiate<GameObject>(m_templateSpace.gameObject, m_contentRoot);
            cacheInstance.SetActive(true);
        }
	}


    private void Clear()
    {
        foreach (Transform child in m_contentRoot)
        {
            Destroy(child.gameObject);
        }
    }


    private void GenerateTestButtons(BaseUnitTesting unitTesting, Transform parent)
    {
        UnitTestingData[] unitTestingData = unitTesting.GetUnitTestingData<TestButton>();

        if (null == unitTestingData ||
            unitTestingData.Length < 1)
        {
            return;
        }

        GameObject cacheInstance = null;
        for (int j = 0; j < unitTestingData.Length; j++)
        {
            cacheInstance = Instantiate<GameObject>(m_templateTestButtonElement.gameObject, parent);
            cacheInstance.SetActive(true);
            cacheInstance.GetComponent<TestButtonElement>().SetData(unitTesting, unitTestingData[j]);
        }
    }


    private void GenerateTestToggles(BaseUnitTesting unitTesting, Transform parent)
    {
        UnitTestingData[] unitTestingData = unitTesting.GetUnitTestingData<TestToggle>();

        if (null == unitTestingData ||
            unitTestingData.Length < 1)
        {
            return;
        }

        GameObject cacheInstance = null;
        for (int j = 0; j < unitTestingData.Length; j++)
        {
            cacheInstance = Instantiate<GameObject>(m_templateTestToggleElement.gameObject, parent);
            cacheInstance.SetActive(true);
            cacheInstance.GetComponent<TestToggleElement>().SetData(unitTesting, unitTestingData[j]);
        }
    }


    private void GenerateTestInputFields(BaseUnitTesting unitTesting, Transform parent)
    {
        UnitTestingData[] unitTestingData = unitTesting.GetUnitTestingData<TestInputField>();

        if (null == unitTestingData ||
            unitTestingData.Length < 1)
        {
            return;
        }

        GameObject cacheInstance = null;
        for (int j = 0; j < unitTestingData.Length; j++)
        {
            cacheInstance = Instantiate<GameObject>(m_templateTestInputFieldElement.gameObject, parent);
            cacheInstance.SetActive(true);
            cacheInstance.GetComponent<TestInputFieldElement>().SetData(unitTesting, unitTestingData[j]);
        }
    }


    private void GenerateTestSliders(BaseUnitTesting unitTesting, Transform parent)
    {
        UnitTestingData[] unitTestingData = unitTesting.GetUnitTestingData<TestSlider>();

        if (null == unitTestingData ||
            unitTestingData.Length < 1)
        {
            return;
        }

        GameObject cacheInstance = null;
        for (int j = 0; j < unitTestingData.Length; j++)
        {
            cacheInstance = Instantiate<GameObject>(m_templateTestSliderElement.gameObject, parent);
            cacheInstance.SetActive(true);
            cacheInstance.GetComponent<TestSliderElement>().SetData(unitTesting, unitTestingData[j]);
        }
    }


    private void GenerateTestDropdowns(BaseUnitTesting unitTesting, Transform parent)
    {
        UnitTestingData[] unitTestingData = unitTesting.GetUnitTestingData<TestDropdown>();

        if (null == unitTestingData ||
            unitTestingData.Length < 1)
        {
            return;
        }

        GameObject cacheInstance = null;
        for (int j = 0; j < unitTestingData.Length; j++)
        {
            cacheInstance = Instantiate<GameObject>(m_templateTestDropdownElement.gameObject, parent);
            cacheInstance.SetActive(true);
            cacheInstance.GetComponent<TestDropdownElement>().SetData(unitTesting, unitTestingData[j]);
        }
    }
}

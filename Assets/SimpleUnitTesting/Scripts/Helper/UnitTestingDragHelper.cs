using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UnitTestingDragHelper : MonoBehaviour
{
    public const float FULL_SIZE_RATIO = 0.75f;

    [SerializeField] private float m_duration = 1f;
    [SerializeField] private GameObject m_dragImage;
    [SerializeField] private GameObject m_fullScreen;

    private Canvas m_canvas;
    private RectTransform m_rectTransform;

    private float m_maxWidth;
    private float m_maxHeight;

    #region Drag
    private Vector2 m_startPosition;
    private Vector2 m_targetPosition;
    private float m_moveTimer;
    private bool m_isMoving = false;
    #endregion

    #region Screen
    private Vector2 m_initSizeDelta;
    private Vector2 m_fullSizeDelta;
    private float m_pointerDownTime;
    private Vector2 m_startSizeDelta;
    private Vector2 m_targetSizeDelta;
    private float m_sizeTimer;
    private bool m_isSizing = false;
    #endregion

    private void Awake()
    {
        m_canvas = GetComponentInParent<Canvas>();
        m_rectTransform = GetComponent<RectTransform>();

        m_maxHeight = m_canvas.GetComponent<RectTransform>().sizeDelta.y / 2;
        m_maxWidth = m_canvas.GetComponent<RectTransform>().sizeDelta.x / 2;

        m_dragImage.SetActive(true);
        m_fullScreen.SetActive(false);
    }


    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();

        m_maxHeight = m_canvas.GetComponent<RectTransform>().sizeDelta.y / 2;
        m_maxWidth = m_canvas.GetComponent<RectTransform>().sizeDelta.x / 2;

        m_initSizeDelta = m_rectTransform.sizeDelta;
        m_fullSizeDelta = new Vector2(m_maxWidth * 2, m_maxHeight * 2) * FULL_SIZE_RATIO;

        OnDragEnd(null);
    }


    private void Update()
    {
        if (m_isMoving)
        {
            m_moveTimer += Time.deltaTime;
            m_rectTransform.anchoredPosition = Vector2.Lerp(m_startPosition, m_targetPosition, m_moveTimer / m_duration);

            if (m_moveTimer >= m_duration)
            {
                m_isMoving = false;
                m_rectTransform.anchoredPosition = m_targetPosition;
            }
        }

        if (m_isSizing)
        {
            m_sizeTimer += Time.deltaTime;
            m_rectTransform.anchoredPosition = Vector2.Lerp(m_startPosition, m_targetPosition, m_sizeTimer / m_duration);
            m_rectTransform.sizeDelta = Vector2.Lerp(m_startSizeDelta, m_targetSizeDelta, m_sizeTimer / m_duration);

            if (m_sizeTimer >= m_duration)
            {
                m_isSizing = false;
                m_rectTransform.anchoredPosition = m_targetPosition;
                m_rectTransform.sizeDelta = m_targetSizeDelta;

                if (m_targetSizeDelta == m_initSizeDelta)
                {
                    m_dragImage.SetActive(true);
                    m_fullScreen.SetActive(false);
                }
                else if (m_targetSizeDelta == m_fullSizeDelta)
                {
                    m_fullScreen.SetActive(true);
                }
            }
        }
    }


    private bool IsMoving()
    {
        return m_isMoving || m_isSizing;
    }


    public void OnDrag(BaseEventData eventData)
    {
        if (IsMoving() || m_fullScreen.activeInHierarchy)
        {
            return;
        }

        transform.position = Input.mousePosition;
        m_isMoving = false;
    }


    public void OnDragEnd(BaseEventData eventData)
    {
        if (IsMoving() || m_fullScreen.activeInHierarchy)
        {
            return;
        }

        Vector2 position = m_rectTransform.anchoredPosition;

        float[] borderDistance = new float[4];
        borderDistance[0] = m_maxHeight - position.y;
        borderDistance[1] = position.y + m_maxHeight;
        borderDistance[2] = position.x + m_maxWidth;
        borderDistance[3] = m_maxWidth - position.x;

        int closestIndex = 0;
        float closestDistance = borderDistance[closestIndex];
        for (int i = 1; i < borderDistance.Length; i++)
        {
            if (closestDistance > borderDistance[i])
            {
                closestIndex = i;
                closestDistance = borderDistance[i];
            }
        }

        SetTargetPosition(closestIndex);
    }


    private void SetTargetPosition(int direction)
    {
        m_startPosition = m_rectTransform.anchoredPosition;
        m_targetPosition = m_rectTransform.anchoredPosition;
        switch (direction)
        {
            case 0:
                m_targetPosition.y = m_maxHeight - m_rectTransform.sizeDelta.y / 2;
                break;
            case 1:
                m_targetPosition.y = -m_maxHeight + m_rectTransform.sizeDelta.y / 2;
                break;
            case 2:
                m_targetPosition.x = -m_maxWidth + m_rectTransform.sizeDelta.x / 2;
                break;
            case 3:
                m_targetPosition.x = m_maxWidth - m_rectTransform.sizeDelta.y / 2;
                break;
        }

        m_moveTimer = 0;
        m_isMoving = true;
    }


    public void OnPointerDown(BaseEventData eventData)
    {
        if (IsMoving() || m_fullScreen.activeInHierarchy)
        {
            return;
        }

        m_pointerDownTime = Time.realtimeSinceStartup;
    }


    public void OnPointerUp(BaseEventData eventData)
    {
        if (IsMoving() || m_fullScreen.activeInHierarchy)
        {
            return;
        }

        float pointerUpTime = Time.realtimeSinceStartup;
        if (pointerUpTime - m_pointerDownTime > 0.1f)
        {
            return;
        }

        m_dragImage.SetActive(false);

        Vector2 temp = m_startPosition;
        m_startPosition = m_targetPosition;
        m_targetPosition = Vector2.zero;
        m_startSizeDelta = m_initSizeDelta;
        m_targetSizeDelta = m_fullSizeDelta;

        m_sizeTimer = 0;
        m_isSizing = true;
    }


    public void OnFullScreenCloseButtonClicked()
    {
        if (IsMoving())
        {
            return;
        }

        m_targetPosition = m_startPosition;
        m_startPosition = Vector2.zero;
        m_startSizeDelta = m_fullSizeDelta;
        m_targetSizeDelta = m_initSizeDelta;

        m_sizeTimer = 0;
        m_isSizing = true;
    }
}

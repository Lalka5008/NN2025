using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HelpAnnotation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string ToolTip;
    public Vector2 offset = new Vector2(20, 20);
    public TextMeshProUGUI HelpText;

    private Coroutine _showCoroutine;
    private bool _isShowed;

    private void Start()
    {
        // �������� ����� ��� ������
        HelpText.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ������������� ���������� ��������, ���� ����
        if (_showCoroutine != null)
            StopCoroutine(_showCoroutine);

        _showCoroutine = StartCoroutine(ShowAfterDelay());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ������������� �������� � �������� �����
        if (_showCoroutine != null)
            StopCoroutine(_showCoroutine);

        HideTooltip();
    }

    private IEnumerator ShowAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        ShowTooltip();
    }

    private void ShowTooltip()
    {
        _isShowed = true;
        HelpText.text = ToolTip;
        HelpText.gameObject.SetActive(true);
        UpdateTooltipPosition();
    }

    private void HideTooltip()
    {
        _isShowed = false;
        HelpText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isShowed)
        {
            UpdateTooltipPosition();
        }
    }

    private void UpdateTooltipPosition()
    {
        HelpText.transform.position = (Vector2)Input.mousePosition + offset;
    }
}
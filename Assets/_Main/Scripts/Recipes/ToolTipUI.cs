using UnityEngine;
using UnityEngine.UI;

public class ToolTipUI : MonoBehaviour
{
    [SerializeField] private Button close;

    private void Awake()
    {
        close.onClick.AddListener(() => Hide());
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

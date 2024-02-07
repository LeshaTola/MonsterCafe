using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipUI : MonoBehaviour
{
    [SerializeField] private Button close;
    [SerializeField] private TextMeshProUGUI orderName;

    private void Awake()
    {
        close.onClick.AddListener(() => Hide());
    }

    private void Start()
    {
        Hide();
    }

    public void Show(string name)
    {
        gameObject.SetActive(true);
        orderName.text = name;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

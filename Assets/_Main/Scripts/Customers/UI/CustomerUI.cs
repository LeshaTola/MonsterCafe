using UnityEngine;
using UnityEngine.UI;

public class CustomerUI : MonoBehaviour
{
    [SerializeField] private Button popUp;
    [SerializeField] private PopUpAnimation popUpAnimation;
    [SerializeField] private Customer customer;
    private ToolTipUI toolTipUI;
    private void OnEnable()
    {
        customer.OnOrderWaiting += Show;
        customer.OnOrderCompleted += Hide;
    }

    private void OnDisable()
    {
        customer.OnOrderWaiting -= Show;
        customer.OnOrderCompleted -= Hide;
    }

    private void Start()
    {
        toolTipUI = customer.ToolTipUI;
        popUp.onClick.AddListener(() => toolTipUI.Show());
    }


    public void Show()
    {
        popUpAnimation.Show();
    }

    public void Hide()
    {
        popUpAnimation.Hide();
    }
}

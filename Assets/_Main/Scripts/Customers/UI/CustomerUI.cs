using UnityEngine;
using UnityEngine.UI;

public class CustomerUI : MonoBehaviour
{
    [SerializeField] private Button popUp;
    [SerializeField] private PopUpAnimation popUpAnimation;
    [SerializeField] private Customer customer;
    [SerializeField] private CustomerOrder order;
    private ToolTipUI toolTipUI;

    private void OnEnable()
    {
        customer.OnOrderWaiting += ShowPopUp;
        customer.OnOrderCompleted += HidePopUp;
    }

    private void OnDisable()
    {
        customer.OnOrderWaiting -= ShowPopUp;
        customer.OnOrderCompleted -= HidePopUp;
    }

    private void Start()
    {
        toolTipUI = customer.ToolTipUI;
        popUp.onClick.AddListener(() => toolTipUI.Show(order.OrderRecipe.Name));
    }


    public void ShowPopUp()
    {
        popUpAnimation.Show();
    }

    public void HidePopUp()
    {
        popUpAnimation.Hide();
    }
}

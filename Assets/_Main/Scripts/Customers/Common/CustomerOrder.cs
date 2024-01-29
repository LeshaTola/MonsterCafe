using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField] private Customer customer;
    private OrderSentry order;

    public MergingRecipeSO OrderRecipe { get; private set; }

    private void Start()
    {
        transform.parent.TryGetComponent(out order);
        customer.OnOrderWaiting += GetOrderRecipe;
    }

    private void OnDestroy()
    {
        customer.OnOrderWaiting -= GetOrderRecipe;
    }

    private void GetOrderRecipe()
    {
        OrderRecipe = order.ChooseOrder();
    }
}

using UnityEngine;


[CreateAssetMenu(fileName = "Customer", menuName = "Customers/Customer", order = 51)]
public class CustomerSO : ScriptableObject
{
    [field: SerializeField] public float MoveDuration { get; private set; } = 5f;

    [field: SerializeField] public float WaitDuration { get; private set; } = 15f;
}

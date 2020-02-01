using UnityEngine;

public class Barcode : MonoBehaviour
{
	public Product Product;

	public void OnBought()
	{
		Product.OnBought();
	}
}
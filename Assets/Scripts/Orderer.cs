using TMPro;
using UnityEngine;

public class Orderer : Node
{
    private float counter;
    public TextMeshProUGUI infoText;
    public GameObject deliveringBar;
    public GameObject shipper;
    public string foodInfo;
    public Food foodType;
    public Node nearestNode;

    //private void Start()
    //{
    //    counter = 30;
    //    shipper = null;
    //}
    private void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            if (this.shipper != null)
            {
                var shipper = this.shipper.GetComponent<Shipper>();
                shipper.isTakenFood = false;
                shipper.orderPosition = null;
                shipper.path.Clear();
            }
            GameManager.Instance.LoseMoney(this.foodType);
            gameObject.SetActive(false);
        }
        DisplayInfo();
    }

    private void DisplayInfo()
    {
        int timeRemain = (int)counter;
        infoText.SetText(foodInfo + " - " + timeRemain.ToString());
        if (shipper == null)
            deliveringBar.SetActive(false);
        else
            deliveringBar.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == this.shipper)
        {
            var shipper = other.gameObject.GetComponent<Shipper>();
            if (!shipper.isTakenFood)
                return;
            shipper.isTakenFood = false;
            shipper.orderPosition = null;
            shipper.targetPoint = nearestNode;
            shipper.path.Clear();
            GameManager.Instance.GainMoney(this.foodType);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        foodType = (Food)Random.Range(0, 2);
        counter = 10;
        shipper = null;
        switch (foodType)
        {
            case Food.Pizza: foodInfo = "Pizza"; break;
            case Food.BanhMi: foodInfo = "Banh Mi"; break;
                //default: break;
        }
    }
}
public enum Food
{
    Pizza,
    BanhMi
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<InventoryListItem> itemList;

    public ItemSO itemToUse;

    public int itemIndex;
    [SerializeField] int itemCount;

    [SerializeField] private GameObject[] Seeds; 
    private int currentIndex = 0;
    private int pressCount = 0;
    [SerializeField] GameObject rocCam;

    [SerializeField] Color selectedColor;
    [SerializeField] Color defaultColor;

    [SerializeField] GameObject inventoryUI;
    [SerializeField] bool isOpened;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        itemCount = itemList.Count;
        SelectItem(0);
        inventoryUI.SetActive(false);
    }
    public void CollectItem(ItemSO _item) //her bir yeni item toplarken kullanýlar fonksiyon
    {
        foreach (InventoryListItem item in itemList)
        {
            if (item.itemInfo == _item)
            {
                item.iitemcount++;
                item.itemCountM.text = item.iitemcount.ToString() + " / " + item.itemInfo.goalCount.ToString();
                break;
            }
            else if (item.itemInfo == null)
            {
                Color _color = Color.white;
                _color.a = 1;
                item.itemImage.color = _color;

                item.itemImage.sprite = _item.itemSprite;
                item.itemInfo = _item;
                itemToUse = itemList[itemIndex].itemInfo; //seçili olan item bilgisini güncelleme burada da çalýþmalý ki ilki kullanýlabilsin.
                item.iitemcount++;
                //item.itemCountM.text = item.iitemcount.ToString();
                item.itemCountM.text = item.iitemcount.ToString() + " / " + item.itemInfo.goalCount.ToString();
                item.itemCountM.gameObject.SetActive(true);
                return;
            }
        }
    }
    public void SelectItem(int _delta)
    {
        itemList[itemIndex].BGImage.color = defaultColor;//item deðiþtirmeden hemen önce, az önce seçili olan item'in arkaplanýný normale çevirme

        itemIndex += _delta;//fonksiyon içine gönderilen "mouse scroll" yönüne göre seçili envanter index'ini deðiþtirme

        if (itemIndex < 0) //index'in sýfýrýn altýna inmesini ve envanter limitini geçmesini engelleme
        {
            itemIndex = itemCount - 1;
        }
        else if (itemIndex > itemCount - 1)
        {
            itemIndex = 0;
        }

        itemList[itemIndex].BGImage.color = selectedColor;//item deðiþtikten sonra, yeni seçilmiþ itemin arkaplanýný deðiþtirme
        itemToUse = itemList[itemIndex].itemInfo;//seçili olan item bilgisini güncelleme // bunu collectItema ekle
    }
    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0) //scroll tuþu ile envanterde seçim yapmak 
        {
            SelectItem((int)Input.mouseScrollDelta.y);
        }

        if (Input.GetKeyDown(KeyCode.F)) //burasý roketi gördüðünde yerleþmesi için veya deniz kabuðunu köprü açmasý gibi yerlerde kullanýlacak ilerde 
        {
            if (itemToUse.itemName == ItemSO.ItemNames.Seed && rocCam.activeSelf)
            {
                UseItem(itemToUse);
                pressCount++;
                GameObject gameObject = Seeds[currentIndex];
                gameObject.SetActive(true);
                currentIndex = (currentIndex + 1) % Seeds.Length;
            }
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            OnOfInventory();
        }
    }

    public void OnOfInventory() //açýksa kapat kapalýysa aç fonksiyonu
    {
        inventoryUI.gameObject.SetActive(!isOpened); 
        isOpened = !isOpened;
    }

    public bool UseItem(ItemSO _item)//eðer kullanmaya çalýþtýðýmýz item, seçili olan item ile ayný türde ise o item'i kullanýr ve True deðeri döndürür
    {
        if (_item == itemToUse)
        {
            if (itemList[itemIndex].iitemcount != 0)
            {
                itemList[itemIndex].iitemcount--;
                itemList[itemIndex].itemCountM.text = itemList[itemIndex].iitemcount.ToString();

            }

            if (itemList[itemIndex].iitemcount == 0)
            {
                itemList[itemIndex].itemCountM.gameObject.SetActive(false);
                itemList[itemIndex].itemImage.sprite = null;

                Color _color = Color.white;
                _color.a = 0;
                itemList[itemIndex].itemImage.color = _color;
                itemList[itemIndex].itemInfo = null;
            }
            return true;
        }

        return false;
    }
    [Serializable]
    public class InventoryListItem
    {
        public Image itemImage;
        public Image BGImage;
        public ItemSO itemInfo;
        public TextMeshProUGUI itemCountM;
        public int iitemcount;
    }
}

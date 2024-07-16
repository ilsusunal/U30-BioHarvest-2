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
    public void CollectItem(ItemSO _item) //her bir yeni item toplarken kullan�lar fonksiyon
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
                itemToUse = itemList[itemIndex].itemInfo; //se�ili olan item bilgisini g�ncelleme burada da �al��mal� ki ilki kullan�labilsin.
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
        itemList[itemIndex].BGImage.color = defaultColor;//item de�i�tirmeden hemen �nce, az �nce se�ili olan item'in arkaplan�n� normale �evirme

        itemIndex += _delta;//fonksiyon i�ine g�nderilen "mouse scroll" y�n�ne g�re se�ili envanter index'ini de�i�tirme

        if (itemIndex < 0) //index'in s�f�r�n alt�na inmesini ve envanter limitini ge�mesini engelleme
        {
            itemIndex = itemCount - 1;
        }
        else if (itemIndex > itemCount - 1)
        {
            itemIndex = 0;
        }

        itemList[itemIndex].BGImage.color = selectedColor;//item de�i�tikten sonra, yeni se�ilmi� itemin arkaplan�n� de�i�tirme
        itemToUse = itemList[itemIndex].itemInfo;//se�ili olan item bilgisini g�ncelleme // bunu collectItema ekle
    }
    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0) //scroll tu�u ile envanterde se�im yapmak 
        {
            SelectItem((int)Input.mouseScrollDelta.y);
        }

        if (Input.GetKeyDown(KeyCode.F)) //buras� roketi g�rd���nde yerle�mesi i�in veya deniz kabu�unu k�pr� a�mas� gibi yerlerde kullan�lacak ilerde 
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

    public void OnOfInventory() //a��ksa kapat kapal�ysa a� fonksiyonu
    {
        inventoryUI.gameObject.SetActive(!isOpened); 
        isOpened = !isOpened;
    }

    public bool UseItem(ItemSO _item)//e�er kullanmaya �al��t���m�z item, se�ili olan item ile ayn� t�rde ise o item'i kullan�r ve True de�eri d�nd�r�r
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

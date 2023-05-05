using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Keyholder : MonoBehaviour
{
    [SerializeField] private keyHolder keyHolder;

    private Transform container;

    private Transform keyTemplate;


    private void Awake()
    {
        container = transform.Find("container");
        keyTemplate = container.Find("KeyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == keyTemplate) continue;
            Destroy(child.gameObject);
        }


        List<key.KeyType> keyList = keyHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++)
        {
            key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTransform.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(100 * i, 0);
            Image KeyImage = keyTransform.Find("image").GetComponent<Image>();
            switch (keyType)
            {
                default:
                case key.KeyType.Red: KeyImage.color = Color.red; break;

                case key.KeyType.Bue: KeyImage.color = Color.blue; break;

                case key.KeyType.Green: KeyImage.color = Color.green; break;
            }

        }
    }


    private void Start()
    {
        keyHolder.OnKeysChange += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

}

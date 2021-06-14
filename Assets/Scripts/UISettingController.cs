using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingController : MonoBehaviour
{
    [SerializeField] Text displayText;
    [SerializeField] InputField inputField;
    [SerializeField] Button editBtn;
    [SerializeField] Button saveBtn;

    bool isOnEdit;

    private void Start() {
        isOnEdit = false;
        displayText.gameObject.SetActive(true);
        inputField.gameObject.SetActive(false);
        editBtn.gameObject.SetActive(true);
        saveBtn.gameObject.SetActive(false);

        editBtn.onClick.AddListener(OnEditBtnClick);
        saveBtn.onClick.AddListener(OnSaveBtnClick);
    }

    void OnEditBtnClick(){
        displayText.gameObject.SetActive(false);
        inputField.gameObject.SetActive(true);
        editBtn.gameObject.SetActive(false);
        saveBtn.gameObject.SetActive(true);

        inputField.text = displayText.text;
    }

    void OnSaveBtnClick(){
        displayText.gameObject.SetActive(true);
        inputField.gameObject.SetActive(false);
        editBtn.gameObject.SetActive(true);
        saveBtn.gameObject.SetActive(false);

        displayText.text = inputField.text;

        // TODO: Sync to Server
    }
}

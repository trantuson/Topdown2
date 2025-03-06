using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login_Register : MonoBehaviour
{
    [SerializeField] private GameObject panel_Login;
    [SerializeField] private GameObject panel_Register;

    // Login
    [SerializeField] private TMP_InputField inputField_Email_Login;
    [SerializeField] private TMP_InputField inputField_Password_Login;

    // Register
    [SerializeField] private TMP_InputField inputField_Email_Register;
    [SerializeField] private TMP_InputField inputField_Password_Register;
    [SerializeField] private TMP_InputField inputField_RepeatPassword_Registert;

    public void ShowLogin()
    {
        panel_Login.SetActive(true);
        panel_Register.SetActive(false);
    }
    public void ShowRegister()
    {
        panel_Register.SetActive(true);
        panel_Login.SetActive(false);
    }

    public void Login()
    {
        string email = inputField_Email_Login.text.Trim();
        string password = inputField_Password_Login.text.Trim();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.Log("Vui lòng điền đầy đủ thông tin");
            return;
        }
        if(PlayerPrefs.HasKey(email))
        {
            string passwordSave = PlayerPrefs.GetString(email);
            if(password == passwordSave)
            {
                Debug.Log("Đăng nhập thành công!");
                SceneManager.LoadScene("PlayGame");
            }
            else
            {
                Debug.Log("Tài khoản hoặc mật khẩu không đúng!");
                return;
            }
        }
        else
        {
            Debug.Log("Tài khoản hoặc mật khẩu không đúng!");
            return;
        }
        inputField_Email_Login.text = "";
        inputField_Password_Login.text = "";
    }
    public void Register()
    {
        string email = inputField_Email_Register.text.Trim();
        string password = inputField_Password_Register.text.Trim();
        string repeatPassword = inputField_RepeatPassword_Registert.text.Trim();

        if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatPassword))
        {
            Debug.Log("Vui lòng điền đầy đủ thông tin");
            return;
        }
        if (PlayerPrefs.HasKey(email))
        {
            Debug.Log("Email đã tồn tại");
            return;
        }
        if (password == repeatPassword)
        {
            PlayerPrefs.SetString(email, password);
            PlayerPrefs.Save();
            Debug.Log("Đăng ký thành công!");
        }
        else 
        {
            Debug.Log("Mật khẩu không trùng khớp");
        }
        inputField_Email_Register.text = "";
        inputField_Password_Register.text = "";
        inputField_RepeatPassword_Registert.text = "";
    }
}

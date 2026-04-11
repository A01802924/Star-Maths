using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LoginBD : MonoBehaviour
{
    private Button btnLogin;
    private TextField tfUsuario;
    private TextField tfPassword;


    public static int sesionCompleta;
    public struct MandarDatos
    {
        public string nombre_usuario;
        public string contrasenia;
    }

    public struct RegresarDatos
    {
        public bool exito;
        public string aviso;
        public int sesionId;
    }


    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        tfUsuario = root.Q<TextField>("Usuario");
        tfPassword = root.Q<TextField>("Contrasenia");
        btnLogin = root.Q<Button>("Ingresar");
        btnLogin.clicked += () =>
        {
            StartCoroutine(Login());
        };
    }


    private IEnumerator Login() //para el api el IEnumerator (el tipo de dato que se utiliza)
{
    MandarDatos data = new MandarDatos
    {
        nombre_usuario = tfUsuario.value,
        contrasenia = tfPassword.value,
    };

    string json = JsonUtility.ToJson(data);

    
    UnityWebRequest request = UnityWebRequest.Post("http://18.233.166.175:8080/login", json, "application/json"); //aqui esta el unitywebrequest el url esta declarado hasta arriba y post para enviar los datos al servidor 
 

    yield return request.SendWebRequest(); //yo regreso de la funcion mientras, es lo que hace que regrese de inmediato arriba es el segundo thread de la programacion espera a que se complete la solicitud web antes de continuar con el siguiente paso

    if (request.result == UnityWebRequest.Result.Success)
        {
            print("Respuesta: " + request.downloadHandler.text);

            RegresarDatos r = JsonUtility.FromJson<RegresarDatos>(request.downloadHandler.text);

            if (r.exito)
            {
                sesionCompleta = r.sesionId;
                SceneManager.LoadScene("MenuPrincipalScene");
            }
            else
            {
                print("Login fallido: " + r.aviso);
            }
        }
        else
        {
            print("Error: " + request.error);
        }
    }

}
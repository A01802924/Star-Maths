using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Assets.Scripts.Core;
public class LoginBD : MonoBehaviour
{
    private Button btnLogin;
    private TextField tfUsuario;
    private TextField tfPassword;
    private VisualElement errorDialogContainer;
    private Label errorDialogTitleLabel;
    private Label errorDialogBodyLabel;
    private Label signInExceptionLabel;
    private Button closeDialogContainerButton;
    private Button acceptDialogContainerButton;
    public static LoginBD instance;
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
        public int id_jugador;
    }
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        errorDialogContainer = root.Q<VisualElement>("ErrorDialogContainer");
        errorDialogTitleLabel = root.Q<Label>("ErrorTitleLabel");
        errorDialogBodyLabel = root.Q<Label>("ErrorDescriptionLabel");
        closeDialogContainerButton = root.Q<Button>("CloseErrorDialog");
        acceptDialogContainerButton = root.Q<Button>("AcceptErrorDialog");
        signInExceptionLabel = root.Q<Label>("SignInExceptionLabel");
        closeDialogContainerButton.clicked += CloseErrorDialog;
        acceptDialogContainerButton.clicked += CloseErrorDialog;

        tfUsuario = root.Q<TextField>("Usuario");
        tfPassword = root.Q<TextField>("Contrasenia");
        btnLogin = root.Q<Button>("Ingresar");
        btnLogin.clicked += () =>
        {
            AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
            StartCoroutine(Login());
        };
    }
    private void CloseErrorDialog()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickFormerWindow);
        errorDialogContainer.style.display = DisplayStyle.None;
    }
    private IEnumerator Login() // para el api el IEnumerator (el tipo de dato que se utiliza)
    {
        if (tfUsuario.value != "" && tfPassword.value != "")
        {
            signInExceptionLabel.style.display = DisplayStyle.None;
            MandarDatos data = new()
            {
                nombre_usuario = tfUsuario.value,
                contrasenia = tfPassword.value,
            };

            string json = JsonUtility.ToJson(data);

            UnityWebRequest request = UnityWebRequest.Post("https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/login", json, "application/json"); //aqui esta el unitywebrequest el url esta declarado hasta arriba y post para enviar los datos al servidor 

            yield return request.SendWebRequest(); // yo regreso de la funcion mientras, es lo que hace que regrese de inmediato arriba es el segundo thread de la programacion espera a que se complete la solicitud web antes de continuar con el siguiente paso

            if (request.result == UnityWebRequest.Result.Success)
            {
                print("Respuesta: " + request.downloadHandler.text);

                RegresarDatos r = JsonUtility.FromJson<RegresarDatos>(request.downloadHandler.text);

                if (r.exito)
                {
                    id_juador_instance.instance.id_jugador = r.id_jugador;
                    SessionData.ClearGameData();
                    yield return StartCoroutine(GetComponent<ConfiguracionBD>().ObtenerConfiguracion()); // get para obtener la configuración del jugador después de iniciar sesión exitosamente, se espera a que se complete antes de continuar a cargar la escena del menú principal
                    yield return StartCoroutine(GetComponent<CustomizeBD>().ObtenerSelectedItems(null)); // get para obtener los items seleccionados del jugador después de iniciar sesión exitosamente, se espera a que se complete antes de continuar a cargar la escena del menú principal                    
                    print("Login exitoso, id_jugador: " + r.id_jugador);
                    SceneManager.LoadScene("MenuPrincipalScene");
                }
                else
                {
                    errorDialogTitleLabel.text = "Inicio de sesión fallido";
                    errorDialogBodyLabel.text = "Credenciales incorrectas.\nIntenta de nuevo";
                    errorDialogContainer.style.display = DisplayStyle.Flex;
                    print("Login fallido: " + r.aviso);
                }
            }
            else
            {
                errorDialogTitleLabel.text = "Error de conexión";
                errorDialogBodyLabel.text = request.error;
                errorDialogContainer.style.display = DisplayStyle.Flex;
                print("Error: " + request.error);
            }
        }
        else
        {
            signInExceptionLabel.text = "Campos faltantes";
            signInExceptionLabel.style.display = DisplayStyle.Flex;
        }
    }

}
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class RegistroBD : MonoBehaviour
{

    //obtenemos variables para el UI
    private TextField tfUsuario;
    private TextField tfPassword;
    private TextField tfcorreoElectronico;
    private TextField tfNombre;
    private TextField tfApellido;
    private TextField tfFechaNacimiento;
    private RadioButton rbgMasculino;
    private RadioButton rbgFemenino;
    private DropdownField dfGrado;
    private Button btnRegistrar;

     public struct MandarDatos
    {
        public string nombre_usuario;
        public string corre_electronico;
        public string contrasenia;
        public string genero;
        public string nombre;
        public string apellidos;
        public string fecha_nacimiento;
        public int grado_escolar;
    }
    public struct RegresarDatos
    {
        public bool exito;
        public string aviso;
         public int id_jugador;
    }

     void OnEnable()
     {
         var root = GetComponent<UIDocument>().rootVisualElement;

         tfUsuario = root.Q<TextField>("Usuario2");
         tfPassword = root.Q<TextField>("Contrasenia2");
         tfcorreoElectronico = root.Q<TextField>("CorreoElectronico");
         tfNombre = root.Q<TextField>("NombreJugador");
         tfApellido = root.Q<TextField>("ApellidoJugador");
         tfFechaNacimiento = root.Q<TextField>("FechaNacimiento");
         rbgMasculino = root.Q<RadioButton>("Nino");
         rbgFemenino = root.Q<RadioButton>("Nina");
         dfGrado = root.Q<DropdownField>("Grado");
         btnRegistrar = root.Q<Button>("Ingresar2");

         btnRegistrar.clicked += () =>
         {
             StartCoroutine(Registrar());
         };
     }

     private IEnumerator Registrar()
     {
        //Mandar datos config para el registro
        MandarDatos data = new MandarDatos
        {
            nombre_usuario = tfUsuario.value,
            corre_electronico = tfcorreoElectronico.value,
            contrasenia = tfPassword.value,
            genero = rbgMasculino.value ? "masculino" : "femenino",
            nombre = tfNombre.value,
            apellidos = tfApellido.value,
            fecha_nacimiento = tfFechaNacimiento.value,
            grado_escolar = int.Parse(dfGrado.value)
        };
        string json = JsonUtility.ToJson(data);

        UnityWebRequest request = UnityWebRequest.Post("https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/registro", json, "application/json"); 
        
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            print("Respuesta: " + request.downloadHandler.text);

            RegresarDatos r = JsonUtility.FromJson<RegresarDatos>(request.downloadHandler.text);

            if (r.exito)
            {
                id_juador_instance.instance.id_jugador = r.id_jugador;
                print("Login exitoso, id_jugador: " + r.id_jugador);
                SceneManager.LoadScene("MenuPrincipalScene");
            }
            else
            {
                Debug.LogError("Error en el registro: " + r.aviso);
            }
        }
        else
        {
            Debug.LogError("Error en la solicitud: " + request.downloadHandler.text);
        }


     }


}

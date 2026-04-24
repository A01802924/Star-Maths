using System;
using System.Collections;
using System.Linq;
using OMG.UI.DatePickerUITK;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class RegistroBD : MonoBehaviour
{
    private TextField tfUsuario;
    private TextField tfPassword;
    private TextField tfcorreoElectronico;
    private TextField tfNombre;
    private TextField tfApellido;
    private TextField tfFechaNacimiento;
    private DropdownField dfGrado;
    private Button btnRegistrar;
    private RadioButtonGroup genreOptionsGroup;
    private VisualElement errorDialogContainer;
    private Label errorDialogTitleLabel;
    private Label errorDialogBodyLabel;
    private Label signUpExceptionLabel;
    private Button closeDialogContainerButton;
    private Button acceptDialogContainerButton;
    private DatePicker datePicker;
    private VisualElement datePickerContainer;
    private Button calendarButton;
    private Label birthDateSelected;
    Z
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        tfUsuario = root.Q<TextField>("Usuario2");
        tfPassword = root.Q<TextField>("Contrasenia2");
        tfcorreoElectronico = root.Q<TextField>("CorreoElectronico");
        tfNombre = root.Q<TextField>("NombreJugador");
        tfApellido = root.Q<TextField>("ApellidoJugador");
        tfFechaNacimiento = root.Q<TextField>("FechaNacimiento");
        dfGrado = root.Q<DropdownField>("Grado");
        btnRegistrar = root.Q<Button>("Ingresar2");
        genreOptionsGroup = root.Q<RadioButtonGroup>("Genero");
        signUpExceptionLabel = root.Q<Label>("SignUpExceptionLabel");

        errorDialogContainer = root.Q<VisualElement>("ErrorDialogContainer");
        errorDialogTitleLabel = root.Q<Label>("ErrorTitleLabel");
        errorDialogBodyLabel = root.Q<Label>("ErrorDescriptionLabel");
        closeDialogContainerButton = root.Q<Button>("CloseErrorDialog");
        acceptDialogContainerButton = root.Q<Button>("AcceptErrorDialog");
        signUpExceptionLabel = root.Q<Label>("SignUpExceptionLabel");

        datePickerContainer = root.Q<VisualElement>("DatePickerContainer");
        datePicker = root.Q<DatePicker>("DatePicker");
        calendarButton = root.Q<Button>("CalendarButton");
        birthDateSelected = root.Q<Label>("BirthDateValue");

        datePickerContainer.RegisterCallback<ClickEvent>(TryHidingDatePicker);
        datePicker.RegisterValueChangedCallback(SelectNewBirthDate);

        calendarButton.clicked += ShowDatePicker;
        closeDialogContainerButton.clicked += CloseErrorDialog;
        acceptDialogContainerButton.clicked += CloseErrorDialog;

        btnRegistrar.clicked += () =>
        {
            StartCoroutine(Registrar());
        };
    }
    private void SelectNewBirthDate(ChangeEvent<DateTime?> evt)
    {
        birthDateSelected.text = evt.newValue?.ToString("yyyy-MM-dd");
        birthDateSelected.style.display = DisplayStyle.Flex;
        datePickerContainer.style.display = DisplayStyle.None;
    }
    private void TryHidingDatePicker(ClickEvent evt)
    {
        if (evt.target == evt.currentTarget)
        {
            datePickerContainer.style.display = DisplayStyle.None;
        }
    }
    private void ShowDatePicker()
    {
        datePickerContainer.style.display = DisplayStyle.Flex;
    }
    private void CloseErrorDialog()
    {
        errorDialogContainer.style.display = DisplayStyle.None;
    }
    private IEnumerator Registrar()
    {
        if (
            tfUsuario.value != "" &&
            tfcorreoElectronico.value != "" &&
            tfPassword.value != "" &&
            tfNombre.value != "" &&
            tfApellido.value != "" &&
            birthDateSelected.text != "" &&
            genreOptionsGroup.value != -1 &&
            dfGrado.index != -1
        )
        {
            string generoUI = genreOptionsGroup.choices.ElementAt(genreOptionsGroup.value);

            string generoBD;

                if (generoUI == "Niña")
                    generoBD = "femenino";
                else if (generoUI == "Niño")
                    generoBD = "masculino";
                else
                    generoBD = "otro";
            signUpExceptionLabel.style.display = DisplayStyle.None;
            MandarDatos data = new()
            {
                nombre_usuario = tfUsuario.value,
                corre_electronico = tfcorreoElectronico.value,
                contrasenia = tfPassword.value,
                genero = generoBD,
                nombre = tfNombre.value,
                apellidos = tfApellido.value,
                fecha_nacimiento = birthDateSelected.text,
                grado_escolar = int.Parse(dfGrado.value)
            };

            Debug.Log("Genero enviado: " + data.genero);
Debug.Log("Grado enviado: " + data.grado_escolar);
Debug.Log("Fecha enviada: " + data.fecha_nacimiento);

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
                    errorDialogTitleLabel.text = "Error en el registro";
                    errorDialogBodyLabel.text = r.aviso;
                    errorDialogContainer.style.display = DisplayStyle.Flex;
                    Debug.LogError("Error en el registro: " + r.aviso);
                }
            }
            else
            {
                errorDialogTitleLabel.text = "Error de conexión";
                errorDialogBodyLabel.text = request.downloadHandler.text;
                errorDialogContainer.style.display = DisplayStyle.Flex;
                Debug.LogError("Error en la solicitud: " + request.downloadHandler.text);
            }
        }
        else
        {
            signUpExceptionLabel.text = "Campos faltantes";
            signUpExceptionLabel.style.display = DisplayStyle.Flex;
        }
    }
}

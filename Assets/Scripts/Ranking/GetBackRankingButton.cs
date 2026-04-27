using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GetBackRankingButton : MonoBehaviour
{
    private Button getBackButton;
    private Button web;
    private ScrollView rankingScrollView;

    // Lista procesada para la interfaz
    private List<(int pos, string name, int score)> rankingValues = new();

    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();

        getBackButton = root.Q<Button>("GetBackButton");
        rankingScrollView = root.Q<ScrollView>("RankingContainer");
        web = root.Q<Button>("WebButton");

        getBackButton.clicked += GetBack;
        web.clicked += AbrirWeb;

        rankingScrollView.Q<Label>("NullRowsLabels").style.display = DisplayStyle.None;
        
        // Limpiar filas iniciales
        rankingScrollView.Clear();
    }

    void OnEnable()
    {
        StartCoroutine(ranking());
    }

    private IEnumerator ranking()
    {
        // Se asume que id_juador_instance ya está configurado correctamente
        int playerId = id_juador_instance.instance.id_jugador;

        UnityWebRequest request = UnityWebRequest.Get(
            "https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/ranking/" + playerId
        );

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Deserializamos usando las clases con los nombres corregidos
            RegresarDatos r = JsonUtility.FromJson<RegresarDatos>(request.downloadHandler.text);

            if (r != null && r.exito)
            {
                rankingValues.Clear();
                rankingScrollView.Clear();

                // Procesamos cada posición (Verificamos que el nombre no esté vacío como en tu top2)
                if (r.top1 != null && !string.IsNullOrEmpty(r.top1.nombre_usuario)) 
                    rankingValues.Add((1, r.top1.nombre_usuario, r.top1.puntaje_total));
                
                if (r.top2 != null && !string.IsNullOrEmpty(r.top2.nombre_usuario)) 
                    rankingValues.Add((2, r.top2.nombre_usuario, r.top2.puntaje_total));
                
                if (r.top3 != null && !string.IsNullOrEmpty(r.top3.nombre_usuario)) 
                    rankingValues.Add((3, r.top3.nombre_usuario, r.top3.puntaje_total));
                
                if (r.top4 != null && !string.IsNullOrEmpty(r.top4.nombre_usuario)) 
                    rankingValues.Add((4, r.top4.nombre_usuario, r.top4.puntaje_total));

                // Añadimos tu puntaje personal al final
                if (r.mipuntaje != null)
                {
                    rankingValues.Add((r.posicion, r.mipuntaje.nombre_usuario, r.mipuntaje.puntaje_total));
                }

                // Dibujar en la interfaz
                foreach (var user in rankingValues)
                {
                    rankingScrollView.Add(RankingUIs.BuildRankingRow(user.pos, user.name, user.score));
                }
            }
        }
        else
        {
            Debug.LogError("Error en la petición: " + request.error);
        }
    }

    private void GetBack() => SceneManager.LoadScene("Informacion");
    private void AbrirWeb() => Application.OpenURL("http://star-maths.s3-website-us-east-1.amazonaws.com/ranking.html");

    // --- CLASES CORREGIDAS SEGÚN TU JSON ---
    [System.Serializable]
    public class UsuarioRanking
    {
        // Estos nombres DEBEN ser iguales a los del JSON de la imagen
        public string nombre_usuario; 
        public int puntaje_total;
    }

    [System.Serializable]
    public class RegresarDatos
    {
        public bool exito;
        public UsuarioRanking top1;
        public UsuarioRanking top2;
        public UsuarioRanking top3;
        public UsuarioRanking top4;
        public UsuarioRanking mipuntaje;
        public int posicion;
    }
}
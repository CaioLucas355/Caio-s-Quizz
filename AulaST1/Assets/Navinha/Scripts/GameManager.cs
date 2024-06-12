using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instancia;

    [Header("Menu")]
    public GameObject painelInicio;
    public GameObject painelGameplay;
    public GameObject painelGameover;


    [Header("Pontua��o")]
    public int score;
    public TMP_Text scoreText;

    [Header("Gerador de Alans")]
    public GameObject objetoAlan;
    public Transform[] geradoresAlan;
    public float taxaAlan;

    private void Awake()
    {
        Instancia = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        painelInicio.SetActive(true);
        painelGameplay.SetActive(false);
        painelGameover.SetActive(false);
    }

    public void IniciarJogo()
    {
        painelInicio.SetActive(false);
        painelGameplay.SetActive(true);
        StartCoroutine(GerarAlan());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AlterarScore(int valor)
    {
        score += valor;
        scoreText.text = "SCORE: " + score;
    }
    IEnumerator GerarAlan()
    {
        int rnd = Random.Range(0, geradoresAlan.Length);
        Instantiate(objetoAlan, geradoresAlan[rnd].position , Quaternion.identity);
        yield return new WaitForSeconds(taxaAlan);
        StartCoroutine(GerarAlan());
    }
    public void GameOver()
    {
        StartCoroutine(FinalizarJogo());
        
    }
    IEnumerator FinalizarJogo() 
    {
        painelGameplay.SetActive(false );
        painelGameover.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

}

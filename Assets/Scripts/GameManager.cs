using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public bool GameStarted = false;
    public bool GameEnded;
    public List<GameObject> GoodCollactables = new List<GameObject>();
    public List<GameObject> BadCollactables = new List<GameObject>();
    [SerializeField] private bool once = true;
    [SerializeField] private TextMeshProUGUI Starttext;
     public TextMeshProUGUI FailText;
     public Animator anim;
     public Animator badanim;
     public Animator defBadanim;
     public Animator GoodAnim;
     public List<Transform> stairs = new List<Transform>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && once)
        {
            GameStarted = true;
            once = false;
            Starttext.gameObject.SetActive(false);
            anim.SetTrigger(Animator.StringToHash("walkTrigger"));
           
          
           
          
        }
    }

    public void ColorCollactables(Color color)
    {
        for (int i = 0; i < GoodCollactables.Count; i++)
        {
           MeshRenderer col = GoodCollactables[i].GetComponent<MeshRenderer>();
           col.material.color = color;
        }
    }

    public void Fail()
    {
        FailText.gameObject.SetActive(true);
        badanim.SetTrigger((Animator.StringToHash("fail")));
        defBadanim.SetTrigger(Animator.StringToHash("fail"));
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

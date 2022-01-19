using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerCollitions : MonoBehaviour
{
   public enum CharecterType {Artist,BadArtist, Scientist,BadScientist, Lawyer, BadLawyer ,Default};

   public GameObject defaultModel;
   public GameObject artistModel;
   public GameObject lawyerModel; 
   public GameObject scientistModel;
   public GameObject BadArtistModel;
   public GameObject BadscientistModel;
   public GameObject BadLawyerModel;
   public GameObject GoodArtistModel;
   public GameObject GoodscientistModel;
   public GameObject GoodLawyerModel;
   public int collactableScore;
  

   [SerializeField] private MeshRenderer scicentistMeshRenderer;
   [SerializeField] private MeshRenderer artistMeshRenderer;
   [SerializeField] private MeshRenderer LawyerMeshRenderer;
   [SerializeField] public int score = 0 ;
   [SerializeField] private bool good = false;
   [SerializeField] private bool bad = false;
   [SerializeField] public Vector3 endpos = new Vector3();
   public ScoreBar scoreBar;
   public  int currentState;
   
   private GameManager gameManager;

    public CharecterType currentCharacterType = CharecterType.Default;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        scoreBar.Slider.value = 0;

    }

    private void Update()
    {
        
        if (score >= 180)
        {
            switch (currentState)
            {
                case 1 : 
                    OnTypeGoodArtist();
                    gameManager.GoodAnim.SetTrigger(Animator.StringToHash("walk"));
                    good = true;
                    break;
                case 2 :
                    OnTypeGoodLawyer();
                    good = true;

                    break;
                case 3 :
                    OnTypeGoodSci();
                    good = true;

                    break;
                    
                    
                    
            }

            
        }
        
        if (score < 0)
        {
            switch (currentState)
            {
                case 1 :
                    OnTypeBadArtist();
                   gameManager.badanim.SetTrigger(Animator.StringToHash("walk"));
                    bad = true;
                    break;
                case 2 :
                    OnTypeBadSci();
                    bad = true;
                    break;
                case 3 :
                    OnTypeBadLawyer();
                    bad = true;
                    break;
                        
                    
            }
        }
    }

    
    public void ChangeState(CharecterType targetType)
    {
        CloseAllModels();
        switch (targetType)
        {
            case CharecterType.Artist:
                OnTypeArtist();
               gameManager.defBadanim.SetTrigger(Animator.StringToHash("walk"));
                break;
            
            case CharecterType.Scientist:
                OnTypeSci();
                break;
            
            case CharecterType.Lawyer:
                OnTypeLawyer();
                break;
            
            case CharecterType.BadLawyer:
                OnTypeBadLawyer();
                break;
            
            case CharecterType.BadArtist:
                OnTypeBadArtist();
                break;
            
            case CharecterType.BadScientist:
                OnTypeBadSci();
                break;
            
        }
    }

    public void CloseAllModels()
    {
        artistModel.SetActive(false);
        lawyerModel.SetActive(false);
        scientistModel.SetActive(false);
        defaultModel.SetActive(false);
    }

    private void OnTypeArtist()
    {
        artistModel.SetActive(true);
        gameManager.ColorCollactables(artistMeshRenderer.sharedMaterial.color);
        
    } private void OnTypeSci()
    {
        scientistModel.SetActive(true);
        gameManager.ColorCollactables(scicentistMeshRenderer.sharedMaterial.color);
        
    } 
    private void OnTypeLawyer()
    {
        lawyerModel.SetActive(true);
        gameManager.ColorCollactables(LawyerMeshRenderer.sharedMaterial.color);
        
    }
    
    private void OnTypeBadLawyer()
    {
        BadLawyerModel.SetActive(true);
        lawyerModel.SetActive(false);
        Debug.Log("bad lawyer");
        
        
    }
    
    private void OnTypeBadArtist()
    {
       BadArtistModel.SetActive(true);
       artistModel.SetActive(false);
      // Debug.Log("bad artist");
        
    }
    
    private void OnTypeBadSci()
    {
        BadscientistModel.SetActive(true);
        scientistModel.SetActive(false);
        Debug.Log("bad sci");
      
        
    }
    
    private void OnTypeGoodLawyer()
    {
        GoodLawyerModel.SetActive(true);
        lawyerModel.SetActive(false);
        Debug.Log("good lawyer");
        
        
    }
    
    private void OnTypeGoodArtist()
    {
       GoodArtistModel.SetActive(true);
       artistModel.SetActive(false);
        Debug.Log("Good artist");
        
    }
    
    private void OnTypeGoodSci()
    {
        BadscientistModel.SetActive(true);
        scientistModel.SetActive(false);
        Debug.Log("good sci");
      
        
    }




    public void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("artist"))
      {
        
          ChangeState(CharecterType.Artist);
          
          currentState = 1;

      }
       
       if (other.CompareTag("scientist"))
      {
         ChangeState(CharecterType.Scientist);
         currentState = 2;


      }
       if (other.CompareTag("lawyer"))
      {
        ChangeState(CharecterType.Lawyer);
        currentState = 3;

      }
     


       if (other.CompareTag("good"))
       {
           score += collactableScore;
           scoreBar.SetScore(score);
           Destroy(other.gameObject);
       }

       if (other.CompareTag("bad"))
       {
           score -= collactableScore;
           scoreBar.SetScore(score);

           Destroy(other.gameObject);
       }

       if (other.CompareTag("stair1"))
       {
           CameraManager.Instance.ActivateCamera(0);
           gameManager.GameEnded = true;
           if (bad == true)
           {
            gameManager.Fail();
              
           }

           if (score <= 0)
           {
               gameManager.Fail();
           }

           if (good = true)
           {
               for (int i = 0 ; i< gameManager.stairs.Count ; i++)
               {
                   if (score >= 45)
                   {
                       endpos = new Vector3(gameManager.stairs[i].position.x, gameManager.stairs[i].position.y,gameManager.stairs[i].position.z);
                       transform.DOMove(endpos, 2f).OnComplete((() => {gameManager.defBadanim.SetTrigger(Animator.StringToHash("dance"));}));
                       score -= 45;
                   }
                   
                  
               }
               
           }
          
       }

       if (other.CompareTag("finish"))
       {
           gameManager.GoodAnim.SetTrigger(Animator.StringToHash("handshake"));
           gameManager.FinalCharAnim.SetTrigger(Animator.StringToHash("handShake"));
           gameManager.GoodAnim.SetBool("walk" ,false);
       }
   }

    
}

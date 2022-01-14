using System;
using System.Collections;
using System.Collections.Generic;
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
  

   [SerializeField] private MeshRenderer scicentistMeshRenderer;
   [SerializeField] private MeshRenderer artistMeshRenderer;
   [SerializeField] private MeshRenderer LawyerMeshRenderer;
   [SerializeField] public int score = 0 ;
   public  int currentState;
   
   private GameManager gameManager;

    public CharecterType currentCharacterType = CharecterType.Default;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (score > 8)
        {
            switch (currentState)
            {
                case 1 : 
                    OnTypeGoodArtist();
                    break;
                case 2 :
                    OnTypeGoodLawyer();
                    break;
                case 3 :
                    OnTypeGoodSci();
                    break;
                    
                    
                    
            }

            
        }
        
        if (score < -2)
        {
            gameManager.GameEnded = true;
            gameManager.FailText.gameObject.SetActive(true);
            switch (currentState)
            {
                case 1 :
                    OnTypeBadArtist();
                   
                    break;
                case 2 :
                    OnTypeBadSci();
                   
                    break;
                case 3 :
                    OnTypeBadLawyer();
                  
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
       Debug.Log("bad artist");
        
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
           score += 2;
           Destroy(other.gameObject);
       }

       if (other.CompareTag("bad"))
       {
           score -= 2;
           Destroy(other.gameObject);
       }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState{
    menu,
    inGame,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;

    public static GameManager sharedInstance;
    //Creacion de las instancias pára el señor obcuro 
    private void Awake(){
        if(sharedInstance == null){
        sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            StartGame();
        }
    }
//metodo para empezar el juego 
    public void StartGame(){
        SetGameState(GameState.inGame);
    }
    //Para terminar la partida 
    public void GameOver(){
        SetGameState(GameState.GameOver);
    }
    //Estado para regresar al menu 
    public void BackToMenu(){
        SetGameState(GameState.menu);
    }
    private void SetGameState(GameState newGameState){
        //coloca los estados dentro del juego  
        if (newGameState == GameState.menu ){
            //TODO: coloca el estado del menu
        }else  if (newGameState == GameState.inGame){

        }else if(newGameState == GameState.GameOver){

        }

        this.currentGameState = newGameState;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementSousMarin : MonoBehaviour
{

    //Variable pouvant contenir une valeur de type Rigidbody
    private Rigidbody _rb;
    private Vector3 _direction;

    private Vector3 _directionVerticale;

    [SerializeField] private float _forceHaut;
    [SerializeField] private float _forceVitesse;

    //-------------------------------------------------------------------------------


    void Start()
    {
        //Donne une valeur à la variable _rb lorsque le script s’exécute
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        BougerSousMarin();
        DivingSousMarin();
    }


    //-------------------------------------------------------------------------------

    //Méthode qui s’exécute lorsque les touches W, S, A, D, sont enfoncées
    void OnMove(InputValue valeur)
    {

        Debug.Log(valeur);

        //Paramètre nécessaire pour récupérer les entrées sous la forme d’un Vector2 ((x, y)), lorsqu’une des touches W, S, A, D, est enfoncée
        Vector2 _valeurRecues = valeur.Get<Vector2>(); //  (0,0) (-1,0) (0,-1) (1,0) (1,0)
        _direction = new Vector3(_valeurRecues.x, 0, _valeurRecues.y);

    }

    void OnMonteDescend(InputValue valeur){
        float _valeurRecues = valeur.Get<float>();
        _directionVerticale = new Vector3(0, _valeurRecues, 0);

    }

    //-------------------------------------------------------------------------------


    void BougerSousMarin()
    {
        _rb.AddForce(_direction * Time.deltaTime * _forceVitesse, ForceMode.VelocityChange);

        

    }

    void DivingSousMarin(){

        _rb.AddForce(_directionVerticale * Time.deltaTime * _forceHaut, ForceMode.VelocityChange);

    }

}




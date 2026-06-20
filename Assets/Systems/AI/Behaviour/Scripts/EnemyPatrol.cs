using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private CharacterController2D characterController;
    private Life life;

    //[SerializeField]private Vector2

    //        [SerializeField] private Transform[] patrolPathPoints;

    [SerializeField] private float maxXValue = 5;
    [SerializeField] private float maxYValue = 5;
    [SerializeField] float maxSecondsSameDirection = 2f;
    private float directionSecondsCounter = 0f;
    private Vector2 movementDirection = Vector2.zero;


    private void Awake()
    {
        //Cacheamos el componente de character controller y de vida
        this.characterController = GetComponent<CharacterController2D>();
        this.life = GetComponent<Life>();
    }

    private void OnEnable()
    {
        //De momento los enemigos simplemente escucharán al evento OnLifeDepleted (cuando la barra de vida llega a su fin)
        this.life.onLifeDepleted.AddListener(OnLifeDepleted);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Patrol());
    }

    private void OnDisable()
    {
        //De momento los enemigos simplemente escucharán al evento OnLifeDepleted (cuando la barra de vida llega a su fin)
        this.life.onLifeDepleted.RemoveListener(OnLifeDepleted);
    }

    private void OnLifeDepleted(float startLife)
    {
        //Destruimos el gameobject del enemigo
        Destroy(this.gameObject);
    }

    IEnumerator Patrol()
    {

        this.movementDirection = SetNewDestiny();
        this.characterController.SetRawMove(movementDirection);

        while (true)
        {
            this.directionSecondsCounter += Time.deltaTime;

            if (CheckChangeDirection())
            {
                this.movementDirection = SetNewDestiny();
            }

            yield return null;
            this.characterController.SetRawMove(this.movementDirection);

        }

    }

    private Vector2 SetNewDestiny()
    {
        //Hayamos una dirección aleatoria:
        float randomXCoordinate = Random.Range(-1f, 1f);
        float randomYCoordinate = Random.Range(-1f, 1f);

        Vector2 searchDirection = new Vector2(randomXCoordinate, randomYCoordinate).normalized;

        //Reseteamos el contador de segundos de movimeinto en la misma dirección:
        this.directionSecondsCounter = 0;

        return searchDirection;

    }

    private bool CheckChangeDirection()
    {
        if (this.directionSecondsCounter >= this.maxSecondsSameDirection)
        {
            return true;
        }
        else
            return false;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

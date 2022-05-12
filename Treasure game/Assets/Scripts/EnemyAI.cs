using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // private Vector3 startingPosition;
    // private Vector3 roamPosition;
    // private EnemyPathFindingMovement pathfindingMovement;

    // private void Awake() {
    //     pathfindingMovement.GetComponent<EnemyPathFindingMovement>();
    // }

    // // start position
    // private void Start() 
    // {
    //     startingPosition = transform.position;
    //     roamPosition = GetRoamingPosition();
    // }

    // private void Update() {
    //     pathfindingMovement.MoveTo(roamPosition);
    //     pathfindingMovement.MoveTo(roamPosition);
    //     if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance) {
    //         // re
    //     }
    // }

    // // Generate random normalized direction
    // public static Vector3 GetRandomDir() {
    //     return new Vector3(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    // }

    // // random roaming position
    // public Vector3 GetRoamingPosition() {
    //     return startingPostion + GetRandomDir() * Random.Range(10f, 70f);
    // }
//------------------------------------------------------------------
    // public NavMeshAgent agent;

    // public Transform player;

    // public LayerMask whatIsGround, whatIsPlayer;

    // //Patrolling
    // public Vector3 walkPoint;
    // bool walkPointSet;
    // public float walkPointRange;

    //Attacking
    // public float timeBetweenAttacks;
    // bool alreadyAttacked;

    // //States
    // public float sighRange, attackRange;
    // public bool playerInSigtRange, playerInAttackRange;

    // private void Awake() {
    //     player = GameObject.Find("Girl").transform;
    //     agent = GetComponent<NavMeshAgent>();
    // }

    // private void Update() {
    //     //Check for sight and attack range
    //     playerInSigtRange = Physics.Check
    // }

    // private void Patrolling() {

    // }
}

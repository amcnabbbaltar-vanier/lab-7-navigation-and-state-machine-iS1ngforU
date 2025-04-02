using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackState : IState
{
    private AIController aiController;
    
    public StateType Type => StateType.Attack;

    public AttackState(AIController aiController)
    {
        this.aiController = aiController;
    }

    public void Enter()
    {
        aiController.Animator.SetBool("isAttacking", true);
        aiController.Agent.isStopped = true; 
    }

    public void Execute()
    {
        //check if the player is in range of attack
        if(Vector3.Distance(aiController.transform.position, aiController.Player.position)
        > aiController.AttackRange)
        {
            //if the player moves away, transition back to chaseState
            aiController.StateMachine.TransitionToState(StateType.Chase);
            return;
        }
    }

    public void Exit()
    {
    aiController.Animator.SetBool("isAttacking", true);
    aiController.Agent.isStopped = false; // Resume the AI agent movement
    }  
}

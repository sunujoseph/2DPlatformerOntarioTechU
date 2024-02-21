using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using System.Collections;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            

            player.StartCoroutine(waitForSpawn(player));

            
            
        }

        private IEnumerator waitForSpawn(PlayerController player)
        {

            //player.playerAnimator.PlayAnimation("Death");


            player.collider2d.enabled = true;
            player.controlEnabled = false;
            if (player.audioSource && player.respawnAudio)
                player.audioSource.PlayOneShot(player.respawnAudio);



            player.Teleport(model.spawnPoint.transform.position);
            player.jumpState = PlayerController.JumpState.Grounded;
            player.playerAnimator.PlayAnimation("Spawn");
            //player.animator.SetBool("dead", false);
            model.virtualCamera.m_Follow = player.transform;
            model.virtualCamera.m_LookAt = player.transform;
            yield return new WaitForSeconds(1);
            Simulation.Schedule<EnablePlayerInput>(1f);

            player.health.Increment();
        }
    }
}
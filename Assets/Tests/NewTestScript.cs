using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class PlayerMovementTest
{
    private GameObject playerObj;
    private PlayerMovement player;
    private Rigidbody2D rb;

    [SetUp]//E
    public void Setup()
    {
        playerObj = new GameObject();
        rb = playerObj.AddComponent<Rigidbody2D>();
        player = playerObj.AddComponent<PlayerMovement>();

        player.groundCheck = new GameObject().transform;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(playerObj);
    }

    [UnityTest]
    //mozgas
        public IEnumerator MovesLeft_WhenInputIsNegative()
        {
            player.moveSpeed = 5f;
            player.SetMoveInput(-1f);

            yield return new WaitForFixedUpdate();

            Assert.AreEqual(-5f, rb.linearVelocity.x, 0.01f);
        }
    [UnityTest]
    //ugras
        public IEnumerator Jump_Works_WhenGrounded()
        {
            player.jumpForce = 10f;

            // set grounded manually
            typeof(PlayerMovement)
                .GetField("isGrounded", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(player, true);

            player.TryJump(true);

            yield return null;

            Assert.AreEqual(10f, rb.linearVelocity.y, 0.01f);
        }
    [UnityTest]
    //foldon van e a jatekos
    public IEnumerator DetectsGroundCorrectly()
    {
        var ground = new GameObject();
        ground.layer = LayerMask.NameToLayer("Ground");
        ground.AddComponent<BoxCollider2D>();

        player.groundLayer = LayerMask.GetMask("Ground");
        player.groundCheck.position = ground.transform.position;

        yield return null;

        player.Update();

        bool isGrounded = (bool)typeof(PlayerMovement)
            .GetField("isGrounded", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(player);

        Assert.IsTrue(isGrounded);
    }
}

/*using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementPlayModeTests
{
    private GameObject CreatePlayer()
    {
        var player = new GameObject("Player");

        player.AddComponent<SpriteRenderer>();
        player.AddComponent<Rigidbody2D>();
        player.AddComponent<BoxCollider2D>();

        var animator = player.AddComponent<Animator>();
        var movement = player.AddComponent<PlayerMovement>();

        // GroundCheck létrehozása
        var groundCheck = new GameObject("GroundCheck");
        groundCheck.transform.SetParent(player.transform);
        groundCheck.transform.localPosition = Vector3.zero;

        movement.groundCheck = groundCheck.transform;

        return player;
    }

    [UnityTest]
    public IEnumerator PlayerStartsWith10Hp()
    {
        var player = CreatePlayer();
        var movement = player.GetComponent<PlayerMovement>();

        yield return null;

        Assert.AreEqual(10, movement.hp);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator KnockbackChangesVelocity()
    {
        var player = CreatePlayer();
        var movement = player.GetComponent<PlayerMovement>();
        var rb = player.GetComponent<Rigidbody2D>();

        yield return null;

        movement.Knockback(Vector2.right, 5f);

        yield return new WaitForFixedUpdate();

        Assert.Greater(rb.linearVelocity.x, 0);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator HpReductionWorks()
    {
        var player = CreatePlayer();
        var movement = player.GetComponent<PlayerMovement>();

        yield return null;

        movement.hp -= 3;

        Assert.AreEqual(7, movement.hp);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator MoveSpeedHasValidValue()
    {
        var player = CreatePlayer();
        var movement = player.GetComponent<PlayerMovement>();

        yield return null;

        Assert.Greater(movement.moveSpeed, 0);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator JumpForceHasValidValue()
    {
        var player = CreatePlayer();
        var movement = player.GetComponent<PlayerMovement>();

        yield return null;

        Assert.Greater(movement.jumpForce, 0);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator RigidbodyExists()
    {
        var player = CreatePlayer();

        yield return null;

        Assert.IsNotNull(player.GetComponent<Rigidbody2D>());

        Object.Destroy(player);
    }
}*/

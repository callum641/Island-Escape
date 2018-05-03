using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EnemyAttackTest {

	[Test]
	public void EnemyAttackTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator EnemyAttackTestWithEnumeratorPasses() {
        GameObject enemy = new GameObject();
        GameObject player = new GameObject();
        int playerHealth = 3;
        int newPlayerHealth = 3;

        enemy.transform.position = player.transform.position;
        if (enemy.transform.position == player.transform.position)
        {
            newPlayerHealth -= 1;
        }

        yield return new WaitForFixedUpdate();
        Assert.AreNotEqual(newPlayerHealth, playerHealth);
    }
}

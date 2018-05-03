using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CharacterAttackTest {

	[Test]
	public void CharacterAttackTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator CharacterAttackTestWithEnumeratorPasses() {
        int enemyHealth = 3;
        int newEnemyHealth = 0;
        GameObject enemy = new GameObject();
        GameObject player = new GameObject();
        bool keypressed = true;

        if (keypressed == true)
        {
            newEnemyHealth = enemyHealth - 1;
        }
        yield return new WaitForFixedUpdate();
        Assert.AreNotEqual(newEnemyHealth, enemyHealth);
    }
}

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class EnemyMovementTest {

	[Test]
	public void EnemyMovementTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator EnemyMovementTestWithEnumeratorPasses() {
        GameObject go = new GameObject();
        go.AddComponent<Rigidbody2D>();
        var originalPosition = go.transform.position;
        go.transform.position += go.transform.right * 5;
       



        yield return new WaitForFixedUpdate();
        Assert.AreNotEqual(originalPosition, go.transform.position);
    }
}

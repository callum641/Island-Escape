using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayerMovement {

	[Test]
	public void PlayerMovementSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator PlayerMovementWithEnumeratorPasses() {

        GameObject go = new GameObject();
        go.AddComponent<Rigidbody2D>();
        var originalPosition = go.transform.position;

        go.transform.position = new Vector3(10, 0, 0);



        yield return new WaitForFixedUpdate();
        Assert.AreNotEqual(originalPosition, go.transform.position);
    }
}

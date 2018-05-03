using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class RotationTest {

	[Test]
	public void RotationTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator RotationTestWithEnumeratorPasses() {
        GameObject rotation = new GameObject();
        bool faceLeft = true;
        bool faceRight = false;
        bool faceUp = false;
        bool faceDown = false;
        int rotationCount = 1;

        if (faceLeft == true) {
            rotation.transform.eulerAngles = new Vector3(0, 180, 0);
            if (rotation.transform.eulerAngles == new Vector3(0, 180, 0)) {
                rotationCount += 1;
            }
            faceRight = true;
            faceLeft = false;
        }
        if (faceRight == true)
        {
            rotation.transform.eulerAngles = new Vector3(0, 0, 0);
            if (rotation.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                rotationCount += 1;
            }
            faceUp = true;
            faceRight = false;
        }
        if (faceUp == true)
        {
            rotation.transform.eulerAngles = new Vector3(0, 0, 90);
            if (rotation.transform.eulerAngles == new Vector3(0, 0, 90))
            {
                rotationCount += 1;
            }
            faceDown = true;
            faceUp = false;
        }
        if (faceDown == true)
        {
            rotation.transform.eulerAngles = new Vector3(0, 0, -90);
            if (rotation.transform.eulerAngles == new Vector3(0, 0, -90))
            {
                rotationCount += 1;
            }
            faceDown = false;
        }

        yield return new WaitForFixedUpdate();
        Assert.AreEqual(4, rotationCount);
	}
}

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class WinTest : MonoBehaviour
{

	[Test]
	public void WinTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator WinTestWithEnumeratorPasses() {
        bool Win = false;
       int score = 0;
      int newscore = score + 1;
        if (newscore == 1)
        {
           Win = true;
        }
        yield return new WaitForFixedUpdate();
        Assert.IsTrue(Win);


	}
}

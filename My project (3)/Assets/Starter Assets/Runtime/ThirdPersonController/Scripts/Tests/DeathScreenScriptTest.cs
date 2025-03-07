using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DeathScreenScriptTest
{
    [UnityTest]
    public IEnumerator SimpleStubTest()
    {
        Debug.Log("Running stub test...");
        yield return null;
        Assert.IsTrue(true, "This is a simple stub test that always passes");
    }

    [UnityTest]
    public IEnumerator FailingStubTest()
    {
        Debug.Log("Running failing stub test...");
        yield return null;
        Assert.IsFalse(true, "This test is designed to fail intentionally");
    }
}

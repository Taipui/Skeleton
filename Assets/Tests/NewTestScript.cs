using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TW.Common;

public class NewTestScript
{
    [Test]
    public void ScreenHelperTest()
    {
        Debug.Log($"ScreenWidth: {ScreenHelper.ScreenWidth}");
        Debug.Log($"ScreenHeight: {ScreenHelper.ScreenHeight}");
        Debug.Log($"HalfScreenWidth: {ScreenHelper.HalfScreenWidth}");
        Debug.Log($"HalfScreenHeight: {ScreenHelper.HalfScreenHeight}");
        Debug.Log($"AspectRate: {ScreenHelper.AspectRate}");
        Debug.Log($"NormalizedAspectRate: {ScreenHelper.NormalizedAspectRate}");
    }

    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

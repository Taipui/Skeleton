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

    [Test]
    public void MathHelperTest()
    {
        var intX = 630;
        var intY = 300;
        var gcd  = MathHelper.Gcd(intX, intY);
        Debug.Log($"{intX}と{intY}の最大公約数は{gcd}");

        var floatX = 630.0f;
        var floatY = 300.0f;
        gcd        = MathHelper.Gcd(floatX, floatY);
        Debug.Log($"{floatX:F1}と{floatY:F1}の最大公約数は{gcd}");

        var width      = 1920;
        var height     = 1080;
        var aspectRate = MathHelper.GetAspectRate(width, height);
        Debug.Log($"{width}pxと{height}pxのアスペクト比は{aspectRate.x}:{aspectRate.y}");

        aspectRate = MathHelper.GetNormalizedAspectRate(width, height);
        Debug.Log($"{width}pxと{height}pxのアスペクト比は{aspectRate.x}:{aspectRate.y}");

        var min   = 0;
        var max   = 10;
        var value = 5;
        Debug.Log($"{min}～{max}の中の{value}は、0～1の中の{MathHelper.To01(value, max, min)}");
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

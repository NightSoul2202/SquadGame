using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenScriptTests
{
    private GameObject deathScreenObject;
    private DeathScreenScript deathScreenScript;
    private Button exitButton;
    private Button restartButton;

    [SetUp]
    public void SetUp()
    {
        deathScreenObject = new GameObject("DeathScreen");
        deathScreenScript = deathScreenObject.AddComponent<DeathScreenScript>();
        deathScreenScript.DeathScreen = new GameObject("DeathScreenUI");

        exitButton = new GameObject("ExitButton").AddComponent<Button>();
        restartButton = new GameObject("RestartButton").AddComponent<Button>();
        deathScreenScript.ExitButton = exitButton;
        deathScreenScript.RestartButton = restartButton;

        deathScreenScript.Initialize(); // «м≥нюЇмо на Initialize
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(deathScreenObject);
        Object.DestroyImmediate(deathScreenScript.DeathScreen);
        Object.DestroyImmediate(exitButton.gameObject);
        Object.DestroyImmediate(restartButton.gameObject);
    }

    [Test]
    public void GameOver_SetsDeathScreenActive()
    {
        deathScreenScript.GameOver();
        Assert.IsTrue(deathScreenScript.DeathScreen.activeSelf, "DeathScreen маЇ бути активним");
        Assert.IsTrue(DeathScreenScript.IsMenuOpen, "IsMenuOpen маЇ бути true");
    }

    [Test]
    public void Restart_ResetsMenu()
    {
        deathScreenScript.GameOver();
        deathScreenScript.Restart();
        Assert.IsFalse(DeathScreenScript.IsMenuOpen, "IsMenuOpen маЇ бути false");
    }

    [Test]
    public void Exit_DoesNotThrow()
    {
        Assert.DoesNotThrow(() => deathScreenScript.Exit(), "Exit не маЇ кидати вин€тк≥в");
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AntiPiracy : MonoBehaviour
{
	private string[] allowedHosts =
	{
		"itch.io",
		"itch.zone",
		"v6p9d9t4.ssl.hwcdn.net",
		"file://",
		"localhost",
		"127.0.0.1",
	};

	private void Start()
	{
		if (!Application.isEditor)
			ValidateURL();
	}

	private void ValidateURL()
	{
		if (!IsValidURL(allowedHosts))
			SceneManager.LoadScene("PirateScene");
	}

	private static bool IsValidURL(IEnumerable<string> urls)
	{
		return urls.Any(url => Application.absoluteURL.ToLower().Contains(url));
	}
}
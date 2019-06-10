/* SearchController.cs
 * Gameobject:      search_controller
 * Brief:           This script controls the searching functionality for our image search.
 * Author:          Drew Massey
 * Date Created:    06/09/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class SearchController : MonoBehaviour
{
    #region Public Variables
    public string request = "dog";
    public TMP_InputField m_searchField;
    public Image m_image;
    #endregion Public Variables

    #region Private Variables
    //Put in your own api key from: https://pixabay.com/api/docs/
    private string api_key = "";
    private string api_link = "https://pixabay.com/api/";
    #endregion Private Variables

    #region Properties
    private string Query
    {
        get
        {
            return $"{api_link}?key={api_key}&q={request}";
        }
    }
    #endregion Properties


    #region Methods
    public void OnClick()
    {
        Debug.Log("I was clicked");
        Debug.Log("Search: " + m_searchField.text);

        StartCoroutine(Search());
    }

    IEnumerator LoadImage(string img_url)
    {
        var www = new WWW(img_url);

        yield return www;

        Texture2D texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);

        www.LoadImageIntoTexture(texture);
        Rect rect = new Rect(0, 0, texture.width, texture.height);

        Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f), 100);
        m_image.sprite = sprite;
        m_image.SetNativeSize();
    }

    IEnumerator Search()
    {
        request = m_searchField.text;

        UnityWebRequest www = UnityWebRequest.Get(Query);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            var response = www.downloadHandler.text;
            var dict = MiniJSON.Json.Deserialize(response) as Dictionary<string, object>;
            var hits = dict["hits"] as List<object>;

            if(hits != null && hits.Count > 0)
            {
                var hit = hits[0] as Dictionary<string, object>;

                if(hit != null)
                {
                    var largeImageUrl = hit["largeImageURL"] as string;
                    if (largeImageUrl != null)
                    {
                        Debug.Log("Image URL: " + largeImageUrl);
                        StartCoroutine(LoadImage(largeImageUrl));
                    }
                }
            }
        }
    }
    #endregion Methods
}

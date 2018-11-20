using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour {

    public Renderer textureRenderer;

    public void DrawNoiseMap(float[,] noiseMap) {
        // width gets the 1st dimension of the 2 dimensional array noisemap and that's our width, height gets the 2nd dimension
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        // We are creating an array of colours for each pixel in our texture and at the end setting them all at once
        // which is faster than setting them one by one.

        Color[] colourMap = new Color[width * height];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }
        texture.SetPixels(colourMap);
        texture.Apply();

        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(width, 1f, height);
    }
	
}

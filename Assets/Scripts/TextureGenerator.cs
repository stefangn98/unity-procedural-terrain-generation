using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator {

	public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height) {
        Texture2D texture = new Texture2D (width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;

        texture.SetPixels(colourMap);
        texture.Apply();    

        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap) {
        // width gets the 1st dimension of the 2 dimensional array noisemap and that's our width, height gets the 2nd dimension
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        // We are creating an array of colours for each pixel in our texture and at the end setting them all at once
        // which is faster than setting them one by one.

        Color[] colourMap = new Color[width * height];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }

        return TextureFromColourMap(colourMap, width, height);
    }

}

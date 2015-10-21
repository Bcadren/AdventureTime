using UnityEngine;
using System.Collections;

public class screenMath {

    private int width;
    private int height;
    private Mesh screen;

    public screenMath(int Width, int Height, Mesh Screen)
    {

        width = Width;
        height = Height;
        screen = Screen;

    }

    public int[] lookup(index position)
    {
        int[] arrayPosition = new int[4];

        arrayPosition[0] = ((position.y * width + position.x) * 4);
        arrayPosition[1] = ((position.y * width + position.x) * 4 + 1);
        arrayPosition[2] = ((position.y * width + position.x) * 4 + 2);
        arrayPosition[3] = ((position.y * width + position.x) * 4 + 3);

        return arrayPosition;
    }
    
    public int[] lookup (int x, int y)
    {
        return lookup(new index(x, y));
    }

}

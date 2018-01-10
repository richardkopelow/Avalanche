using System;
using System.Collections.Generic;


public class GlobalValues
{
    public const float BounceDuration = 1f;
    public const float GameWidth = 16;
    public static float GameHeight = 24;
    public static float YOffset =  5;
    public static float Slope
    {
        get
        {
            return -4 * YOffset / GameWidth / GameWidth;
        }
    }
}

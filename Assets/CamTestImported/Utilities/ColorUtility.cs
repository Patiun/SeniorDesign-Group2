using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUtility
{
	// Rough Compare determines if colors are nearly the same, given a threshold.
	// The threshold is the amount that the difference individual color components can be below.
	// For example, if a.r = .925 and b.r = .901, and threshold = .3, then RoughCompare returns true;
	public static bool RoughCompare(Color a, Color b, float threshold)
    {
		if (Mathf.Abs(a.r - b.r) > threshold)
        {
			return false;
		}
        else if (Mathf.Abs(a.g - b.g) > threshold)
        {
			return false;
		}
        else if (Mathf.Abs(a.b - b.b) > threshold)
        {
			return false;
		}
        else if (Mathf.Abs(a.a - b.a) > threshold)
        {
			return false;
		}
		return true;
	}

	public static Vector4 Difference(Color a, Color b)
    {
		return new Vector4
        (
			a.r - b.r,
			a.g - b.g,
			a.b - b.b,
			a.a - b.a
		);
	}
}
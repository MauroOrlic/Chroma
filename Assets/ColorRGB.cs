using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRGB
{
    public float r = 0f;
    public float g = 0f;
    public float b = 0f;

    public ColorRGB(float _r, float _g, float _b)
    {
        r = Mathf.Min(Mathf.Max(_r, 0f), 255f);
        g = Mathf.Min(Mathf.Max(_g, 0f), 255f);
        b = Mathf.Min(Mathf.Max(_b, 0f), 255f);
    }
    public static bool operator ==(ColorRGB a, ColorRGB b)
    {
        if (a.r == b.r && a.g == b.g && a.b == b.b)
        {
            return true;
        }
        return false;
    }
    public static bool operator !=(ColorRGB a, ColorRGB b)
    {
        if (a.r != b.r || a.g != b.g || a.b != b.b)
        {
            return true;
        }
        return false;
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as ColorRGB);
    }
    public bool Equals(ColorRGB other)
    {
        return other != null && r == other.r && g == other.g && b == other.b;
    }

    public override int GetHashCode()
    {
        var hashCode = 352033288;
        hashCode *= -1521134295 + r.GetHashCode();
        hashCode *= -1521134295 + g.GetHashCode();
        hashCode *= -1521134295 + b.GetHashCode();
        return hashCode;
    }

    public static ColorRGB operator +(ColorRGB a, ColorRGB b)
    {
        return new ColorRGB(Mathf.Min(255f, a.r + b.r), Mathf.Min(255f, a.g + b.g), Mathf.Min(255f, a.b + b.b));
    }

    public static ColorRGB operator -(ColorRGB a, ColorRGB b)
    {
        return new ColorRGB(Mathf.Max(0f, a.r - b.r), Mathf.Max(0f, a.g - b.g), Mathf.Max(0f, a.b - b.b));
    }

    public Color getColor()
    {
        return new Color(r / 255f, g / 255f, b / 255f, 1f);
    }

    public bool isElementary()
    {
        return (r == 0f && g == 0f) || (r == 0f && b == 0f) || (g == 0f && b == 0f);
    }
}
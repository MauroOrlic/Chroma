using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCMYK{
    public float c = 0f;
    public float m = 0f;
    public float y = 0f;

    public ColorCMYK(float c, float m, float y){
        this.c = c;
        this.m = m;
        this.y = y;
    }
    public static bool operator== (ColorCMYK a, ColorCMYK b){
        if(a.c == b.c && a.m == b.m && a.y == b.y)
        {
            return true;
        }
        return false;
    }
        public static bool operator!= (ColorCMYK a, ColorCMYK b){
        if(a.c != b.c || a.m != b.m || a.y != b.y)
        {
            return true;
        }
        return false;
    }
    public override bool Equals(object obj){
        return Equals(obj as ColorCMYK);
    }
    public bool Equals(ColorCMYK other){
        return other!= null && c == other.c && m == other.m && y == other.y;
    }

    public override int GetHashCode(){
        var hashCode = 352033288;
        hashCode *= -1521134295 + c.GetHashCode();
        hashCode *= -1521134295 + m.GetHashCode();
        hashCode *= -1521134295 + y.GetHashCode();
        return hashCode;
    }


    public static ColorCMYK operator+ (ColorCMYK a, ColorCMYK b){
        return new ColorCMYK(Mathf.Min(255f,a.c + b.c), Mathf.Min(255f,a.m + b.m), Mathf.Min(255f,a.y + b.y));
    }

    public static ColorCMYK operator- (ColorCMYK a, ColorCMYK b){        
        return new ColorCMYK(Mathf.Max(0f,a.c-b.c), Mathf.Max(0f,a.m-b.m), Mathf.Max(0f,a.y-b.y));        
    }

    public Color getColor(){
        return new Color((255f-c)/255f, (255f-m)/255f, (255f-y)/255f ,1f);
    }
}
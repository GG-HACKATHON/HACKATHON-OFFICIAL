using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : BaseEffect
{
    private Color fadeIndex;
    private SpriteRenderer rdr;
    protected override void Start()
    {
        //base.Start();
        //rdr = target.GetComponent<SpriteRenderer>();
        //fadeIndex = Color.white;
        //fadeIndex.a = rdr.color.a;

        base.Start();

        rdr = target.GetComponent<SpriteRenderer>();
        if (rdr == null)
        {
            Debug.LogError("FadeOut doesn't have SpriteRenderer!");
            Destroy(this.gameObject);
            return;
        }
        rdr = (SpriteRenderer)CopyComponent(rdr, this.gameObject);

        //scaleOriginal = target.transform.localScale;

        fadeIndex = Color.white;
        fadeIndex.a = 1;
    }
    protected override void Update()
    {
        rdr.color = fadeIndex;
        fadeIndex.a = (timer / timeLife);
        base.Update();
    }

    protected override void End()
    {
        rdr.color = Color.white;
        base.End();
    }

    public Component CopyComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        // Copied fields can be restricted with BindingFlags
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }
}

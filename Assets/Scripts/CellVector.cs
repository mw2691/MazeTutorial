using System.Collections;
using System.Collections.Generic;
// TODO: Why is this necessary?
//Unity braucht diese Information, um das Feld im Editor anzeigen zu können
//Bei jeder Skriptänderung serialisiert Unity und aktualisiert die DLLs
[System.Serializable]
public struct CellVector {
    public int x;
    public int z;

    public CellVector(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public static CellVector operator +(CellVector a, CellVector b)
    {
        // TODO: implement the + operator in terms of an element-wise addition
        a.x += b.x;
        a.z += b.z;

        return a;
    }
}
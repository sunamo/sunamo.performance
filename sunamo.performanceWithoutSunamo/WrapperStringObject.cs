using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WrapperStringObject
{
    string s;
    public WrapperStringObject(string s)
    {
        this.s = s;
    }

    public override string ToString()
    {
        return s;
    }
}

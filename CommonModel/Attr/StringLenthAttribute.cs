using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel.Attr
{
    public class StringLenthAttribute: Attribute
    {
        public string ErrprMsg { get; set; }
        public int MaxLenth { get; set; }
        public int MinLenth { get; set; }
    }
}

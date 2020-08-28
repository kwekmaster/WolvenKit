﻿using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Editors;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;

namespace WolvenKit.CR2W.Types
{
    [REDMeta(EREDMetaInfo.REDStruct)]
    public class SMaterialGraphParameter : CVariable
    {
        [RED] public CUInt8 Type { get; set; }
        [RED] public CUInt8 Offset { get; set; }
        [RED] public CName Name { get; set; }


        public SMaterialGraphParameter(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }

        public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name)
        {
            return new SMaterialGraphParameter(cr2w, parent, name);
        }


        public override string ToString()
        {
            return "";
        }
    }
}
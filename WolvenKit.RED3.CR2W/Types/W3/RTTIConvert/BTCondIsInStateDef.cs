using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class BTCondIsInStateDef : IBehTreeConditionalTaskDefinition
	{
		[Ordinal(1)] [RED("stateName")] 		public CName StateName { get; set;}

		[Ordinal(2)] [RED("ifNot")] 		public CBool IfNot { get; set;}

		public BTCondIsInStateDef(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}
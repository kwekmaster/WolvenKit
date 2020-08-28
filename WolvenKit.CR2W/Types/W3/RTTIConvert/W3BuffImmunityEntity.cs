using System.IO;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;
using static WolvenKit.CR2W.Types.Enums;


namespace WolvenKit.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class W3BuffImmunityEntity : CGameplayEntity
	{
		[RED("immunities", 2,0)] 		public CArray<CEnum<EEffectType>> Immunities { get; set;}

		[RED("range")] 		public CFloat Range { get; set;}

		[RED("isActive")] 		public CBool IsActive { get; set;}

		[RED("actorsInRange", 2,0)] 		public CArray<CHandle<CActor>> ActorsInRange { get; set;}

		public W3BuffImmunityEntity(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new W3BuffImmunityEntity(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}
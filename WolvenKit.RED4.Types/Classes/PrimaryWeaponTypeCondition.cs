using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	public partial class PrimaryWeaponTypeCondition : workIScriptedCondition
	{
		[Ordinal(0)] 
		[RED("weaponType")] 
		public CEnum<WorkspotWeaponConditionEnum> WeaponType
		{
			get => GetPropertyValue<CEnum<WorkspotWeaponConditionEnum>>();
			set => SetPropertyValue<CEnum<WorkspotWeaponConditionEnum>>(value);
		}

		public PrimaryWeaponTypeCondition()
		{
			PostConstruct();
		}

		partial void PostConstruct();
	}
}

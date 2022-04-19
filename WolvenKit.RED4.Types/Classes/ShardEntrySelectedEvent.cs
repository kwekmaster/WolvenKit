using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	public partial class ShardEntrySelectedEvent : redEvent
	{
		[Ordinal(0)] 
		[RED("hash")] 
		public CUInt32 Hash
		{
			get => GetPropertyValue<CUInt32>();
			set => SetPropertyValue<CUInt32>(value);
		}

		public ShardEntrySelectedEvent()
		{
			PostConstruct();
		}

		partial void PostConstruct();
	}
}

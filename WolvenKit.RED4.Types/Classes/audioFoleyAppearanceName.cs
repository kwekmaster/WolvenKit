using static WolvenKit.RED4.Types.Enums;

namespace WolvenKit.RED4.Types
{
	public partial class audioFoleyAppearanceName : audioAudioMetadata
	{
		[Ordinal(1)] 
		[RED("void")] 
		public CBool Void
		{
			get => GetPropertyValue<CBool>();
			set => SetPropertyValue<CBool>(value);
		}

		public audioFoleyAppearanceName()
		{
			PostConstruct();
		}

		partial void PostConstruct();
	}
}

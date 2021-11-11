
namespace NetCoreExamples.BestPractices.SOLID.OpenClosed.FirstExample.Refactor.Delivery
{
	using System.Collections.Generic;

	internal class Factory
	{
		private readonly Dictionary<CountryEnum, IDelivery> deliveryDictionary;

		#region Singleton pattern

		private static Factory instance;

		private Factory()
		{
			deliveryDictionary = new Dictionary<CountryEnum, IDelivery>
			{
				{ CountryEnum.Colombia, new ColombiaDelivery() },
				{ CountryEnum.Mexico, new MexicoDelivery() }
			};
		}

		public static Factory Instance
		{
			get
			{
				if (instance == null)
					instance = new Factory();

				return instance;
			}
		}

		#endregion

		public IDelivery Get(CountryEnum country)
		{
			IDelivery result = null;

			if (deliveryDictionary.ContainsKey(country))
				result = deliveryDictionary[country];

			return result;
		}
	}
}

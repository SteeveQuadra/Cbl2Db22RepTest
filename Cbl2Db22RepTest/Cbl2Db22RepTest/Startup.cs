using Cbl2Db22RepTest.Configuration;
using Cbl2Db22RepTest.Dal;
using Cbl2Db22RepTest.Models;
using Cbl2Db22RepTest.Services;
using Cbl2Db22RepTest.ViewModels;
using Cbl2Db22RepTest.Views;

namespace Cbl2Db22RepTest
{
	internal class Startup
	{
		public Startup()
		{
		}

		public void ConfigureServices(SimpleInjector.Container services)
		{
			services.Register<MainPage>();
			services.Register<HeaderStackLayout>();
			services.Register<ServerConnection>();
			services.Register<ListVendeur>();
			services.Register<ListInformations>();

			services.Register<FuturAcquereur>();
			services.Register<Adresse>();
			services.Register<Aquereur>();
			services.Register<Vendeur>();
			services.Register<Financement>();
			services.Register<Enfant>();
			services.Register<Server>();
			services.Register<SynchroEx>();
			services.Register<Reservation>();
			services.Register<Programme>();
			services.Register<Lot>();
			services.Register<DefaultVendeur>();
			services.Register<Option>();

			services.Register<VM_ListVendeur>();
			services.Register<VM_ServerConnection>();
			services.Register<VM_Informations>();

			services.Register<IDataBaseGetter, DataBaseGetter>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IDataBaseSaver, DataBaseSaver>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IDataBaseLoader, DataBaseLoader>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IDataBaseIndexesCreator, DataBaseIndexesCreator>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IReplicatorGetter, ReplicatorGetter>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IReplicatorStatus, ReplicatorStatus>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IDbConfigurationGetter, DbConfigurationGetter>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IDbConfigurationSaver, DbConfigurationSaver>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IPropertyValueGetter, PropertyValueGetter>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IDefaultVendeurGetter, DefaultVendeurGetter>(SimpleInjector.Lifestyle.Singleton);

			services.Register<ISituationFamilleDal, SituationFamilleDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<ICommuneDal, CommuneDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IFuturAcquereurDal, FuturAcquereurDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IServerDal, ServerDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<ITypeFinancementDal, TypeFinancementDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<ISynchroExDal, SynchroExDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IProgrammeDal, ProgrammeDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IReservationDal, ReservationDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<ILotDal, LotDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IVendeurDal, VendeurDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IDefaultVendeurDal, DefaultVendeurDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IConstructeurDal, ConstructeurDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<ICiviliteDal, CiviliteDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IPaysDal, PaysDal>(SimpleInjector.Lifestyle.Singleton);
			services.Register<IOptionDal, OptionDal>(SimpleInjector.Lifestyle.Singleton);
		}
	}
}
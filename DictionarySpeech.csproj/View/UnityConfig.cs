using Speech.BusinessLogic.Contracts.Interfaces;
using Speech.BusinessLogic.Implementations;
using Speech.Data.Context;
using Speech.Data.Contracts.Interfactes;
using Speech.Data.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DictionarySpeech.csproj.View
{
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static IUnityContainer GetNewConfiguredContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {

            container.RegisterType<ISpeechRepository, SpeechRepository>();
            container.RegisterType<ISpeechManager, SpeechManager>();
            container.RegisterType<SpeechContext>();

            //            container.RegisterType<IExceptionFilter, GlobalExceptionFilterAttribute>();

        }
    }
}

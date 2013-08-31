using Munq;

namespace Log.Ioc
{
    public class Container
    {
        #region Private Variables 

        private static readonly IocContainer container = new IocContainer();

        #endregion

        #region Public Methods

        public static T Resolve<T>()
            where T : class
        {
            return container.Resolve<T>();
        }

        public static T Resolve<T>(string name)
            where T : class
        {
            return container.Resolve<T>(name);
        }

        public static void Register<T, TK>() 
            where T : class
            where TK : class, T
        {
            container.Register<T, TK>();
        }

        public static void RegisterInstance<T>(T instance)
            where T : class 
        {
            container.RegisterInstance(instance);
        }

        #endregion
    }
}

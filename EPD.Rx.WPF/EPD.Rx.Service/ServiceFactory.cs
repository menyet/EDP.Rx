namespace EPD.Rx.Service
{
    static class ServiceFactory
    {
        public static IService GetService()
        {
            return new Service();
        }
    }
}

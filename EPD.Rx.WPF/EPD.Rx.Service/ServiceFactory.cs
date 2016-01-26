namespace EPD.Rx.Service
{
    public static class ServiceFactory
    {
        public static IService GetService()
        {
            return new Service();
        }
    }
}

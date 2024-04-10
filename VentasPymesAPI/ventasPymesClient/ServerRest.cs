namespace ventasPymesClient
{
    [Serializable]
    public enum Protocol
    {
        HTTP,
        HTTPS
    }
    internal class ServerRest
    {
        public string host { get; set; }
        public int port { get; set; }
        public string token { get; set; }
        public Protocol protocol { get; set; }
    }
}

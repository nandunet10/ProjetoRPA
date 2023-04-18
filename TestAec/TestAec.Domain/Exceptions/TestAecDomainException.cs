namespace TestAec.Domain.Exceptions
{
    public class TestAecDomainException : Exception
    {
        public TestAecDomainException()
        { }

        public TestAecDomainException(string message)
            : base(message)
        { }

        public TestAecDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

using Castle.DynamicProxy;

namespace Document.Aspects.Logging.Console
{
    public class ConsoleLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Method.DeclaringType}_{invocation.Method.Name}";

            // execute the intercepted method -- other aspects may be 'stacked' and they
            // will be called before the final method proceeds...
            System.Console.WriteLine($"Document is valid, passing from aspect to invocation... ");
            invocation.Proceed();
            System.Console.WriteLine($"After executing proceed by aspect invocation... ");

        }
    }
}

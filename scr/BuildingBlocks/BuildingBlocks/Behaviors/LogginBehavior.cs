using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LogginBehavior<TRequest, TResponse> 
        (ILogger<LogginBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle request={Request} - Response={Response} - RequestData={RequestData}",
                typeof(TRequest).Name, typeof(TResponse).Name, request);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();
            var TimeTaken = timer.Elapsed;
            if(TimeTaken.Seconds > 3)
            {
                logger.LogInformation("[PERFORMANCE] Handle request={Request} took ={TimeTaken}",
                typeof(TRequest).Name, TimeTaken.Seconds);
            }

            logger.LogInformation("[END] Handle request={Request} - with={Response}",
                typeof(TRequest).Name, typeof(TResponse).Name);

            return response;
        }
    }
}

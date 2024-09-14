﻿
using BaselinkerConnector.Application.Contracts;

namespace BaselinkerConnector.Application.Configuration.Commands
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync(ICommand command);

        Task EnqueueAsync<T>(ICommand<T> command);
    }
}
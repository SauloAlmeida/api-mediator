namespace ApiMediator.Core.Base.Handlers
{
    public class Command : SimpleSoft.Mediator.Command
    {
    }

    public class CommandResult<TResult> : SimpleSoft.Mediator.Command<TResult>
    {
    }
}

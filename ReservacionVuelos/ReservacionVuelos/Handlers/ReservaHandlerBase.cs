using ReservacionVuelos.DTOs;

namespace ReservacionVuelos.Handlers
{
    public abstract class ReservaHandlerBase : IReservaHandler
    {
        protected IReservaHandler _nextHandler;

        public void SetNext(IReservaHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public virtual void Handle(ReservaContext context)
        {
            _nextHandler?.Handle(context);
        }
    }
}

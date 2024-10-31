using ReservacionVuelos.DTOs;

namespace ReservacionVuelos.Handlers
{
    public interface IReservaHandler
    {
        void SetNext(IReservaHandler nextHandler);
        void Handle(ReservaContext context);
    }
}

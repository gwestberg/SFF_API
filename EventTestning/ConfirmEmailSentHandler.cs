using System;
using System.Threading.Tasks;
using SFF_API.Repositories;

public class ConfirmEmailSentHandler : IEventHandler<RentalReturnedEvent>
{
    private readonly IRentalRepository _rentalRepository;
    public ConfirmEmailSentHandler(IRentalRepository rentalRepository)
    {
        _rentalRepository = rentalRepository;
    }

    public Task RunAsync(RentalReturnedEvent obj)
    {

        return Task.Run(() =>
        {
            Console.WriteLine("Confirm Email Sent.");
        });
    }
}
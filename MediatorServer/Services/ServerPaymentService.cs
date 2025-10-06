using Shared.Core.Models;

namespace MediatorServer.Services
{
    public class ServerPaymentService
    {
        private decimal _balance;
        private readonly List<ServerPaymentRecord> _history = new();

        public ServerPaymentService(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        public bool Charge(decimal amount, string endpoint)
        {
            if (_balance < amount)
                return false;

            _balance -= amount;

            _history.Add(new ServerPaymentRecord
            {
                Timestamp = DateTime.UtcNow,
                Endpoint = endpoint,
                Amount = amount,
                BalanceAfter = _balance
            });

            return true;
        }

        public decimal GetBalance() => _balance;
        public IReadOnlyList<ServerPaymentRecord> GetHistory() => _history.AsReadOnly();
    }
}

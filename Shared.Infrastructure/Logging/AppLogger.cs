using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Shared.Infrastructure.Logging
{
    public class AppLogger<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public AppLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogError(string message, Exception? ex = null)
        {
            _logger.LogError(ex,"[ERROR] {Message}", message);
        }

        public void LogInfo(string message)
        {
            _logger.LogInformation("[INFO] {Message}", message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning("[WARN] {Message}", message);
        }
    }
}

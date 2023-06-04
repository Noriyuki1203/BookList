using Microsoft.Extensions.Logging;

namespace ApiBookList
{
    public class AppLogger
    {
        private readonly ILogger _logger;

        public AppLogger(ILogger<AppLogger> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        // 同様に、他のログレベルのメソッドも追加できます。例えば、エラーレベルのログ出力メソッドは以下のようになります。
        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        // その他のログレベルについても同様です。
        public void LogDebug(string message)
        {
            _logger.LogDebug(message);
        }
    }
}


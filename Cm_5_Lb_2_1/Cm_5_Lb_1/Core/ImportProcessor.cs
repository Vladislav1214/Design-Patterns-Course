using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using System;
using System.IO;

namespace Cm_5_Lb_1.Core
{
    public class ImportProcessor
    {
        private readonly IDataReader _reader;
        private readonly ITransactionParser _parser;
        private readonly ITransactionValidator _validator;
        private readonly ITransactionRepository _repository;
        private readonly IProgressReporter _reporter;

        public ImportProcessor(
            IDataReader reader,
            ITransactionParser selectedParser,
            ITransactionValidator validator,
            ITransactionRepository repository,
            IProgressReporter reporter)
        {
            _reader = reader;
            _parser = selectedParser;
            _validator = validator;
            _repository = repository;
            _reporter = reporter;
        }

        public ImportResult Process(string filePath)
        {
            try
            {
                if (!_reader.Exists(filePath))
                {
                    throw new FileNotFoundException($"Джерело даних не знайдено: {filePath}");
                }

                _reporter.ReportProgress(10);

                using Stream stream = _reader.Open(filePath);

                var transactions = _parser.Parse(stream);
                var validTransactions = _validator.Validate(transactions);

                int saved = _repository.Save(validTransactions);

                if (saved == 0)
                {
                    throw new InvalidDataException(
                        "Джерело не містить жодної валідної транзакції або має неправильну структуру.");
                }

                _reporter.ReportProgress(100);

                return new ImportResult
                {
                    IsSuccess = true,
                    ProcessedCount = saved
                };
            }
            catch (Exception ex)
            {
                return new ImportResult
                {
                    IsSuccess = false,
                    ErrorMessage = $"Помилка імпорту: {ex.Message}"
                };
            }
        }
    }
}

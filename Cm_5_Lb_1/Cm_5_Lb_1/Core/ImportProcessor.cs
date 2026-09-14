using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Core
{
    internal class ImportProcessor
    {
        private IDataReader _reader;
        private ITransactionParser _parser;
        private ITransactionValidator _validator;
        private ITransactionRepository _repository;
        private IProgressReporter _reporter;

        public ImportResult Process(string filePath)
        {
            try
            {
                _reporter.ReportProgress(10);

                string content = _reader.Read(filePath);

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new InvalidOperationException("Джерело даних порожнє.");
                }
                _reporter.ReportProgress(30);

                var transactions = _parser.Parse(content);

                if (transactions == null || !transactions.Any())
                {
                    throw new InvalidDataException("Джерело не містить жодної транзакції або має неправильну структуру.");
                }
                _reporter.ReportProgress(50);

                var validTransactions = _validator.Validate(transactions);
                _reporter.ReportProgress(70);

                _repository.Save(validTransactions);
                _reporter.ReportProgress(100);

                return new ImportResult
                {
                    IsSuccess = true,
                    ProcessedCount = validTransactions.Count()
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

        public ImportProcessor(
            IDataReader reader, 
            ITransactionParser selectedParser, 
            ITransactionValidator validator, 
            ITransactionRepository repository, 
            IProgressReporter reporter
            )
        {
            _reader = reader;
            _parser = selectedParser;
            _validator = validator;
            _repository = repository;
            _reporter = reporter;
        }
    }
}

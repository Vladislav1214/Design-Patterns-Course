using Cm_5_Lb_1.Interfase;
using System;

namespace Cm_5_Lb_1.Core
{
    public class ImportProcessorBuilder
    {
        private IDataReader? _reader;
        private ITransactionParser? _parser;
        private ITransactionValidator? _validator;
        private ITransactionRepository? _repository;
        private IProgressReporter? _reporter;

        public ImportProcessorBuilder UseReader(IDataReader reader)
        {
            _reader = reader;
            return this;
        }

        public ImportProcessorBuilder UseParser(ITransactionParser parser)
        {
            _parser = parser;
            return this;
        }

        public ImportProcessorBuilder UseValidator(ITransactionValidator validator)
        {
            _validator = validator;
            return this;
        }

        public ImportProcessorBuilder UseRepository(ITransactionRepository repository)
        {
            _repository = repository;
            return this;
        }

        public ImportProcessorBuilder UseReporter(IProgressReporter reporter)
        {
            _reporter = reporter;
            return this;
        }

        public ImportProcessor Build()
        {
            if (_reader == null) throw new InvalidOperationException("Reader не налаштовано!");
            if (_parser == null) throw new InvalidOperationException("Parser не налаштовано!");
            if (_validator == null) throw new InvalidOperationException("Validator не налаштовано!");
            if (_repository == null) throw new InvalidOperationException("Repository не налаштовано!");
            if (_reporter == null) throw new InvalidOperationException("Reporter не налаштовано!");

            return new ImportProcessor(_reader, _parser, _validator, _repository, _reporter);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ultra.Core.Infrastructure.Commands
{
    public class CommandResult
    {
        private CommandResult(List<ValidationError> validationErrors)
        {
            this.ValidationErrors = validationErrors ?? new List<ValidationError>();
        }

        public List<ValidationError> ValidationErrors { get; private set; }
        public bool WasSuccessful() => !ValidationErrors.Any();

        public static CommandResult Success()
        {
            return new CommandResult(null);
        }

        public static CommandResult NotValid(List<ValidationError> validationResult)
        {
            if (validationResult == null) throw new ArgumentNullException(nameof(validationResult));
            if (validationResult.Any())
                throw new ArgumentException(
                    "Cannot create NotValid command result if no validation errors have occurred.",
                    nameof(validationResult));

            return new CommandResult(validationResult);
        }
    }
}
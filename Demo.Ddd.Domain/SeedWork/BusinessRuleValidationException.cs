using System;

namespace Demo.Ddd.Domain.SeedWork
{
    public class BusinessRuleValidationException : Exception
    {
        public IBusinessRule BrokenRule { get; }

        public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
        {
            this.BrokenRule = brokenRule;
        }

        public override string ToString()
        {
            return $"{BrokenRule.GetType().Name}: {BrokenRule.Message}";
        }
    }
}

namespace RubSort.Core.Results
{
    public class ValidationResult : Result<ValidationError>
    {
        
    }
    
    public class ValidationResult<TValue> : Result<TValue, ValidationError>
    {
        
    }
}
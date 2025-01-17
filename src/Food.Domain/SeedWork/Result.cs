﻿namespace Food.Domain.SeedWork
{    
    public class Result
    {        
        protected internal Result(bool isSuccess, Error error)
        {            
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)            
                throw new Exception("Result is not valid");                        

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public Error Error { get; }
        public bool IsFailure => !IsSuccess;        

        public static Result Success() => new(true, Error.None);               

        public static Result<TType> Success<TType>(TType type) => new(type, true, Error.None);

        public static Result<T> Failure<T>(Error error) => new(default, false, error);

        public static Result Failure(Error error) => new(false, error);        

    }

    public class Result<TValue> : Result
    {
        private readonly TValue _value;        

        public Result(TValue value, bool isSuccess, Error error)
            : base(isSuccess, error) =>
            _value = value;

        // For JsonConvert
        //private Result() : base() { }

        public TValue? Value => IsSuccess && _value is not null
            ? _value!
            : default;        

        public static implicit operator Result<TValue>(TValue value) => 
            new(value, true, Error.None);        
        
    }    
}

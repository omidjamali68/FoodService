﻿namespace Food.Domain.SeedWork
{
    public class Error : IEquatable<Error>
    {
        public string Code { get; }
        public string Message { get; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static Error None => Create(string.Empty, string.Empty);        

        public static implicit operator string(Error error) => error.Code;
        public static implicit operator Result(Error error) => Result.Failure(error);        

        public static Error Create(string code, string message) => new(code, message);

        public static bool operator ==(Error? a, Error? b)
        {
            if (a is null && b is null) return true;

            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Error? first, Error? second)
        {
            return !(first == second);
        }

        public bool Equals(Error? other)
        {
            if (other is null)
                return false;

            if (other.GetType() != GetType())
                return false;

            return this.Code == other.Code && this.Message == other.Message;
        }
    }
}

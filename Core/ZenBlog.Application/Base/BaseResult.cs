using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace ZenBlog.Application.Base;

public class BaseResult<T>
{
    public T? Data { get; set; }
    public IEnumerable<Error>? Errors { get; set; }

    [JsonIgnore]//Json da göstermemek için
    public bool IsSuccess => Errors == null || !Errors.Any();
    [JsonIgnore]//Json da göstermemek için
    public bool IsFailure => !IsSuccess;




    public static BaseResult<T> Success(T data)
    {
        return new BaseResult<T>
        {
            Data = data
        };
    }

    public static BaseResult<T> Fail(string error)
    {

        return new BaseResult<T>
        {
            Errors = [new Error { ErrorMessage = error }]
        };
    }


    public static BaseResult<T> Fail()
    {

        return new BaseResult<T>
        {
            Errors = [new Error { ErrorMessage = "An Unexpected Error Occured" }]
        };
    }


    public static BaseResult<T> Fail(IEnumerable<IdentityError> errors)
    {

        return new BaseResult<T>
        {
            Errors = (from error in errors
                      select new Error { PropertyName = error.Code, ErrorMessage = error.Description })
        };
    }



    public static BaseResult<T> Fail(IEnumerable<string> errors)
    {

        return new BaseResult<T>
        {
            Errors = (from error in errors
                      select new Error { ErrorMessage = error })
        };
    }

    public static BaseResult<T> NotFound(string message)
    {
        return new BaseResult<T>
        {
            Errors = [new Error { ErrorMessage = message }]
        };
    }


}


public class Error
{
    public string? PropertyName { get; set; }
    public string? ErrorMessage { get; set; }
}
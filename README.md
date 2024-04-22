## Description
A compact results library similar to FluentResults, offering all essential features for effective error handling and response management.

## How to Use the Library
The library offers four main result types, each suited for different scenarios:

1. **`Result`**: Indicates a simple success or failure of an operation.
2. **`Result<T>`**: Returns a value if the operation is successful.
3. **`Result<T, TError>`**: Returns a value or a custom error if the operation fails.
4. **`SuccessOr<TError>`**: Indicates success or returns a custom error for operations that do not return a value.

### `Result`
Use `Result` to simply indicate the success or failure of an operation.

#### Usage Example
```cs
Result DoWork()  
{  
    if (isOperationSuccessful) 
    {        
	    return Result.Ok();  
    }    
    else  
    {  
        return Result.Fail("Operation is unsuccessful"); 
    }
}
```

#### Properties
``` cs 
Result result = DoWork(); 

result.IsSuccess; 
result.ErrorMessage; 
```

- `IsSuccess`: Returns `true` if the operation was successful.
- `ErrorMessage`: Provides the error message if the operation failed.

### `Result<T>`
Use `Result<T>` when the operation needs to return a value upon success.

#### Usage Example
```cs
Result<int> DoWork()  
{  
    int valueToReturn = 123;
    if (isOperationSuccessful)  
    {        
	    return Result.Ok(valueToReturn);  
    }    
    else  
    {  
        return Result.Fail("Operation is unsuccessful");  
    }
}
```

#### Properties
``` cs 
Result<int> result = DoWork(); 

result.IsSuccess; 
result.Value; 
result.ErrorMessage; 
```

- `IsSuccess`: Indicates if the operation was successful.
- `Value`: The value returned by the operation (e.g., 123).
- `ErrorMessage`: The error message if the operation failed.

### `Result<T, TError>`
Use `Result<T, TError>` to return either a value upon success or a custom error if the operation fails.

#### Usage Example
```cs
Result<int, CustomError> DoWork()  
{  
    int valueToReturn = 123;  
    if (isOperationSuccessful)  
    {        
	    return Result.Ok(valueToReturn);  
    }    
    else  
    {  
		return Result.Fail(new CustomError(666, "Error message")); 
    }
}
```

#### Custom Error Class
```cs
public class CustomError
{  
    public int StatusCode { get; init; }  
    public string Message { get; init; }  

    public CustomError(int statusCode, string message)  
    {  
        StatusCode = statusCode;  
        Message = message;  
    }
}
```

#### Properties
``` cs 
Result<int, CustomError> result = DoWork(); 

result.IsSuccess; 
result.Value; 
result.Error; 
```

- `IsSuccess`: Whether the operation succeeded.
- `Value`: The value returned if successful.
- `Error`: The custom error returned if the operation failed.

### `SuccessOr<TError>`
Use `SuccessOr<TError>` for operations that don't return a value but may fail with a custom error.

#### Usage Example
```cs
SuccessOr<CustomError> DoWork()  
{  
    if (isOperationSuccessful)  
    {        
	    return Result.Ok();  
    }    
    else  
    {  
        return Result.Fail(new CustomError(666, "Error message"));  
    }
}
```

#### Properties
``` cs 
SuccessOr<CustomError> result = DoWork(); 

result.IsSuccess; 
result.Error; 
```

- `IsSuccess`: Indicates if the operation was successful.
- `Error`: The custom error returned if the operation failed.

## License
This project is licensed under the MIT License - see the LICENSE.txt file for details.

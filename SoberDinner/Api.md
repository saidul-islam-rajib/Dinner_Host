# Sober Dinner API
- [Sober Dinner API](#sober-dinner-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response)
#
# Presentation Layer
- [Sober Dinner API](#sober-dinner-api)
    - [DinnersController](#dinner-controller)
    - [UsersController](#users-controller)
    - [AuthenticationController](#authentication-controller)
- [Services](#services)
        - [UserService](#user-service)
        - [IUserService](#iuser-service) 
- [Common](#common)
    - [Mappings](#mappings)
        - [AuthMappingConfig](#auth-mapping-config)
        - [DinnerMappingConfig](#dinner-mapping-config)
        - [UserMappingConfig](#user-mapping-config)
        - [MappingDependencyInjection](#mapping-dependency-injection)
- [Program.cs](#program-cs)

#

- [Sober Dinner Contract](#sober-dinner-contract)
    - [Authentication](#authentication)
        - [Register Request](#register-request)
        - [Login Request](#login-request)
        - [Authentication Response](#authentication-response)
    - [Dinner](#dinner)
        - [CreateDinnerRequest](#dinner-request)
        - [DinnerResponse](#dinner-response)
    - [User](#user)
        - [UserResponse](#user-response)
    - [Common](#common)
        - [UpcomingDinner](#upcoming-dinner)
        - [Host](#host)
        - [Guest](#guest)


# Authentication
```js
### POST {{host}}/auth/register
```
#### Register Request
```json
{
    "firstName":"Saidul Islam",
    "lastName":"Rajib",
    "email":"saidul.is.rajib@gmail.com",
    "password":"Test@123"
}
```

#### Register Response
```json
{
    "id":"f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "firstName":"Saidul Islam",
    "lastName":"Rajib",
    "email":"saidul.is.rajib@gmail.com",
    "token":"lorem....sdfsdf"
}
```


#### Login Request
```json
### POST {{host}}/auth/login
```

```json
{
    "email":"saidul.is.rajib@gmail.com",
    "password":"Test@123"
}
```

#### Login Response
```json
{
    "id":"f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "firstName":"Saidul Islam",
    "lastName":"Rajib",
    "email":"saidul.is.rajib@gmail.com",
    "token":"lorem....sdfsdf"
}
```



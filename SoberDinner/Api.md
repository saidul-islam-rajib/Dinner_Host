# Sober Dinner API
- [Sober Dinner API](#sober-dinner-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response)

- [Sober Dinner Contract](#sober-dinner-contract)
    - [Authentication](#authentication)
        - [Register Request](#register-request)
        - [Login Request](#login-request)
        - [Authentication Response](#authentication-response)


# Authentication
```js
### POST {{host}}/auth/register
```
#### Register Request
```json
{
    "firstName":"Saidul Islam",
    "lastName":"Rajib",
    "email":"saidul.is.rajib@gmail.com"
    "password":"Test@123"
}
```

#### Register Response
```json
{
    "id":"f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "firstName":"Saidul Islam",
    "lastName":"Rajib",
    "email":"saidul.is.rajib@gmail.com"
    "token":"lorem....sdfsdf"
}
```


#### Login Request
```json
### POST {{host}}/auth/login
```

```json
{
    "email":"saidul.is.rajib@gmail.com"
    "password":"Test@123"
}
```

#### Login Response
```json
{
    "id":"f47ac10b-58cc-4372-a567-0e02b2c3d479",
    "firstName":"Saidul Islam",
    "lastName":"Rajib",
    "email":"saidul.is.rajib@gmail.com"
    "token":"lorem....sdfsdf"
}
```



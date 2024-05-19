# Menu Section
### Menu Request
```js
{
  "name": "test name",
  "description": "just for testing",
  "sections": [
    {
      "name": "section name",
      "description": "section description",
      "items": [
        {
          "name": "item name",
          "description": "item description"
        }
      ]
    }
  ]
}
```



### Menu Response
```js
POST hosts/{{hostId}}/menus
```
```js
{
    "id": "db4f5e35-0700-48e8-b146-fe88241b078d",
    "name": "test name",
    "description": "just for testing",
    "averageRating": null,
    "sectionResponse": null,
    "hostId": "6969b2f9-5de5-4fda-8371-730a45b3ca7e",
    "dinnerIds": [],
    "menuReviewIds": [],
    "createdDateTime": "2024-05-19T08:18:00.903828Z",
    "updatedDateTime": "2024-05-19T08:18:00.9038283Z"
}
```

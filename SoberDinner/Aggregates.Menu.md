# Domain Models
## Menu

```csharp
class Menu
{
	Menu Create();
	void AddDinner(Dinner dinner)
	void RemoveDinner(Dinner dinner)
	void UpdateSection(MenuSection section)
}
```


```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "name": "Yummy Menu",
    "description": "A menu with yummy food",
    "averageRating": 4.5,
    "sections": [
        {
            "id": { "value": "00000000-0000-0000-0000-000000000000" },
            "name": "Fast food",
            "description": "just to test",
            "items": [
                {
                    "id": { "value": "00000000-0000-0000-0000-000000000000" },
                    "name": "Pizza",
                    "description": "Tasty pizza"
                }
            ]
        }
    ],
    "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
    "dinnerIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "menuReviewIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```

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


### Menu Response
```json
{
    "id": "6126960c-0e94-46d6-a270-e836bf767b6a",
    "name": "Menu Name",
    "description": "Menu description will be here",
    "averageRating": 0,
    "sections": [
        {
            "id": "07e8b33e-5b0c-4fc2-b284-2c92e5dd3fd9",
            "name": "1st Section Name",
            "description": "1st section description will be here",
            "items": [
                {
                    "id": "a1d50fea-36d7-490a-ba50-2b4879215e01",
                    "name": "1st item name",
                    "description": "1st item description will be here"
                },
                {
                    "id": "9489cdcf-5575-42ec-8872-7ab06571811b",
                    "name": "2nd item name",
                    "description": "2nd item description will be here"
                }
            ]
        },
        {
            "id": "ed88ba10-41ef-436f-b1dd-98ab45bf39fe",
            "name": "2nd Section Name",
            "description": "2nd section description will be here",
            "items": [
                {
                    "id": "8ddcc30c-dff4-4c0c-bc4f-32c0a9caca1b",
                    "name": "3rd item name",
                    "description": "3rd item description will be here"
                },
                {
                    "id": "fafdb99d-1ac8-4c7f-ad06-028f872d7814",
                    "name": "4th item name",
                    "description": "4th item description will be here"
                }
            ]
        }
    ],
    "hostId": "123e4567-e89b-12d3-a456-426614174000",
    "dinnerIds": [],
    "menuReviewIds": [],
    "createdDateTime": "0001-01-01T00:00:00",
    "updatedDateTime": "0001-01-01T00:00:00"
}
```

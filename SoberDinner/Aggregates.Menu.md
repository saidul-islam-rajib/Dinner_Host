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
	"id":"00000000-0000-0000-0000-000000000000",
	"name":"Menu 1",
	"description":"menu 1 description",
	"averageRating":4.5,
	"sections":[
		{
			"id":"00000000-0000-0000-0000-000000000000",
			"name":"section name",
			"description":"section description",
			"items":[
				{
					"id":"00000000-0000-0000-0000-000000000000",
					"name":"Item 1",
					"description":"item description",
					"price":120.6,
				}
			]
		}
	],
	"createdDateTime":"2024-01-01T00:00:00.000000Z",
	"updatedDateTime":"2024-01-01T00:00:00.000000Z",
	
	"hostId":"00000000-0000-0000-0000-000000000000",
	"dinnerIds": [
		"00000000-0000-0000-0000-000000000000",
		"00000000-0000-0000-0000-000000000000"
	],
	"menuReviewIds":[
		"00000000-0000-0000-0000-000000000000"
	],
	
	
}
```

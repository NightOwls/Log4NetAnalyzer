
printjson(
	
	//db.Log.Domain.LogRecord.findOne()


	db.Log.Domain.LogRecord.aggregate(
		{
			$group:
				{
					_id: {GroupItem : "$Logger", Level : "$Level"},
						
					count:{$sum:1}
				}
		},
		{
			$group:
			{
				_id: "$_id.GroupItem",
				Errors: {$push: {Level: "$_id.Level", Count: "$count"}}
			}
		},
		{
			$project: 
			{
				_id: 0,
				Logger: "$_id",
				Errors: "$Errors"

			}
		}
		
	)
);

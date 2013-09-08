
printjson(
	
	//db.Log.Domain.LogRecord.findOne()


	db.Log.Domain.LogRecord.aggregate(
		{
			$match:
			{
				"$LogTime" : 
					{ 
						$gt: new Date(2013, 08, 19), 
					  	//$lt : new Date(2013, 09, 4)
					}
			}
		},
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

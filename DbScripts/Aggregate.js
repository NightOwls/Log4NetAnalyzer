
printjson(
	
	//db.Log.Domain.LogRecord.findOne()


	db.Log.Domain.LogRecord.aggregate(
		{
			$match:
			{
				LogTime : 
					{ 

	                      $gt : new ISODate("2013-09-01T00:00:00Z") ,
	                      $lt : new ISODate("2013-09-04T00:00:00Z")
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

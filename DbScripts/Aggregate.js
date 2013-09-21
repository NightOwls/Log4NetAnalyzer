
printjson(
	
	//db.Log.Domain.LogRecord.findOne()


	db.Log.Domain.LogRecord.aggregate(
		{
			$match:
			{
				LogTime : 
					{ 

	                      $gt : new ISODate("2013-08-01T00:00:00Z") ,
	                      $lt : new ISODate("2013-09-09T00:00:00Z")
					}
					,Logger: "EvilPigeon"
			}
		},
		{ 
			$project: 
					{
						_id: "$_id",
        				logger: "$Logger",
        				level: "$Level",
				        hour: {$hour: "$LogTime"},
				        day: {$dayOfMonth: "$LogTime"},
				        month: {$month: "$LogTime"},
				        year: {$year: "$LogTime"}
    				}
    	},
		{
			$group:
				{
					_id: 
						{
							groupItem : "$logger", 
							level : "$level", 
							hour : "$hour",
							day : "$day",
							month : "$month",
							year : "$year"
						},
						
					count:{$sum:1}
				}
		},
		{
			$group:
			{
				_id: {
						groupItem : "$_id.groupItem"
					 },
				Errors: 
					{
							$push: 
								{
									Level: "$_id.level", 
									hour : "$_id.hour",
									day : "$_id.day",
									month : "$_id.month",
									year : "$_id.year",
									Count: "$_id.count"
								}
					}
			}
		},
		{
			$project: 
			{
				_id: 0,
				Logger: "$_id.groupItem",
				Errors: "$Errors"

			}
		},
		{
				$sort: {Logger : 1, Level:1, year:1, month:1, day:1, hour:1}
		}
		
	)
);

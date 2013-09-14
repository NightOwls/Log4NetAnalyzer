printjson(

	//db.Log.Domain.LogRecord.find()
	db.Log.Domain.LogRecord.find(
				{
					LogTime : 
							{ 
			                      $gt : new ISODate("2013-09-01T00:00:00Z"),
			                      $lt : new ISODate("2013-09-04T00:00:00Z")
							}
				}
			)

);
